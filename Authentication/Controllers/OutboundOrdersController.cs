using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Authentication.Data;
using Authentication.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System.Dynamic;
using Microsoft.AspNetCore.Identity;

namespace Authentication.Controllers
{
    public class OutboundOrdersController : Controller
    {
        private readonly WMContext _context;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly string[] lHeader = { "Status", "Order Number", "Order Type", "Plan Ship Date", "Customer", "Invoice Number", "Description", "Create By", "Create Date", "Edit By", "Edit Date", "Cancel By", "Cancel Date", "Cancel Remark" };

        public OutboundOrdersController(WMContext context, RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _context = context;
            _roleManager = roleManager;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IActionResult> Index()
        {
            var tempData = SetPageNumber(null, false, null);
            var vOutboundOrder = (from OO in _context.OutboundOrder.Include(e => e.OrderType).Include(e => e.StatusOutboundOrder).Include(e => e.Customer)
                                  orderby OO.create_date ascending
                                  select OO).Skip(tempData.SkipRec).Take(tempData.PerPage);

            var orderType = _context.OrderType.Where(x => x.type.Contains("O") || x.type.Contains("IO")).Select(s => new { Id = (int?)s.Id, Type = s.order_type }).ToList();
            orderType.Insert(0, new
            {
                Id = new Nullable<int>(),
                Type = "Select"
            });

            var customer = _context.Customer.Where(x => x.active == true).OrderBy(x => x.customer_name).Select(s => new { Id = s.Id.ToString(), Name = s.customer_code + ": " + s.customer_name }).ToList();
            customer.Insert(0, new
            {
                Id = string.Empty,
                Name = "Select"
            });

            var user = _context.Users.OrderBy(x => x.UserName).Select(s => new { Id = s.Id.ToString(), Username = s.UserName }).ToList();
            user.Insert(0, new
            {
                Id = String.Empty,
                Username = "Select"
            });
            setSearchState(false);
            Temp.lSearch.Clear();
            Temp.iSearchCount = 0;

            ViewData["Header"] = lHeader;
            ViewData["OrderTypeList"] = new SelectList(orderType, "Id", "Type");
            ViewData["CustomerList"] = new SelectList(customer, "Id", "Name");
            ViewData["UserList"] = new SelectList(user, "Id", "Username");
            ViewBag.btn_edit = "Y";
            ViewBag.btn_del = "Y";
            ViewBag.Mode = "outbound";
            return View(await vOutboundOrder.ToListAsync());
        }

        public IActionResult CreateOutboundOrder()
        {
            var outboundOrder = new OutboundOrder
            {
                Id = Guid.NewGuid()
            };
            var orderType = _context.OrderType.Where(x => x.type.Contains("O") || x.type.Contains("IO")).Select(s => new { Id = (int?)s.Id, Type = s.order_type }).ToList();
            orderType.Insert(0, new
            {
                Id = new Nullable<int>(),
                Type = "Select"
            });

            var customer = _context.Customer.Where(x => x.active == true).OrderBy(x => x.customer_name).Select(s => new { Id = s.Id.ToString(), Name = s.customer_code + ": " + s.customer_name }).ToList();
            customer.Insert(0, new
            {
                Id = string.Empty,
                Name = "Select"
            });


            ViewData["OrderTypeList"] = new SelectList(orderType, "Id", "Type");
            ViewData["CustomerList"] = new SelectList(customer, "Id", "Name");
            ViewData["Status"] = "Draft";
            return View(outboundOrder);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateOutboundOrder([Bind("Id, order_no, plan_ship_date, invoice_no, OrderTypeId, CustomerId, create_by, create_date, edit_by, edit_date, cancel_by, cancel_date, cancel_remark, StatusOutboundOrderId")] OutboundOrder outboundOrder, string txtDescription)
        {
            if (ModelState.IsValid) // Check binding success
            {
                var fOO = await _context.OutboundOrder.FirstOrDefaultAsync(m => m.order_no == outboundOrder.order_no);
                if (fOO != null)
                {
                    return NotFound();
                }

                outboundOrder.create_date = DateTime.Now;
                outboundOrder.create_by = User.Identity.Name; //Program.username;
                outboundOrder.edit_date = null;

                StatusOutboundOrder oSOO = new StatusOutboundOrder();
                Guid oStatusId = Guid.NewGuid();
                oSOO.Id = oStatusId;
                oSOO.status = "open";
                oSOO.description = txtDescription;
                oSOO.create_date = DateTime.Now;
                oSOO.create_by = User.Identity.Name;
                oSOO.OutboundOrderId = outboundOrder.Id;
                _context.Add(oSOO);
                await _context.SaveChangesAsync();

                outboundOrder.StatusOutboundOrderId = oStatusId;
                _context.Add(outboundOrder);
                await _context.SaveChangesAsync();
                return RedirectToAction("EditOutboundOrder", new { id = outboundOrder.Id });
            }

            return View(outboundOrder);
        }

        public IActionResult EditOutboundOrder(Guid id)
        {
            if (id == Guid.Empty || id == null)
            {
                return NotFound();
            }

            var vOutboundOrder = _context.OutboundOrder.Include(x => x.StatusOutboundOrder).Where(x => x.Id == id).FirstOrDefault();
            if (vOutboundOrder == null)
            {
                return NotFound();
            }

            var orderType = _context.OrderType.Where(x => x.type.Contains("O") || x.type.Contains("IO")).Select(s => new { Id = (int?)s.Id, Type = s.order_type }).ToList();
            orderType.Insert(0, new
            {
                Id = new Nullable<int>(),
                Type = "Select"
            });

            var customer = _context.Customer.Where(x => x.active == true).OrderBy(x => x.customer_name).Select(s => new { Id = s.Id.ToString(), Name = s.customer_code + ": " + s.customer_name }).ToList();
            customer.Insert(0, new
            {
                Id = string.Empty,
                Name = "Select"
            });

            var tempData = SetPageNumberItem(id);
            var outboundItem = (from S in _context.OutboundItem.Include(e => e.OutboundOrder).Include(e => e.ItemReceivedState).Include(e => e.Item).Include("Item.ItemCategory").Where(e => e.OutboundOrderId == id)
                               orderby S.create_date ascending
                               select S).Skip(tempData.SkipRecItm).Take(tempData.PerPageItm);

            //string[] lHeaderItem = { "Item Name", "Item Type", "State", "Cost", "Quantity Order", "Create By", "Create Date", "Edit By", "Edit Date" };
            string[] lHeaderItem = { "Item Name", "Item Type", "State", "Quantity Order", "Create By", "Create Date", "Edit By", "Edit Date" };

            ViewData["OutboundItem"] = outboundItem;
            ViewData["OrderTypeList"] = new SelectList(orderType, "Id", "Type");
            ViewData["CustomerList"] = new SelectList(customer, "Id", "Name");
            ViewData["Status"] = "Open";
            ViewData["Header"] = lHeader;
            ViewData["HeaderSubMenu"] = lHeaderItem;
            ViewBag.btn_receive = "N";
            ViewBag.btn_store = "N";
            return View(vOutboundOrder);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditOutboundOrder(Guid id, [Bind("Id, order_no, plan_ship_date, invoice_no, OrderTypeId, CustomerId, create_by, create_date, edit_by, edit_date, cancel_by, cancel_date, cancel_remark, StatusOutboundOrderId")] OutboundOrder outboundOrder, string txtDescription)
        {
            if (id != outboundOrder.Id)
            {
                return NotFound();
            }
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            if (ModelState.IsValid) // Check binding success
            {
                try
                {
                    var vStatus = await _context.StatusOutboundOrder.FirstOrDefaultAsync(m => m.OutboundOrderId == outboundOrder.Id);
                    vStatus.description = txtDescription;
                    _context.Update(vStatus);
                    await _context.SaveChangesAsync();

                    outboundOrder.edit_date = DateTime.Now;
                    outboundOrder.edit_by = User.Identity.Name;
                    _context.Update(outboundOrder);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("EditOutboundOrder", new { id = outboundOrder.Id });
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OutboundOrderExists(outboundOrder.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }

            return View(outboundOrder);
        }

        public IActionResult DeleteOutboundOrder(Guid id)
        {
            if (id == Guid.Empty || id == null)
            {
                return NotFound();
            }

            var vOutboundOrder = _context.OutboundOrder.Include(x => x.StatusOutboundOrder).Where(x => x.Id == id).FirstOrDefault();
            if (vOutboundOrder == null)
            {
                return NotFound();
            }

            return View(vOutboundOrder);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteOutboundOrder(Guid id, [Bind("Id, order_no, plan_ship_date, invoice_no, OrderTypeId, CustomerId, create_by, create_date, edit_by, edit_date, cancel_by, cancel_date, cancel_remark, StatusOutboundOrderId")] OutboundOrder outboundOrder)
        {
            if (id != outboundOrder.Id)
            {
                return NotFound();
            }
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            if (ModelState.IsValid) // Check binding success
            {
                try
                {
                    var vStatus = _context.StatusOutboundOrder.Where(x => x.OutboundOrderId == outboundOrder.Id);
                    var vOutboundItem = _context.OutboundItem.Where(x => x.OutboundOrderId == outboundOrder.Id);

                    _context.StatusOutboundOrder.RemoveRange(vStatus);
                    _context.OutboundItem.RemoveRange(vOutboundItem);
                    _context.OutboundOrder.Remove(outboundOrder);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OutboundOrderExists(outboundOrder.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                if (Temp.bSearchState == false)
                {
                    return RedirectToAction(nameof(ViewContent));
                }
                else
                {
                    int? iOrderType = null;
                    if (Temp.lSearch[2] != null)
                    {
                        iOrderType = int.Parse(Temp.lSearch[2]);
                    }
                    string sCustomer = Guid.Empty.ToString();
                    if (Temp.lSearch[7] != null)
                    {
                        sCustomer = Temp.lSearch[7];
                    }

                    return RedirectToAction("ViewContent", new { status = Temp.lSearch[0], ordernumber = Temp.lSearch[1], ordertype = iOrderType, sshipdate = Temp.lSearch[3], startshipdate = Convert.ToDateTime(Temp.lSearch[4]), endshipdate = Convert.ToDateTime(Temp.lSearch[5]), invoiceno = Temp.lSearch[6], customer = sCustomer, description = Temp.lSearch[8], createby = Temp.lSearch[9], screatedate = Temp.lSearch[10], startcreatedate = Convert.ToDateTime(Temp.lSearch[11]), endcreatedate = Convert.ToDateTime(Temp.lSearch[12]), editby = Temp.lSearch[13], seditdate = Temp.lSearch[14], starteditdate = Convert.ToDateTime(Temp.lSearch[15]), endeditdate = Convert.ToDateTime(Temp.lSearch[16]), cancelby = Temp.lSearch[17], scanceldate = Temp.lSearch[18], startcanceldate = Convert.ToDateTime(Temp.lSearch[19]), endcanceldate = Convert.ToDateTime(Temp.lSearch[20]), cancelremark = Temp.lSearch[21] });
                }
            }

            return View(outboundOrder);
        }

        public IActionResult ConfirmDeleteOrder(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var vObject = _context.OutboundOrder.Where(x => x.Id == Guid.Parse(id)).FirstOrDefault();
            if (vObject == null)
            {
                return NotFound();
            }

            return View(vObject);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmDeleteOrder(Guid id, [Bind("Id, order_no, plan_ship_date, invoice_no, OrderTypeId, CustomerId, create_by, create_date, edit_by, edit_date, cancel_by, cancel_date, cancel_remark, StatusOutboundOrderId")] OutboundOrder outboundOrder, string ipPassword)
        {
            if (id != outboundOrder.Id)
            {
                return NotFound();
            }
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            if (ModelState.IsValid) // Check binding success
            {
                try
                {
                    var vStatus = _context.StatusOutboundOrder.Where(x => x.OutboundOrderId == outboundOrder.Id);
                    var vOutboundItem = _context.OutboundItem.Where(x => x.OutboundOrderId == outboundOrder.Id);

                    _context.StatusOutboundOrder.RemoveRange(vStatus);
                    _context.OutboundItem.RemoveRange(vOutboundItem);
                    _context.OutboundOrder.Remove(outboundOrder);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OutboundOrderExists(outboundOrder.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                if (Temp.bSearchState == false)
                {
                    return RedirectToAction(nameof(ViewContent));
                }
                else
                {
                    int? iOrderType = null;
                    if (Temp.lSearch[2] != null)
                    {
                        iOrderType = int.Parse(Temp.lSearch[2]);
                    }
                    string sCustomer = Guid.Empty.ToString();
                    if (Temp.lSearch[7] != null)
                    {
                        sCustomer = Temp.lSearch[7];
                    }

                    return RedirectToAction("ViewContent", new { status = Temp.lSearch[0], ordernumber = Temp.lSearch[1], ordertype = iOrderType, sshipdate = Temp.lSearch[3], startshipdate = Convert.ToDateTime(Temp.lSearch[4]), endshipdate = Convert.ToDateTime(Temp.lSearch[5]), invoiceno = Temp.lSearch[6], customer = sCustomer, description = Temp.lSearch[8], createby = Temp.lSearch[9], screatedate = Temp.lSearch[10], startcreatedate = Convert.ToDateTime(Temp.lSearch[11]), endcreatedate = Convert.ToDateTime(Temp.lSearch[12]), editby = Temp.lSearch[13], seditdate = Temp.lSearch[14], starteditdate = Convert.ToDateTime(Temp.lSearch[15]), endeditdate = Convert.ToDateTime(Temp.lSearch[16]), cancelby = Temp.lSearch[17], scanceldate = Temp.lSearch[18], startcanceldate = Convert.ToDateTime(Temp.lSearch[19]), endcanceldate = Convert.ToDateTime(Temp.lSearch[20]), cancelremark = Temp.lSearch[21] });
                }
            }

            return View(outboundOrder);
        }

        public IActionResult CreateResource(String id)
        {
            var outboundItem = new OutboundItem
            {
                Id = Guid.NewGuid(),
                OutboundOrderId = Guid.Parse(id)
            };

            var vOutboundOrder = _context.OutboundOrder.Where(x => x.Id == Guid.Parse(id)).FirstOrDefault();
            var vItem = _context.Item.OrderBy(x => x.create_date).Select(s => new { Id = s.Id.ToString(), Item = s.item_code + ": " + s.item_name }).ToList();
            vItem.Insert(0, new
            {
                Id = string.Empty,
                Item = "Select"
            });

            var vItemState = _context.ItemReceivedState.OrderBy(x => x.state).Select(s => new { Id = s.Id.ToString(), State = s.state }).ToList();
            vItemState.Insert(0, new
            {
                Id = string.Empty,
                State = "Select"
            });

            ViewData["ItemList"] = new SelectList(vItem, "Id", "Item");
            ViewData["ItemStateList"] = new SelectList(vItemState, "Id", "State");
            ViewData["OrderNo"] = vOutboundOrder.order_no;
            return View(outboundItem);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateResource([Bind("Id, cost, qty, remain_qty, create_by, create_date, edit_by, edit_date, OutboundOrderId, ItemId, ItemReceivedStateId")] OutboundItem outboundItem)
        {
            if (ModelState.IsValid) // Check binding success
            {
                var vOutboundOrder = _context.OutboundOrder.Where(x => x.Id == outboundItem.OutboundOrderId).FirstOrDefault();
                vOutboundOrder.edit_by = User.Identity.Name;
                vOutboundOrder.edit_date = DateTime.Now;
                _context.Update(vOutboundOrder);

                var items = await (from a in _context.Inventory
                            join b in _context.ItemReceived
                            on a.ItemReceivedId equals b.Id
                            join c in _context.InboundItem
                            on b.InboundItemId equals c.Id
                            join d in _context.InboundOrder
                            on c.InboundOrderId equals d.Id
                            join e in _context.Item
                            on c.ItemId equals e.Id
                            join f in _context.ItemCategory
                            on e.ItemCategoryId equals f.Id
                            join g in _context.Location
                            on a.LocationId equals g.Id
                            join h in _context.LocationCategory
                            on g.LocationCategoryId equals h.Id
                            where (c.ItemId == outboundItem.ItemId && (a.reserve == 0 || a.reserve < a.qty))
                            select new InventoryDetailViewModel
                            {
                                id              = a.Id,
                                orderNo         = d.order_no,
                                lotNo           = b.lot_no,
                                itemCode        = e.item_code,
                                itemName        = e.item_name,
                                itemCategory    = f.category_name,
                                cost            = b.cost,
                                unit            = a.qty,
                                receiveDate     = b.receive_date,
                                locationCode    = g.location_code,
                                locationName    = h.category_name,
                                status          = b.status,
                                reserve         = a.reserve
                            }).OrderBy(x => x.receiveDate).ToListAsync();

                int tempQty = outboundItem.qty; 
                foreach(var item in items)
                {
                    if (tempQty != 0)
                    {
                        var inventory = await _context.Inventory.Where(x => x.Id == item.id).Select(x => x).FirstOrDefaultAsync();
                        if (!string.IsNullOrWhiteSpace(inventory.user_define1))
                        {
                            inventory.user_define1 += $",{outboundItem.Id.ToString().ToUpper()}";
                        }
                        else
                        {
                            inventory.user_define1 = outboundItem.Id.ToString().ToUpper();
                        }

                        var remainReserve = item.unit - item.reserve;
                        if (remainReserve >= tempQty)
                        {
                            inventory.reserve += tempQty;

                            if(!string.IsNullOrWhiteSpace(inventory.user_define2))
                            {
                                inventory.user_define2 += $",{tempQty}";
                            }
                            else
                            {
                                inventory.user_define2 += $"{tempQty}";
                            }
                            tempQty = 0;
                        }
                        else
                        {
                            inventory.reserve += remainReserve;

                            if (!string.IsNullOrWhiteSpace(inventory.user_define2))
                            {
                                inventory.user_define2 += $",{remainReserve}";
                            }
                            else
                            {
                                inventory.user_define2 += $"{remainReserve}";
                            }

                            tempQty -= remainReserve;
                        }

                        _context.Update(inventory);
                    }
                    else
                    {
                        break;
                    }
                }

                outboundItem.create_date = DateTime.Now;
                outboundItem.create_by = User.Identity.Name; //Program.username;
                outboundItem.edit_date = null;
                _context.Add(outboundItem);
               
                await _context.SaveChangesAsync();
                return RedirectToAction("ViewResource", new { id = outboundItem.OutboundOrderId });
            }

            return View(outboundItem);
        }

        public async Task<IActionResult> EditResource(Guid id)
        {
            if (id == Guid.Empty || id == null)
            {
                return NotFound();
            }

            var vOutbounditem = await _context.OutboundItem.FindAsync(id);
            if (vOutbounditem == null)
            {
                return NotFound();
            }

            var vItem = _context.Item.Select(s => new { Id = s.Id.ToString(), Item = s.item_code + ": " + s.item_name }).ToList();
            vItem.Insert(0, new
            {
                Id = string.Empty,
                Item = "Select"
            });

            var vItemState = _context.ItemReceivedState.OrderBy(x => x.state).Select(s => new { Id = s.Id.ToString(), State = s.state }).ToList();
            vItemState.Insert(0, new
            {
                Id = string.Empty,
                State = "Select"
            });

            var vOutboundOrder = _context.OutboundOrder.Where(x => x.Id == vOutbounditem.OutboundOrderId).FirstOrDefault();

            ViewData["ItemList"] = new SelectList(vItem, "Id", "Item");
            ViewData["ItemStateList"] = new SelectList(vItemState, "Id", "State");
            ViewData["OrderNo"] = vOutboundOrder.order_no;
            return View(vOutbounditem);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditResource(Guid id, [Bind("Id, cost, qty, remain_qty, create_by, create_date, edit_by, edit_date, OutboundOrderId, ItemId, ItemReceivedStateId")] OutboundItem outboundItem)
        {
            if (id != outboundItem.Id)
            {
                return NotFound();
            }
            var error = ModelState.Values.SelectMany(v => v.Errors);
            if (ModelState.IsValid)
            {
                try
                {
                    var vOutboundOrder = _context.OutboundOrder.Where(x => x.Id == outboundItem.OutboundOrderId).FirstOrDefault();
                    vOutboundOrder.edit_by = User.Identity.Name;
                    vOutboundOrder.edit_date = DateTime.Now;
                    _context.Update(vOutboundOrder);

                    var checkOutbountItem = await _context.OutboundItem.Where(x => x.Id == outboundItem.Id).AsNoTracking().FirstOrDefaultAsync();
                    if(checkOutbountItem.qty != outboundItem.qty)
                    {
                        int tempQty = 0;
                        if (checkOutbountItem.qty > outboundItem.qty)
                        {
                            tempQty = checkOutbountItem.qty - outboundItem.qty;
                            var inventories = await (from a in _context.Inventory
                                                join b in _context.ItemReceived
                                                on a.ItemReceivedId equals b.Id
                                                join c in _context.InboundItem
                                                on b.InboundItemId equals c.Id
                                                join d in _context.InboundOrder
                                                on c.InboundOrderId equals d.Id
                                                join e in _context.Item
                                                on c.ItemId equals e.Id
                                                join f in _context.ItemCategory
                                                on e.ItemCategoryId equals f.Id
                                                join g in _context.Location
                                                on a.LocationId equals g.Id
                                                join h in _context.LocationCategory
                                                on g.LocationCategoryId equals h.Id
                                                where (c.ItemId == checkOutbountItem.ItemId && a.user_define1.Contains(checkOutbountItem.Id.ToString().ToUpper()))
                                                select new InventoryDetailViewModel
                                                {
                                                    id              = a.Id,
                                                    orderNo         = d.order_no,
                                                    lotNo           = b.lot_no,
                                                    itemCode        = e.item_code,
                                                    itemName        = e.item_name,
                                                    itemCategory    = f.category_name,
                                                    cost            = b.cost,
                                                    unit            = a.qty,
                                                    receiveDate     = b.receive_date,
                                                    locationCode    = g.location_code,
                                                    locationName    = h.category_name,
                                                    status          = b.status,
                                                    reserve         = a.reserve,
                                                    outboundList    = a.user_define1,
                                                    qtyList         = a.user_define2
                                                }).OrderByDescending(x => x.receiveDate).ToListAsync();

                            foreach (var item in inventories)
                            {
                                if (tempQty != 0)
                                {
                                    var inventory = await _context.Inventory.Where(x => x.Id == item.id).Select(x => x).FirstOrDefaultAsync();
                                    var subOutboundId = item.outboundList.Split(",");
                                    var subQty = item.qtyList.Split(",");

                                    var index = Array.IndexOf(subOutboundId, checkOutbountItem.Id.ToString().ToUpper());
                                    var qty = Convert.ToInt32(subQty[index]);

                                    if (tempQty >= qty)
                                    {
                                        if (tempQty == qty)
                                        {
                                            inventory.reserve -= tempQty;
                                        }
                                        else
                                        {
                                            inventory.reserve -= qty;
                                        }
                                        tempQty -= qty;

                                        if (subOutboundId.Count() == 1)
                                        {
                                            inventory.user_define1 = null;
                                            inventory.user_define2 = null;
                                        }
                                        else
                                        {
                                            if (index == (subOutboundId.Count() - 1))
                                            {
                                                inventory.user_define1 = inventory.user_define1.Replace($",{checkOutbountItem.Id.ToString().ToUpper()}", "");
                                            }
                                            else
                                            {
                                                inventory.user_define1 = inventory.user_define1.Replace($"{checkOutbountItem.Id.ToString().ToUpper()},", "");
                                            }
                                        }

                                        string updateQty = "";
                                        for (int i = 0; i < subQty.Length; i++)
                                        {
                                            if (i != index)
                                            {
                                                updateQty += $"{subQty[i]},";
                                            }
                                        }

                                        if (string.IsNullOrWhiteSpace(updateQty))
                                        {
                                            inventory.user_define2 = null;
                                        }
                                        else
                                        {
                                            updateQty = updateQty.Substring(0, updateQty.Length - 1);
                                            inventory.user_define2 = updateQty;
                                        }
                                    }
                                    else
                                    {
                                        inventory.reserve -= tempQty;
                                        string updateQty = "";
                                        for (int i = 0; i < subQty.Length; i++)
                                        {
                                            if (i != index)
                                            {
                                                updateQty += $"{subQty[i]},";
                                            }
                                            else
                                            {
                                                int currentReserve = qty - tempQty;
                                                updateQty += $"{currentReserve},";
                                            }
                                        }

                                        if (string.IsNullOrWhiteSpace(updateQty))
                                        {
                                            inventory.user_define2 = null;
                                        }
                                        else
                                        {
                                            updateQty = updateQty.Substring(0, updateQty.Length - 1);
                                            inventory.user_define2 = updateQty;
                                        }
                                        tempQty = 0;
                                    }
                                    _context.Update(inventory);
                                }
                                else
                                {
                                    break;
                                }
                            }

                        }
                        else if (checkOutbountItem.qty < outboundItem.qty)
                        {
                            tempQty = outboundItem.qty - checkOutbountItem.qty;
                            var inventories = await (from a in _context.Inventory
                                                join b in _context.ItemReceived
                                                on a.ItemReceivedId equals b.Id
                                                join c in _context.InboundItem
                                                on b.InboundItemId equals c.Id
                                                join d in _context.InboundOrder
                                                on c.InboundOrderId equals d.Id
                                                join e in _context.Item
                                                on c.ItemId equals e.Id
                                                join f in _context.ItemCategory
                                                on e.ItemCategoryId equals f.Id
                                                join g in _context.Location
                                                on a.LocationId equals g.Id
                                                join h in _context.LocationCategory
                                                on g.LocationCategoryId equals h.Id
                                                where (c.ItemId == checkOutbountItem.ItemId && (a.reserve == 0 || a.reserve < a.qty))
                                                select new InventoryDetailViewModel
                                                {
                                                    id              = a.Id,
                                                    orderNo         = d.order_no,
                                                    lotNo           = b.lot_no,
                                                    itemCode        = e.item_code,
                                                    itemName        = e.item_name,
                                                    itemCategory    = f.category_name,
                                                    cost            = b.cost,
                                                    unit            = a.qty,
                                                    receiveDate     = b.receive_date,
                                                    locationCode    = g.location_code,
                                                    locationName    = h.category_name,
                                                    status          = b.status,
                                                    reserve         = a.reserve,
                                                    outboundList    = a.user_define1,
                                                    qtyList         = a.user_define2
                                                }).OrderByDescending(x => x.receiveDate).ToListAsync();

                            var existOutbound = inventories.Where(x => x.outboundList != null && x.outboundList.Contains(checkOutbountItem.Id.ToString().ToUpper())).ToList();

                            foreach(var item in existOutbound)
                            {
                                if (tempQty != 0)
                                {
                                    var inventory = await _context.Inventory.Where(x => x.Id == item.id).Select(x => x).FirstOrDefaultAsync();
                                    var subOutboundId = item.outboundList.Split(",");
                                    var subQty = item.qtyList.Split(",");

                                    var index = Array.IndexOf(subOutboundId, checkOutbountItem.Id.ToString().ToUpper());
                                    var qty = Convert.ToInt32(subQty[index]);

                                    if (tempQty <= (item.unit - item.reserve))
                                    {
                                        inventory.reserve += tempQty;

                                        string updateQty = "";
                                        for (int i = 0; i < subQty.Length; i++)
                                        {
                                            if (i != index)
                                            {
                                                updateQty += $"{subQty[i]},";
                                            }
                                            else
                                            {
                                                var sumQty = qty + tempQty;
                                                updateQty += $"{sumQty},";
                                            }
                                        }

                                        if (string.IsNullOrWhiteSpace(updateQty))
                                        {
                                            inventory.user_define2 = null;
                                        }
                                        else
                                        {
                                            updateQty = updateQty.Substring(0, updateQty.Length - 1);
                                            inventory.user_define2 = updateQty;
                                        }

                                        tempQty = 0;
                                    }
                                    else
                                    {
                                        var remainReserve = item.unit - item.reserve;
                                        inventory.reserve += remainReserve;

                                        string updateQty = "";
                                        for (int i = 0; i < subQty.Length; i++)
                                        {
                                            if (i != index)
                                            {
                                                updateQty += $"{subQty[i]},";
                                            }
                                            else
                                            {
                                                var sumQty = qty + remainReserve;
                                                updateQty += $"{sumQty},";
                                            }
                                        }

                                        if (string.IsNullOrWhiteSpace(updateQty))
                                        {
                                            inventory.user_define2 = null;
                                        }
                                        else
                                        {
                                            updateQty = updateQty.Substring(0, updateQty.Length - 1);
                                            inventory.user_define2 = updateQty;
                                        }

                                        tempQty -= remainReserve;


                                    }
                                    _context.Update(inventory);
                                }
                                else
                                {
                                    break;
                                }
                            }

                            var nonExistOutbound = inventories.Where(x => x.outboundList == null || (x.outboundList != null && !x.outboundList.Contains(checkOutbountItem.Id.ToString().ToUpper()))).ToList();

                            foreach(var item in nonExistOutbound)
                            {
                                if(tempQty != 0)
                                {
                                    var inventory = await _context.Inventory.Where(x => x.Id == item.id).Select(x => x).FirstOrDefaultAsync();
                                    if (!string.IsNullOrWhiteSpace(inventory.user_define1))
                                    {
                                        inventory.user_define1 += $",{outboundItem.Id.ToString().ToUpper()}";
                                    }
                                    else
                                    {
                                        inventory.user_define1 = outboundItem.Id.ToString().ToUpper();
                                    }

                                    var remainReserve = item.unit - item.reserve;
                                    if (remainReserve >= tempQty)
                                    {
                                        inventory.reserve += tempQty;

                                        if (!string.IsNullOrWhiteSpace(inventory.user_define2))
                                        {
                                            inventory.user_define2 += $",{tempQty}";
                                        }
                                        else
                                        {
                                            inventory.user_define2 += $"{tempQty}";
                                        }
                                        tempQty = 0;
                                    }
                                    else
                                    {
                                        inventory.reserve += remainReserve;

                                        if (!string.IsNullOrWhiteSpace(inventory.user_define2))
                                        {
                                            inventory.user_define2 += $",{remainReserve}";
                                        }
                                        else
                                        {
                                            inventory.user_define2 += $"{remainReserve}";
                                        }

                                        tempQty -= remainReserve;
                                    }

                                    _context.Update(inventory);
                                }
                                else
                                {
                                    break;
                                }
                            }
                        }
                    }

                    outboundItem.edit_date = DateTime.Now;
                    outboundItem.edit_by = User.Identity.Name;
                    _context.Update(outboundItem);
                    await _context.SaveChangesAsync();

                    return RedirectToAction("ViewResource", new { id = outboundItem.OutboundOrderId });
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    if (!ItemExists(outboundItem.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return View(outboundItem);
        }

        public async Task<IActionResult> DeleteResource(Guid id)
        {
            if (id == Guid.Empty || id == null)
            {
                return NotFound();
            }

            var vOutbounditem = await _context.OutboundItem.Include(e => e.Item).Where(x => x.Id == id).FirstOrDefaultAsync();
            if (vOutbounditem == null)
            {
                return NotFound();
            }

            return View(vOutbounditem);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteResource(Guid id, [Bind("Id, cost, qty, remain_qty, create_by, create_date, edit_by, edit_date, OutboundOrderId, ItemId, ItemReceivedStateId")] OutboundItem outboundItem)
        {
            if (id != outboundItem.Id)
            {
                return NotFound();
            }
            var error = ModelState.Values.SelectMany(v => v.Errors);
            if (ModelState.IsValid)
            {
                try
                {
                    var vItem = await _context.OutboundItem.FindAsync(outboundItem.Id);

                    var inventories = await (from a in _context.Inventory
                                        join b in _context.ItemReceived
                                        on a.ItemReceivedId equals b.Id
                                        join c in _context.InboundItem
                                        on b.InboundItemId equals c.Id
                                        join d in _context.InboundOrder
                                        on c.InboundOrderId equals d.Id
                                        join e in _context.Item
                                        on c.ItemId equals e.Id
                                        join f in _context.ItemCategory
                                        on e.ItemCategoryId equals f.Id
                                        join g in _context.Location
                                        on a.LocationId equals g.Id
                                        join h in _context.LocationCategory
                                        on g.LocationCategoryId equals h.Id
                                        where (c.ItemId == vItem.ItemId && a.user_define1.Contains(vItem.Id.ToString().ToUpper()))
                                        select new InventoryDetailViewModel
                                        {
                                            id              = a.Id,
                                            orderNo         = d.order_no,
                                            lotNo           = b.lot_no,
                                            itemCode        = e.item_code,
                                            itemName        = e.item_name,
                                            itemCategory    = f.category_name,
                                            cost            = b.cost,
                                            unit            = a.qty,
                                            receiveDate     = b.receive_date,
                                            locationCode    = g.location_code,
                                            locationName    = h.category_name,
                                            status          = b.status,
                                            reserve         = a.reserve,
                                            outboundList    = a.user_define1,
                                            qtyList         = a.user_define2
                                        }).OrderBy(x => x.receiveDate).ToListAsync();

                    foreach(var item in inventories)
                    {
                        var subOutboundId = item.outboundList.Split(",");
                        var subQty = item.qtyList.Split(",");

                        var index = Array.IndexOf(subOutboundId, vItem.Id.ToString().ToUpper());

                        var subtractQty = Convert.ToInt32(subQty[index]);
                        var itemInventory = await _context.Inventory.Where(x => x.Id == item.id).Select(x => x).FirstOrDefaultAsync();
                        itemInventory.reserve -= subtractQty;

                        if (subOutboundId.Count() == 1)
                        {
                            itemInventory.user_define1 = null;
                            itemInventory.user_define2 = null;
                        }
                        else
                        {
                            if(index == (subOutboundId.Count() - 1))
                            {
                                itemInventory.user_define1 = itemInventory.user_define1.Replace($",{vItem.Id.ToString().ToUpper()}", "");
                            }
                            else
                            {
                                itemInventory.user_define1 = itemInventory.user_define1.Replace($"{vItem.Id.ToString().ToUpper()},", "");
                            }

                            string updateQty = "";
                            for(int i = 0; i < subQty.Length; i++)
                            {
                                if(i != index)
                                {
                                    updateQty += $"{subQty[i]},"; 
                                }
                            }

                            if(string.IsNullOrWhiteSpace(updateQty))
                            {
                                itemInventory.user_define2 = null;
                            }
                            else
                            {
                                updateQty = updateQty.Substring(0, updateQty.Length - 1);
                                itemInventory.user_define2 = updateQty;
                            }
                        }

                        _context.Update(itemInventory);
                    }


                    _context.OutboundItem.Remove(vItem);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("ViewResource", new { id = outboundItem.OutboundOrderId });
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItemExists(outboundItem.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return View(outboundItem);
        }

        public IActionResult ConfirmDeleteResource(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var vObject = _context.OutboundItem.Where(x => x.Id == Guid.Parse(id)).FirstOrDefault();
            if (vObject == null)
            {
                return NotFound();
            }

            return View(vObject);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmDeleteResource(Guid id, [Bind("Id, cost, qty, remain_qty, create_by, create_date, edit_by, edit_date, OutboundOrderId, ItemId, ItemReceivedStateId")] OutboundItem outboundItem)
        {
            if (id != outboundItem.Id)
            {
                return NotFound();
            }
            var error = ModelState.Values.SelectMany(v => v.Errors);
            if (ModelState.IsValid)
            {
                try
                {
                    var vItem = await _context.OutboundItem.FindAsync(outboundItem.Id);
                    _context.OutboundItem.Remove(vItem);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("ViewResource", new { id = outboundItem.OutboundOrderId });
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItemExists(outboundItem.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return View(outboundItem);
        }

        public async Task<IActionResult> ViewContent(string status, string ordernumber, int? ordertype, string sshipdate, DateTime startshipdate, DateTime endshipdate, string invoiceno, string customer, string description, string createby, string screatedate, DateTime startcreatedate, DateTime endcreatedate, string editby, string seditdate, DateTime starteditdate, DateTime endeditdate, string cancelby, string scanceldate, DateTime startcanceldate, DateTime endcanceldate, string cancelremark, string clear)
        {
            IQueryable<OutboundOrder> vOutboundOrder = (from d in _context.OutboundOrder.Include(e => e.OrderType).Include(e => e.StatusOutboundOrder).Include(e => e.Customer)
                                                      orderby d.create_date ascending
                                                      select d);
            setSearchState(false);
            Temp.lSearch.Clear();
            Temp.lSearch.Add(status);
            Temp.lSearch.Add(ordernumber);
            if (status != null)
            {
                vOutboundOrder = vOutboundOrder.Where(d => d.StatusOutboundOrder.status.Contains(status)).AsQueryable();
                setSearchState(true);
            }
            if (ordernumber != null)
            {
                vOutboundOrder = vOutboundOrder.Where(d => d.order_no.Contains(ordernumber)).AsQueryable();
                setSearchState(true);
            }
            if (ordertype != null)
            {
                vOutboundOrder = vOutboundOrder.Where(d => d.OrderTypeId == ordertype).AsQueryable();
                setSearchState(true);
                Temp.lSearch.Add(ordertype.ToString());
            }
            else
            {
                Temp.lSearch.Add(null);
            }
            if (sshipdate != null && sshipdate.Trim() == "y")
            {
                vOutboundOrder = vOutboundOrder.Where(d => d.plan_ship_date >= startshipdate.Date && d.plan_ship_date < endshipdate.AddDays(1).Date).AsQueryable();
                setSearchState(true);
                Temp.lSearch.Add(sshipdate);
                Temp.lSearch.Add(startshipdate.Date.ToString());
                Temp.lSearch.Add(endshipdate.Date.ToString());
            }
            else
            {
                Temp.lSearch.Add(null);
                Temp.lSearch.Add(null);
                Temp.lSearch.Add(null);
            }
            Temp.lSearch.Add(invoiceno);
            if (invoiceno != null)
            {
                vOutboundOrder = vOutboundOrder.Where(d => d.invoice_no.Contains(invoiceno)).AsQueryable();
                setSearchState(true);
            }
            if (customer != null && Guid.Parse(customer) != Guid.Empty)
            {
                vOutboundOrder = vOutboundOrder.Where(d => d.CustomerId == Guid.Parse(customer)).AsQueryable();
                setSearchState(true);
                Temp.lSearch.Add(customer.ToString());
            }
            else
            {
                Temp.lSearch.Add(null);
            }
            Temp.lSearch.Add(description);
            if (description != null)
            {
                vOutboundOrder = vOutboundOrder.Where(d => d.StatusOutboundOrder.description.Contains(description)).AsQueryable();
                setSearchState(true);
            }
            Temp.lSearch.Add(createby);
            if (createby != null)
            {
                var User = await _userManager.FindByIdAsync(createby.ToString());
                vOutboundOrder = vOutboundOrder.Where(d => d.create_by.Contains(User.UserName)).AsQueryable();
                setSearchState(true);
            }
            if (screatedate != null && screatedate.Trim() == "y")
            {
                vOutboundOrder = vOutboundOrder.Where(d => d.create_date >= startcreatedate.Date && d.create_date < endcreatedate.AddDays(1).Date).AsQueryable();
                setSearchState(true);
                Temp.lSearch.Add(screatedate);
                Temp.lSearch.Add(startcreatedate.Date.ToString());
                Temp.lSearch.Add(endcreatedate.Date.ToString());
            }
            else
            {
                Temp.lSearch.Add(null);
                Temp.lSearch.Add(null);
                Temp.lSearch.Add(null);
            }
            Temp.lSearch.Add(editby);
            if (editby != null)
            {
                var User = await _userManager.FindByIdAsync(editby.ToString());
                vOutboundOrder = vOutboundOrder.Where(d => d.edit_by.Contains(User.UserName)).AsQueryable();
                setSearchState(true);
            }
            if (seditdate != null && seditdate.Trim() == "y")
            {
                vOutboundOrder = vOutboundOrder.Where(d => d.edit_date >= starteditdate.Date && d.edit_date < endeditdate.AddDays(1).Date).AsQueryable();
                setSearchState(true);
                Temp.lSearch.Add(seditdate);
                Temp.lSearch.Add(starteditdate.Date.ToString());
                Temp.lSearch.Add(endeditdate.Date.ToString());
            }
            else
            {
                Temp.lSearch.Add(null);
                Temp.lSearch.Add(null);
                Temp.lSearch.Add(null);
            }
            if (cancelby != null)
            {
                var User = await _userManager.FindByIdAsync(cancelby.ToString());
                vOutboundOrder = vOutboundOrder.Where(d => d.cancel_by.Contains(User.UserName)).AsQueryable();
                setSearchState(true);
                Temp.lSearch.Add(cancelby.ToString());
            }
            else
            {
                Temp.lSearch.Add(null);
            }
            if (scanceldate != null && scanceldate.Trim() == "y")
            {
                vOutboundOrder = vOutboundOrder.Where(d => d.cancel_date >= startcanceldate.Date && d.cancel_date < endcanceldate.AddDays(1).Date).AsQueryable();
                setSearchState(true);
                Temp.lSearch.Add(scanceldate);
                Temp.lSearch.Add(startcanceldate.Date.ToString());
                Temp.lSearch.Add(endcanceldate.Date.ToString());
            }
            else
            {
                Temp.lSearch.Add(null);
                Temp.lSearch.Add(null);
                Temp.lSearch.Add(null);
            }
            Temp.lSearch.Add(cancelremark);
            if (cancelremark != null)
            {
                vOutboundOrder = vOutboundOrder.Where(d => d.cancel_remark.Contains(cancelremark)).AsQueryable();
                setSearchState(true);
            }
            if (Temp.bSearchState == false)
            {
                Temp.lSearch.Clear();
                Temp.iSearchCount = 0;
                ViewData["shipdatestate"] = "n";
                ViewData["createdatestate"] = "n";
                ViewData["editdatestate"] = "n";
                ViewData["canceldatestate"] = "n";
            }
            else
            {
                ViewData["status"] = Temp.lSearch[0];
                ViewData["ordernumber"] = Temp.lSearch[1];
                ViewData["ordertype"] = Temp.lSearch[2];

                if (Temp.lSearch[3] != null)
                {
                    ViewData["shipdatestate"] = "y";
                    ViewData["startshipdate"] = Convert.ToDateTime(Temp.lSearch[4]).Month.ToString() + "/" + Convert.ToDateTime(Temp.lSearch[4]).Day.ToString() + "/" + Convert.ToDateTime(Temp.lSearch[4]).Year.ToString();
                    ViewData["endshipdate"] = Convert.ToDateTime(Temp.lSearch[5]).Month.ToString() + "/" + Convert.ToDateTime(Temp.lSearch[5]).Day.ToString() + "/" + Convert.ToDateTime(Temp.lSearch[5]).Year.ToString();
                }
                else
                {
                    ViewData["shipdatestate"] = "n";
                }
                ViewData["invoiceno"] = Temp.lSearch[6];
                ViewData["customer"] = Temp.lSearch[7];
                ViewData["description"] = Temp.lSearch[8];
                ViewData["createby"] = Temp.lSearch[9];
                if (Temp.lSearch[10] != null)
                {
                    ViewData["createdatestate"] = "y";
                    ViewData["startcreatedate"] = Convert.ToDateTime(Temp.lSearch[11]).Month.ToString() + "/" + Convert.ToDateTime(Temp.lSearch[11]).Day.ToString() + "/" + Convert.ToDateTime(Temp.lSearch[11]).Year.ToString();
                    ViewData["endcreatedate"] = Convert.ToDateTime(Temp.lSearch[12]).Month.ToString() + "/" + Convert.ToDateTime(Temp.lSearch[12]).Day.ToString() + "/" + Convert.ToDateTime(Temp.lSearch[12]).Year.ToString();
                }
                else
                {
                    ViewData["createdatestate"] = "n";
                }
                ViewData["editby"] = Temp.lSearch[13];
                if (Temp.lSearch[14] != null)
                {
                    ViewData["editdatestate"] = "y";
                    ViewData["starteditdate"] = Convert.ToDateTime(Temp.lSearch[15]).Month.ToString() + "/" + Convert.ToDateTime(Temp.lSearch[15]).Day.ToString() + "/" + Convert.ToDateTime(Temp.lSearch[15]).Year.ToString();
                    ViewData["endeditdate"] = Convert.ToDateTime(Temp.lSearch[16]).Month.ToString() + "/" + Convert.ToDateTime(Temp.lSearch[16]).Day.ToString() + "/" + Convert.ToDateTime(Temp.lSearch[16]).Year.ToString();
                }
                else
                {
                    ViewData["editdatestate"] = "n";
                }
                ViewData["cancelby"] = Temp.lSearch[17];
                if (Temp.lSearch[18] != null)
                {
                    ViewData["canceldatestate"] = "y";
                    ViewData["startcanceldate"] = Convert.ToDateTime(Temp.lSearch[19]).Month.ToString() + "/" + Convert.ToDateTime(Temp.lSearch[19]).Day.ToString() + "/" + Convert.ToDateTime(Temp.lSearch[19]).Year.ToString();
                    ViewData["endcanceldate"] = Convert.ToDateTime(Temp.lSearch[20]).Month.ToString() + "/" + Convert.ToDateTime(Temp.lSearch[20]).Day.ToString() + "/" + Convert.ToDateTime(Temp.lSearch[20]).Year.ToString();
                }
                else
                {
                    ViewData["canceldatestate"] = "n";
                }
                ViewData["cancelremark"] = Temp.lSearch[21];
                Temp.iSearchCount += 1;
            }

            var tempData = SetPageNumber(vOutboundOrder.Count(), Temp.bSearchState, clear);
            vOutboundOrder = vOutboundOrder.Skip(tempData.SkipRec).Take(tempData.PerPage);

            var vOrderType = _context.OrderType.Where(x => x.type.Contains("O") || x.type.Contains("IO")).Select(s => new { Id = (int?)s.Id, Type = s.order_type }).ToList();
            vOrderType.Insert(0, new
            {
                Id = new Nullable<int>(),
                Type = "Select"
            });

            var vCustomer = _context.Customer.Where(x => x.active == true).OrderBy(x => x.customer_name).Select(s => new { Id = s.Id.ToString(), Name = s.customer_code + ": " + s.customer_name }).ToList();
            vCustomer.Insert(0, new
            {
                Id = string.Empty,
                Name = "Select"
            });

            var vUser = _context.Users.OrderBy(x => x.UserName).Select(s => new { Id = s.Id.ToString(), Username = s.UserName }).ToList();
            vUser.Insert(0, new
            {
                Id = String.Empty,
                Username = "Select"
            });

            ViewData["Header"] = lHeader;
            ViewData["OrderTypeList"] = new SelectList(vOrderType, "Id", "Type");
            ViewData["CustomerList"] = new SelectList(vCustomer, "Id", "Name");
            ViewData["UserList"] = new SelectList(vUser, "Id", "Username");
            ViewBag.btn_edit = "Y";
            ViewBag.btn_del = "Y";
            ViewBag.Mode = "outbound";
            return View(await vOutboundOrder.ToListAsync());
        }

        public IActionResult ViewResource(Guid id)
        {
            var tempData = SetPageNumberItem(id);
            var outboundItem = (from S in _context.OutboundItem.Include(e => e.OutboundOrder).Include(e => e.ItemReceivedState).Include(e => e.Item).Include("Item.ItemCategory").Where(e => e.OutboundOrderId == id)
                                orderby S.create_date ascending
                                select S).Skip(tempData.SkipRecItm).Take(tempData.PerPageItm);

            string[] lHeaderItem = { "Item Name", "Item Type", "State", "Cost", "Quantity Order", "Create By", "Create Date", "Edit By", "Edit Date" };
            ViewData["HeaderSubMenu"] = lHeaderItem;
            ViewData["OutboundItem"] = outboundItem;
            ViewBag.btn_receive = "N";
            ViewBag.btn_store = "N";
            return View();
        }

        private void setSearchState(bool state)
        {
            Temp.bSearchState = state;
        }

        private ManagePageNumber SetPageNumber(int? total, bool searchState, string sClear)
        {
            ManagePageNumber temp = new ManagePageNumber
            {
                PerPage = HttpContext.Session.GetInt32("OOPerPage") ?? 20
            };
            if (searchState == true)
            {
                if (Temp.iSearchCount == 1)
                {
                    HttpContext.Session.SetInt32("OOPageNo", 1);
                    temp.PageNo = 1;
                }
                else
                {
                    temp.PageNo = HttpContext.Session.GetInt32("OOPageNo") ?? 1;
                }
                temp.TotalRec = (int)total;
            }
            else
            {
                if (sClear != null)
                {
                    HttpContext.Session.SetInt32("OOPageNo", 1);
                    temp.PageNo = 1;
                }
                else
                {
                    temp.PageNo = HttpContext.Session.GetInt32("OOPageNo") ?? 1;
                }
                temp.TotalRec = _context.OutboundOrder.Count();
            }


            temp.MaxPage = (int)Math.Ceiling((double)temp.TotalRec / (double)temp.PerPage);
            if (temp.MaxPage == 0)
                temp.MaxPage = 1;

            if ((temp.PageNo == 0) || (temp.PageNo > temp.MaxPage))
            {
                temp.PageNo = temp.MaxPage;
            }

            temp.SkipRec = (temp.PerPage * (temp.PageNo - 1));
            if (temp.TotalRec != 0)
            {
                temp.FirstRec = temp.SkipRec + 1;
            }
            else
            {
                temp.FirstRec = 0;
            }

            temp.LastRec = temp.FirstRec + temp.PerPage - 1 > temp.TotalRec ? temp.TotalRec : temp.FirstRec + temp.PerPage - 1;

            ViewData["PerPage"] = temp.PerPage;
            ViewData["FirstRec"] = temp.FirstRec;
            ViewData["LastRec"] = temp.LastRec;
            ViewData["PageNo"] = temp.PageNo;
            ViewData["MaxPage"] = temp.MaxPage;
            ViewData["TotalRec"] = temp.TotalRec;

            return temp;
        }

        public IActionResult SetPerPage(int PerPage)
        {
            var vPage = PerPage switch
            {
                0 => 20,
                1 => 50,
                2 => 100,
                3 => 500,
                4 => 1000,
                _ => 100,
            };

            HttpContext.Session.SetInt32("OOPerPage", vPage);

            if (Temp.bSearchState == false)
            {
                return RedirectToAction(nameof(ViewContent));
            }
            else
            {
                int? iOrderType = null;
                if (Temp.lSearch[2] != null)
                {
                    iOrderType = int.Parse(Temp.lSearch[2]);
                }
                string sCustomer = Guid.Empty.ToString();
                if (Temp.lSearch[7] != null)
                {
                    sCustomer = Temp.lSearch[7];
                }

                return RedirectToAction("ViewContent", new { status = Temp.lSearch[0], ordernumber = Temp.lSearch[1], ordertype = iOrderType, sshipdate = Temp.lSearch[3], startshipdate = Convert.ToDateTime(Temp.lSearch[4]), endshipdate = Convert.ToDateTime(Temp.lSearch[5]), invoiceno = Temp.lSearch[6], customer = sCustomer, description = Temp.lSearch[8], createby = Temp.lSearch[9], screatedate = Temp.lSearch[10], startcreatedate = Convert.ToDateTime(Temp.lSearch[11]), endcreatedate = Convert.ToDateTime(Temp.lSearch[12]), editby = Temp.lSearch[13], seditdate = Temp.lSearch[14], starteditdate = Convert.ToDateTime(Temp.lSearch[15]), endeditdate = Convert.ToDateTime(Temp.lSearch[16]), cancelby = Temp.lSearch[17], scanceldate = Temp.lSearch[18], startcanceldate = Convert.ToDateTime(Temp.lSearch[19]), endcanceldate = Convert.ToDateTime(Temp.lSearch[20]), cancelremark = Temp.lSearch[21] });
            }
        }

        public IActionResult SetPageNo(string PageNo)
        {
            var vPageNo = PageNo switch
            {
                "First" => 1,
                "Last" => 0,
                _ => Convert.ToInt32(PageNo),
            };
            HttpContext.Session.SetInt32("OOPageNo", vPageNo);
            if (Temp.bSearchState == false)
            {
                return RedirectToAction(nameof(ViewContent));
            }
            else
            {
                int? iOrderType = null;
                if (Temp.lSearch[2] != null)
                {
                    iOrderType = int.Parse(Temp.lSearch[2]);
                }
                string sCustomer = Guid.Empty.ToString();
                if (Temp.lSearch[7] != null)
                {
                    sCustomer = Temp.lSearch[7];
                }

                return RedirectToAction("ViewContent", new { status = Temp.lSearch[0], ordernumber = Temp.lSearch[1], ordertype = iOrderType, sshipdate = Temp.lSearch[3], startshipdate = Convert.ToDateTime(Temp.lSearch[4]), endshipdate = Convert.ToDateTime(Temp.lSearch[5]), invoiceno = Temp.lSearch[6], customer = sCustomer, description = Temp.lSearch[8], createby = Temp.lSearch[9], screatedate = Temp.lSearch[10], startcreatedate = Convert.ToDateTime(Temp.lSearch[11]), endcreatedate = Convert.ToDateTime(Temp.lSearch[12]), editby = Temp.lSearch[13], seditdate = Temp.lSearch[14], starteditdate = Convert.ToDateTime(Temp.lSearch[15]), endeditdate = Convert.ToDateTime(Temp.lSearch[16]), cancelby = Temp.lSearch[17], scanceldate = Temp.lSearch[18], startcanceldate = Convert.ToDateTime(Temp.lSearch[19]), endcanceldate = Convert.ToDateTime(Temp.lSearch[20]), cancelremark = Temp.lSearch[21] });
            }
        }

        private ManagePageNumber SetPageNumberItem(Guid id)
        {
            ManagePageNumber temp = new ManagePageNumber
            {
                PerPageItm = HttpContext.Session.GetInt32("OOIPerPage") ?? 20,
                PageNoItm = HttpContext.Session.GetInt32("OOIPageNo") ?? 1,
                TotalRecItm = _context.OutboundItem.Where(x => x.OutboundOrderId == id).Count()
            };
            temp.MaxPageItm = (int)Math.Ceiling((double)temp.TotalRecItm / (double)temp.PerPageItm);
            if (temp.MaxPageItm == 0)
                temp.MaxPageItm = 1;

            if ((temp.PageNoItm == 0) || (temp.PageNoItm > temp.MaxPageItm))
            {
                temp.PageNoItm = temp.MaxPageItm;
            }

            temp.SkipRecItm = (temp.PerPageItm * (temp.PageNoItm - 1));
            if (temp.TotalRecItm != 0)
            {
                temp.FirstRecItm = temp.SkipRecItm + 1;
            }
            else
            {
                temp.FirstRecItm = 0;
            }

            temp.LastRecItm = temp.FirstRecItm + temp.PerPageItm - 1 > temp.TotalRecItm ? temp.TotalRecItm : temp.FirstRecItm + temp.PerPageItm - 1;

            ViewData["PerPageItm"] = temp.PerPageItm;
            ViewData["FirstRecItm"] = temp.FirstRecItm;
            ViewData["LastRecItm"] = temp.LastRecItm;
            ViewData["PageNoItm"] = temp.PageNoItm;
            ViewData["MaxPageItm"] = temp.MaxPageItm;
            ViewData["TotalRecItm"] = temp.TotalRecItm;

            return temp;
        }

        public IActionResult SetPerPageItem(int PerPage, Guid Id)
        {
            var vPage = PerPage switch
            {
                0 => 20,
                1 => 50,
                2 => 100,
                3 => 500,
                4 => 1000,
                _ => 100,
            };

            HttpContext.Session.SetInt32("OOIPerPage", vPage);
            return RedirectToAction("ViewResource", new { id = Id });
        }

        public IActionResult SetPageNoItem(string PageNo, Guid Id)
        {
            var vPageNo = PageNo switch
            {
                "First" => 1,
                "Last" => 0,
                _ => Convert.ToInt32(PageNo),
            };
            HttpContext.Session.SetInt32("OOIPageNo", vPageNo);
            return RedirectToAction("ViewResource", new { id = Id });
        }

        [AcceptVerbs("GET", "POST")]
        public async Task<IActionResult> checkOrderNo(string order_no)
        {

            var fOO = await _context.OutboundOrder.FirstOrDefaultAsync(m => m.order_no == order_no);
            if (fOO != null)
            {
                return Json(false);
            }
            else
            {
                return Json(true);
            }
        }

        private bool ItemExists(Guid id)
        {
            return _context.OutboundItem.Any(e => e.Id == id);
        }

        private bool OutboundOrderExists(Guid id)
        {
            return _context.OutboundOrder.Any(e => e.Id == id);
        }

        public async Task<IActionResult> ValidPassword(string Username, string Password)
        {
            bool result = false;
            var user = await _userManager.FindByNameAsync(Username);
            if (user != null)
            {
                var rolesForUser = await _userManager.GetRolesAsync(user);
                if (rolesForUser[0].ToString().Trim() == "Admin")
                {
                    var valid = await _signInManager.UserManager.CheckPasswordAsync(user, Password.Trim());
                    if (valid == true)
                    {
                        result = true;
                    }
                }
            }
            return Json(new { result });
        }

        public IActionResult getOrderNumber()
        {
            string sDate = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString();
            if (DateTime.Now.Day.ToString().Trim().Length == 1)
            {
                sDate = sDate + "0" + DateTime.Now.Day.ToString();
            }
            else
            {
                sDate = sDate + DateTime.Now.Day.ToString();
            }
            var vOO = _context.OutboundOrder.Where(x => x.order_no.Contains(sDate)).OrderByDescending(x => x.order_no).FirstOrDefault();
            if (vOO != null)
            {
                int iOrderNumber = int.Parse(vOO.order_no[^4..]) + 1;
                string sOutput = string.Empty;
                for (int i = 1; i <= (4 - iOrderNumber.ToString().Length); i++)
                {
                    sOutput += "0";
                }
                sOutput += iOrderNumber.ToString();
                return Json("E" + sDate + sOutput);
            }
            else
            {
                return Json("E" + sDate + "0001");
            }
        }

        [AcceptVerbs("GET", "POST")]
        public JsonResult CheckStatusDeleteOrder(Guid id)
        {
            var vOutboundOrder = _context.OutboundOrder.Include(x => x.StatusOutboundOrder).Where(x => x.Id == id).FirstOrDefault();
            bool result = true;
            string order_no = string.Empty;
            if (vOutboundOrder.StatusOutboundOrder.status != "" && vOutboundOrder.StatusOutboundOrder.status != "open")
            {
                result = false;
                order_no = vOutboundOrder.order_no;
            }

            return Json(new { result, order_no });
        }

        [AcceptVerbs("GET", "POST")]
        public async Task<JsonResult> CheckQuantity(Guid Id, Guid ItemId, int qty)
        {
            if (qty == 0)
            {
                return Json($"Quantity must be more than zero.");
            }
            else
            {
                if(ItemId != Guid.Empty)
                {
                    var item = await (from a in _context.Inventory
                                join b in _context.ItemReceived
                                on a.ItemReceivedId equals b.Id
                                join c in _context.InboundItem
                                on b.InboundItemId equals c.Id
                                join d in _context.InboundOrder
                                on c.InboundOrderId equals d.Id
                                join e in _context.Item
                                on c.ItemId equals e.Id
                                join f in _context.ItemCategory
                                on e.ItemCategoryId equals f.Id
                                join g in _context.Location
                                on a.LocationId equals g.Id
                                join h in _context.LocationCategory
                                on g.LocationCategoryId equals h.Id
                                where (c.ItemId == ItemId)
                                select new InventoryDetailViewModel
                                {
                                    id              = a.Id,
                                    orderNo         = d.order_no,
                                    lotNo           = b.lot_no,
                                    itemCode        = e.item_code,
                                    itemName        = e.item_name,
                                    itemCategory    = f.category_name,
                                    cost            = b.cost,
                                    unit            = a.qty,
                                    receiveDate     = b.receive_date,
                                    locationCode    = g.location_code,
                                    locationName    = h.category_name,
                                    status          = b.status,
                                    reserve         = a.reserve,
                                    outboundList    = a.user_define1,
                                    qtyList         = a.user_define2
                                }).OrderBy(x => x.receiveDate).ToListAsync();

                    var checkInventory = await _context.Inventory.Where(x => x.user_define1.Contains(Id.ToString().ToUpper())).FirstOrDefaultAsync();
                    if(checkInventory == null)
                    {
                        var sumItem = item.Sum(x => x.unit) - item.Sum(x => x.reserve);
                        if (qty <= sumItem)
                        {
                            return Json(true);
                        }
                        else
                        {
                            return Json($"limit {sumItem} items.");
                        }
                    }
                    else
                    {
                        int sumReserve = 0;
                        foreach(var element in item)
                        {
                            if(!string.IsNullOrWhiteSpace(element.outboundList))
                            {
                                if (element.outboundList.Contains(Id.ToString().ToUpper()))
                                {
                                    var subOutboundId = element.outboundList.Split(",");
                                    var subQty = element.qtyList.Split(",");

                                    var index = Array.IndexOf(subOutboundId, Id.ToString().ToUpper());

                                    sumReserve += Convert.ToInt32(subQty[index]);
                                }
                            }
                        }

                        var sumItem = item.Sum(x => x.unit) - item.Sum(x => x.reserve) + sumReserve;
                        if (qty <= sumItem)
                        {
                            return Json(true);
                        }
                        else
                        {
                            return Json($"limit {sumItem} items.");
                        }

                    }
                    
                }
                else
                {
                    return Json($"Please select a item first.");
                }
            }
        }
    }
}
