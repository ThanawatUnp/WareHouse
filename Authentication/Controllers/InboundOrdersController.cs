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
    [Authorize]
    public class InboundOrdersController : Controller
    {
        private readonly WMContext _context;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly string[] lHeader = { "Status", "Order Number", "Order Type", "Expect Date", "Supplier", "Customer", "Description", "Create By", "Create Date", "Edit By", "Edit Date", "Close By", "Close Date", "Close Remark" };

        public InboundOrdersController(WMContext context, RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _context = context;
            _roleManager = roleManager;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IActionResult> Index()
        {
            var tempData = SetPageNumber(null, false, null);
            var vInboundOrder = (from IO in _context.InboundOrder.Include(e => e.OrderType).Include(e => e.StatusInboundOrder).Include(e => e.Supplier).Include(e => e.Customer)
                                 orderby IO.create_date ascending
                                 select IO).Skip(tempData.SkipRec).Take(tempData.PerPage);

            var orderType = _context.OrderType.Where(x => x.type.Contains("I") || x.type.Contains("IO")).Select(s => new { Id = (int?)s.Id, Type = s.order_type }).ToList();
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

            var supplier = _context.Supplier.Where(x => x.active == true).OrderBy(x => x.supplier_name).Select(s => new { Id = s.Id.ToString(), Name = s.supplier_code + ": " + s.supplier_name }).ToList();
            supplier.Insert(0, new
            {
                Id = String.Empty,
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
            ViewData["SupplierList"] = new SelectList(supplier, "Id", "Name");
            ViewData["UserList"] = new SelectList(user, "Id", "Username");
            ViewBag.btn_edit = "Y";
            ViewBag.btn_del = "Y";
            ViewBag.Mode = "inbound";
            return View(await vInboundOrder.ToListAsync());
        }

        public IActionResult CreateInboundOrder()
        {
            var inboundOrder = new InboundOrder
            {
                Id = Guid.NewGuid()
            };
            var orderType = _context.OrderType.Where(x => x.type.Contains("I") || x.type.Contains("IO")).Select(s => new { Id = (int?)s.Id, Type = s.order_type }).ToList();
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

            var supplier = _context.Supplier.Where(x => x.active == true).OrderBy(x => x.supplier_name).Select(s => new { Id = s.Id.ToString(), Name = s.supplier_code + ": " + s.supplier_name }).ToList();
            supplier.Insert(0, new
            {
                Id = String.Empty,
                Name = "Select"
            });

            ViewData["OrderTypeList"] = new SelectList(orderType, "Id", "Type");
            ViewData["CustomerList"] = new SelectList(customer, "Id", "Name");
            ViewData["SupplierList"] = new SelectList(supplier, "Id", "Name");
            ViewData["Status"] = "Draft";
            return View(inboundOrder);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateInboundOrder([Bind("Id, order_no, OrderTypeId, CustomerId, SupplierId, expect_date, create_by, create_date, edit_by, edit_date, close_by, close_date, close_remark, StatusInboundOrderId")] InboundOrder inboundOrder, string txtDescription)
        {
            if (ModelState.IsValid) // Check binding success
            {
                var fIO = await _context.InboundOrder.FirstOrDefaultAsync(m => m.order_no == inboundOrder.order_no);
                if (fIO != null)
                {
                    return NotFound();
                }

                inboundOrder.create_date = DateTime.Now;
                inboundOrder.create_by = User.Identity.Name; //Program.username;
                inboundOrder.edit_date = null;

                StatusInboundOrder oSIO = new StatusInboundOrder();
                Guid oStatusId = Guid.NewGuid();
                oSIO.Id = oStatusId;
                oSIO.status = "open";
                oSIO.description = txtDescription;
                oSIO.create_date = DateTime.Now;
                oSIO.create_by = User.Identity.Name;
                oSIO.InboundOrderId = inboundOrder.Id;
                _context.Add(oSIO);
                await _context.SaveChangesAsync();

                inboundOrder.StatusInboundOrderId = oStatusId;
                _context.Add(inboundOrder);
                await _context.SaveChangesAsync();
                return RedirectToAction("EditInboundOrder", new { id = inboundOrder.Id });
            }

            return View(inboundOrder);
        }

        public IActionResult EditInboundOrder(Guid id)
        {
            if (id == Guid.Empty || id == null)
            {
                return NotFound();
            }

            var vInboundOrder = _context.InboundOrder.Include(x => x.StatusInboundOrder).Where(x => x.Id == id).FirstOrDefault();
            if (vInboundOrder == null)
            {
                return NotFound();
            }

            var orderType = _context.OrderType.Where(x => x.type.Contains("I") || x.type.Contains("IO")).Select(s => new { Id = (int?)s.Id, Type = s.order_type }).ToList();
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

            var supplier = _context.Supplier.Where(x => x.active == true).OrderBy(x => x.supplier_name).Select(s => new { Id = s.Id.ToString(), Name = s.supplier_code + ": " + s.supplier_name }).ToList();
            supplier.Insert(0, new
            {
                Id = String.Empty,
                Name = "Select"
            });

            var tempData = SetPageNumberItem(id);
            var inboundItem = (from S in _context.InboundItem.Include(e => e.InboundOrder).Include(e => e.Item).Include("Item.ItemCategory").Where(e => e.InboundOrderId == id)
                               orderby S.create_date ascending
                               select S).Skip(tempData.SkipRecItm).Take(tempData.PerPageItm);

            string[] lHeaderItem = { "Line Number", "Item Name", "Item Type", "Cost", "Quantity Order", "Remain Quantity", "Create By", "Create Date", "Edit By", "Edit Date" };

            ViewData["InboundItem"] = inboundItem;
            ViewData["OrderTypeList"] = new SelectList(orderType, "Id", "Type");
            ViewData["CustomerList"] = new SelectList(customer, "Id", "Name");
            ViewData["SupplierList"] = new SelectList(supplier, "Id", "Name");
            ViewData["Status"] = "Open";
            ViewData["Header"] = lHeader;
            ViewData["HeaderSubMenu"] = lHeaderItem;
            ViewBag.btn_receive = "Y";
            ViewBag.btn_store = "N";
            return View(vInboundOrder);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditInboundOrder(Guid id, [Bind("Id, order_no, OrderTypeId, CustomerId, SupplierId, expect_date, create_by, create_date, edit_by, edit_date, close_by, close_date, close_remark, StatusInboundOrderId")] InboundOrder inboundOrder, string txtDescription)
        {
            if (id != inboundOrder.Id)
            {
                return NotFound();
            }
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            if (ModelState.IsValid) // Check binding success
            {
                try
                {
                    var vStatus = await _context.StatusInboundOrder.FirstOrDefaultAsync(m => m.InboundOrderId == inboundOrder.Id);
                    vStatus.description = txtDescription;
                    _context.Update(vStatus);
                    await _context.SaveChangesAsync();

                    inboundOrder.edit_date = DateTime.Now;
                    inboundOrder.edit_by = User.Identity.Name;
                    _context.Update(inboundOrder);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("EditInboundOrder", new { id = inboundOrder.Id });
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InboundOrderExists(inboundOrder.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }

            return View(inboundOrder);
        }

        public IActionResult DeleteInboundOrder(Guid id)
        {
            if (id == Guid.Empty || id == null)
            {
                return NotFound();
            }

            var vInboundOrder = _context.InboundOrder.Include(x => x.StatusInboundOrder).Where(x => x.Id == id).FirstOrDefault();
            if (vInboundOrder == null)
            {
                return NotFound();
            }

            return View(vInboundOrder);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteInboundOrder(Guid id, [Bind("Id, order_no, OrderTypeId, CustomerId, SupplierId, expect_date, create_by, create_date, edit_by, edit_date, close_by, close_date, close_remark, StatusInboundOrderId")] InboundOrder inboundOrder)
        {
            if (id != inboundOrder.Id)
            {
                return NotFound();
            }
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            if (ModelState.IsValid) // Check binding success
            {
                try
                {
                    var vStatus = _context.StatusInboundOrder.Where(x => x.InboundOrderId == inboundOrder.Id);
                    var vInboundItem = _context.InboundItem.Where(x => x.InboundOrderId == inboundOrder.Id);

                    _context.StatusInboundOrder.RemoveRange(vStatus);
                    _context.InboundItem.RemoveRange(vInboundItem);
                    _context.InboundOrder.Remove(inboundOrder);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InboundOrderExists(inboundOrder.Id))
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
                    string sSupplier = Guid.Empty.ToString();
                    if (Temp.lSearch[6] != null)
                    {
                        sSupplier = Temp.lSearch[6];
                    }
                    string sCustomer = Guid.Empty.ToString();
                    if (Temp.lSearch[7] != null)
                    {
                        sCustomer = Temp.lSearch[7];
                    }

                    return RedirectToAction("ViewContent", new { status = Temp.lSearch[0], ordernumber = Temp.lSearch[1], ordertype = iOrderType, sexpectdate = Temp.lSearch[3], startexpectdate = Convert.ToDateTime(Temp.lSearch[4]), endexpectdate = Convert.ToDateTime(Temp.lSearch[5]), supplier = sSupplier, customer = sCustomer, description = Temp.lSearch[8], createby = Temp.lSearch[9], screatedate = Temp.lSearch[10], startcreatedate = Convert.ToDateTime(Temp.lSearch[11]), endcreatedate = Convert.ToDateTime(Temp.lSearch[12]), editby = Temp.lSearch[13], seditdate = Temp.lSearch[14], starteditdate = Convert.ToDateTime(Temp.lSearch[15]), endeditdate = Convert.ToDateTime(Temp.lSearch[16]), closeby = Temp.lSearch[17], sclosedate = Temp.lSearch[18], startclosedate = Convert.ToDateTime(Temp.lSearch[19]), endclosedate = Convert.ToDateTime(Temp.lSearch[20]), closeremark = Temp.lSearch[21] });
                }
            }

            return View(inboundOrder);
        }

        public IActionResult ConfirmDeleteOrder(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var vObject = _context.InboundOrder.Where(x => x.Id == Guid.Parse(id)).FirstOrDefault();
            if (vObject == null)
            {
                return NotFound();
            }

            return View(vObject);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmDeleteOrder(Guid id, [Bind("Id, order_no, OrderTypeId, CustomerId, SupplierId, expect_date, create_by, create_date, edit_by, edit_date, close_by, close_date, close_remark, StatusInboundOrderId")] InboundOrder inboundOrder, string ipPassword)
        {
            if (id != inboundOrder.Id)
            {
                return NotFound();
            }
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            if (ModelState.IsValid) // Check binding success
            {
                try
                {
                    var vStatus = _context.StatusInboundOrder.Where(x => x.InboundOrderId == inboundOrder.Id);
                    var vInboundItem = _context.InboundItem.Where(x => x.InboundOrderId == inboundOrder.Id);

                    _context.StatusInboundOrder.RemoveRange(vStatus);
                    _context.InboundItem.RemoveRange(vInboundItem);
                    _context.InboundOrder.Remove(inboundOrder);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InboundOrderExists(inboundOrder.Id))
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
                    string sSupplier = Guid.Empty.ToString();
                    if (Temp.lSearch[6] != null)
                    {
                        sSupplier = Temp.lSearch[6];
                    }
                    string sCustomer = Guid.Empty.ToString();
                    if (Temp.lSearch[7] != null)
                    {
                        sCustomer = Temp.lSearch[7];
                    }

                    return RedirectToAction("ViewContent", new { status = Temp.lSearch[0], ordernumber = Temp.lSearch[1], ordertype = iOrderType, sexpectdate = Temp.lSearch[3], startexpectdate = Convert.ToDateTime(Temp.lSearch[4]), endexpectdate = Convert.ToDateTime(Temp.lSearch[5]), supplier = sSupplier, customer = sCustomer, description = Temp.lSearch[8], createby = Temp.lSearch[9], screatedate = Temp.lSearch[10], startcreatedate = Convert.ToDateTime(Temp.lSearch[11]), endcreatedate = Convert.ToDateTime(Temp.lSearch[12]), editby = Temp.lSearch[13], seditdate = Temp.lSearch[14], starteditdate = Convert.ToDateTime(Temp.lSearch[15]), endeditdate = Convert.ToDateTime(Temp.lSearch[16]), closeby = Temp.lSearch[17], sclosedate = Temp.lSearch[18], startclosedate = Convert.ToDateTime(Temp.lSearch[19]), endclosedate = Convert.ToDateTime(Temp.lSearch[20]), closeremark = Temp.lSearch[21] });
                }
            }

            return View(inboundOrder);
        }

        public IActionResult CreateResource(String id)
        {
            var vInboundItem = _context.InboundItem.Where(x => x.InboundOrderId == Guid.Parse(id)).OrderByDescending(x => x.create_date).FirstOrDefault();
            string sOutput = string.Empty;
            if (vInboundItem != null)
            {
                int iCount = int.Parse(vInboundItem.line_no);
                for (int i = 1; i <= (5 - vInboundItem.line_no.Trim().Replace("0", "").Length); i++)
                {
                    sOutput += "0";
                }
                sOutput += (iCount + 1).ToString();
            }
            else
            {
                sOutput = "00001";
            }
            var inboundItem = new InboundItem
            {
                Id = Guid.NewGuid(),
                line_no = sOutput,
                InboundOrderId = Guid.Parse(id)
            };

            var vInboundOrder = _context.InboundOrder.Where(x => x.Id == Guid.Parse(id)).FirstOrDefault();
            var vItem = _context.Item.OrderBy(x => x.create_date).Select(s => new { Id = s.Id.ToString(), Item = s.item_code + ": " + s.item_name }).ToList();
            vItem.Insert(0, new
            {
                Id = string.Empty,
                Item = "Select"
            });

            ViewData["ItemList"] = new SelectList(vItem, "Id", "Item");
            ViewData["OrderNo"] = vInboundOrder.order_no;
            return View(inboundItem);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateResource([Bind("Id, line_no, cost, qty, remain_qty, create_by, create_date, edit_by, edit_date, InboundOrderId, ItemId")] InboundItem inboundItem)
        {
            if (ModelState.IsValid) // Check binding success
            {
                var vInboundOrder = _context.InboundOrder.Where(x => x.Id == inboundItem.InboundOrderId).FirstOrDefault();
                vInboundOrder.edit_by = User.Identity.Name;
                vInboundOrder.edit_date = DateTime.Now;
                _context.Update(vInboundOrder);
                await _context.SaveChangesAsync();

                inboundItem.remain_qty = (int)inboundItem.qty;
                inboundItem.create_date = DateTime.Now;
                inboundItem.create_by = User.Identity.Name; //Program.username;
                inboundItem.edit_date = null;
                _context.Add(inboundItem);
                await _context.SaveChangesAsync();
                return RedirectToAction("ViewResource", new { id = inboundItem.InboundOrderId });
            }

            return View(inboundItem);
        }

        public async Task<IActionResult> EditResource(Guid id)
        {
            if (id == Guid.Empty || id == null)
            {
                return NotFound();
            }

            var vInbounditem = await _context.InboundItem.FindAsync(id);
            if (vInbounditem == null)
            {
                return NotFound();
            }

            var vItem = _context.Item.Select(s => new { Id = s.Id.ToString(), Item = s.item_code + ": " + s.item_name }).ToList();
            vItem.Insert(0, new
            {
                Id = string.Empty,
                Item = "Select"
            });
            var vInboundOrder = _context.InboundOrder.Where(x => x.Id == vInbounditem.InboundOrderId).FirstOrDefault();

            ViewData["ItemList"] = new SelectList(vItem, "Id", "Item");
            ViewData["OrderNo"] = vInboundOrder.order_no;
            return View(vInbounditem);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditResource(Guid id, [Bind("Id, line_no, cost, qty, remain_qty, create_by, create_date, edit_by, edit_date, InboundOrderId, ItemId")] InboundItem inboundItem)
        {
            if (id != inboundItem.Id)
            {
                return NotFound();
            }
            var error = ModelState.Values.SelectMany(v => v.Errors);
            if (ModelState.IsValid)
            {
                try
                {
                    var vInboundOrder = _context.InboundOrder.Where(x => x.Id == inboundItem.InboundOrderId).FirstOrDefault();
                    vInboundOrder.edit_by = User.Identity.Name;
                    vInboundOrder.edit_date = DateTime.Now;
                    _context.Update(vInboundOrder);
                    await _context.SaveChangesAsync();

                    inboundItem.remain_qty = (int)inboundItem.qty;
                    inboundItem.edit_date = DateTime.Now;
                    inboundItem.edit_by = User.Identity.Name;
                    _context.Update(inboundItem);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("ViewResource", new { id = inboundItem.InboundOrderId });
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItemExists(inboundItem.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return View(inboundItem);
        }

        public async Task<IActionResult> DeleteResource(Guid id)
        {
            if (id == Guid.Empty || id == null)
            {
                return NotFound();
            }

            var vInbounditem = await _context.InboundItem.Include(e => e.Item).Where(x => x.Id == id).FirstOrDefaultAsync();
            if (vInbounditem == null)
            {
                return NotFound();
            }

            return View(vInbounditem);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteResource(Guid id, [Bind("Id, line_no, cost, qty, remain_qty, create_by, create_date, edit_by, edit_date, InboundOrderId, ItemId")] InboundItem inboundItem)
        {
            if (id != inboundItem.Id)
            {
                return NotFound();
            }
            var error = ModelState.Values.SelectMany(v => v.Errors);
            if (ModelState.IsValid)
            {
                try
                {
                    var vItem = await _context.InboundItem.FindAsync(inboundItem.Id);
                    _context.InboundItem.Remove(vItem);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("ViewResource", new { id = inboundItem.InboundOrderId });
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItemExists(inboundItem.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return View(inboundItem);
        }

        public IActionResult ConfirmDeleteResource(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var vObject = _context.InboundItem.Where(x => x.Id == Guid.Parse(id)).FirstOrDefault();
            if (vObject == null)
            {
                return NotFound();
            }

            return View(vObject);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmDeleteResource(Guid id, [Bind("Id, line_no, cost, qty, remain_qty, create_by, create_date, edit_by, edit_date, InboundOrderId, ItemId")] InboundItem inboundItem)
        {
            if (id != inboundItem.Id)
            {
                return NotFound();
            }
            var error = ModelState.Values.SelectMany(v => v.Errors);
            if (ModelState.IsValid)
            {
                try
                {
                    var vItem = await _context.InboundItem.FindAsync(inboundItem.Id);
                    _context.InboundItem.Remove(vItem);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("ViewResource", new { id = inboundItem.InboundOrderId });
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItemExists(inboundItem.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return View(inboundItem);
        }

        public async Task<IActionResult> ReceiveItem(Guid id)
        {
            if (id == Guid.Empty || id == null)
            {
                return NotFound();
            }

            var vInbounditem = await _context.InboundItem.Include(x => x.Item).Include("Item.QueueType").FirstOrDefaultAsync(x => x.Id == id);
            if (vInbounditem == null)
            {
                return NotFound();
            }

            var vInboundOrder = _context.InboundOrder.Where(x => x.Id == vInbounditem.InboundOrderId).FirstOrDefault();

            var vItemState = _context.ItemReceivedState.OrderBy(x => x.state).Select(s => new { Id = s.Id.ToString(), State = s.state }).ToList();
            vItemState.Insert(0, new
            {
                Id = string.Empty,
                State = "Select"
            });

            var vItemReceive = new ItemReceived
            {
                Id = Guid.NewGuid()
            };

            var tempData = SetPageNumberReceive(id);
            var oItemReceive = (from S in _context.ItemReceived.Include(e => e.InboundItem).Include(e => e.ItemReceivedState).Include("InboundItem.InboundOrder").Include("InboundItem.Item").Include("InboundItem.Item.ItemCategory").Where(e => e.InboundItemId == id)
                                orderby S.create_date ascending
                                select S).Skip(tempData.SkipRecSubItm).Take(tempData.PerPageSubItm);

            string[] lHeaderReceive = { "Order Number", "Item Detail", "State", "Receive Quantity", "Cost", "Lot Number", "Expire Date", "Receive Date", "Description", "Create By", "Create Date", "Edit By", "Edit Date" };

            ViewData["ItemStateList"] = new SelectList(vItemState, "Id", "State");
            ViewData["InboundItemId"] = id;
            ViewData["OrderNo"] = vInboundOrder.order_no;
            ViewData["ItemDetail"] = vInbounditem.Item.item_code + ": " + vInbounditem.Item.item_name;
            ViewData["RemainQty"] = vInbounditem.remain_qty;
            ViewData["HeaderReceive"] = lHeaderReceive;
            ViewData["ItemReceived"] = oItemReceive;
            ViewData["Queue"] = vInbounditem.Item.QueueType.category.Trim();
            return View(vItemReceive);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ReceiveItem(Guid id, [Bind("Id, cost, receive_qty, lot_no, expire_date, receive_date, description, create_by, create_date, edit_by, edit_date, InboundItemId, ItemReceivedStateId")] ItemReceived itemReceive)
        {
            if (ModelState.IsValid) // Check binding success
            {
                try
                {
                    var vInboundItem = _context.InboundItem.Where(x => x.Id == itemReceive.InboundItemId).FirstOrDefault();
                    vInboundItem.remain_qty -= itemReceive.receive_qty;
                    _context.Update(vInboundItem);
                    await _context.SaveChangesAsync();

                    itemReceive.remain_putaway = itemReceive.receive_qty;
                    itemReceive.status = "wait";
                    itemReceive.create_date = DateTime.Now;
                    itemReceive.create_by = User.Identity.Name; //Program.username;
                    itemReceive.edit_date = null;
                    itemReceive.receive_date = DateTime.Now;

                    _context.Add(itemReceive);
                    await _context.SaveChangesAsync();

                    var vInboundOrder = _context.InboundOrder.Where(x => x.Id == vInboundItem.InboundOrderId).FirstOrDefault();
                    var vStatus = _context.StatusInboundOrder.Where(x => x.Id == vInboundOrder.StatusInboundOrderId).FirstOrDefault();
                    if (vStatus.status.Trim() != "receiving")
                    {
                        vStatus.status = "receiving";
                    }
                    else
                    {
                        Boolean bReplaceReceived = CheckReplaceReceived(vInboundItem.InboundOrderId);
                        if (bReplaceReceived == true)
                        {
                            vStatus.status = "received";
                        }
                    }

                    _context.Update(vStatus);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("EditInboundOrder", new { id = vInboundItem.InboundOrderId });
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItemReceivedExists(itemReceive.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }   
            }

            return View(itemReceive);
        }

        public async Task<IActionResult> EditReceived(Guid id)
        {
            if (id == Guid.Empty || id == null)
            {
                return NotFound();
            }

            var vItemReceive = await _context.ItemReceived.Include(x => x.InboundItem).Include(x => x.ItemReceivedState).FirstOrDefaultAsync(x => x.Id == id);
            if (vItemReceive == null)
            {
                return NotFound();
            }

            var vInbounditem = await _context.InboundItem.Include(x => x.Item).Include("Item.QueueType").FirstOrDefaultAsync(x => x.Id == vItemReceive.InboundItemId);

            var vInboundOrder = await _context.InboundOrder.FirstOrDefaultAsync(x => x.Id == vInbounditem.InboundOrderId);

            var vItemState = _context.ItemReceivedState.OrderBy(x => x.state).Select(s => new { Id = s.Id.ToString(), State = s.state }).ToList();
            vItemState.Insert(0, new
            {
                Id = string.Empty,
                State = "Select"
            });

            ViewData["ItemStateList"] = new SelectList(vItemState, "Id", "State");
            ViewData["InboundItemId"] = vInbounditem.Id;
            ViewData["OrderNo"] = vInboundOrder.order_no;
            ViewData["ItemDetail"] = vInbounditem.Item.item_code + ": " + vInbounditem.Item.item_name;
            ViewData["OriginRemainQty"] = vInbounditem.remain_qty + vItemReceive.receive_qty;
            ViewData["RemainQty"] = vInbounditem.remain_qty;
            ViewData["Queue"] = vInbounditem.Item.QueueType.category.Trim();
            return View(vItemReceive);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditReceived(Guid id, string ipEdtTmpRemainQty, [Bind("Id, cost, receive_qty, lot_no, expire_date, receive_date, description, create_by, create_date, edit_by, edit_date, InboundItemId, ItemReceivedStateId")] ItemReceived itemReceive)
        {
            if (id != itemReceive.Id)
            {
                return NotFound();
            }
            var error = ModelState.Values.SelectMany(v => v.Errors);
            if (ModelState.IsValid) // Check binding success
            {
                try
                {
                    var vRemain_Qty = int.Parse(ipEdtTmpRemainQty);
                    var vInboundItem = _context.InboundItem.Where(x => x.Id == itemReceive.InboundItemId).FirstOrDefault();
                    vInboundItem.remain_qty = vRemain_Qty - itemReceive.receive_qty;
                    _context.Update(vInboundItem);
                    await _context.SaveChangesAsync();

                    itemReceive.status = "wait";
                    itemReceive.remain_putaway = itemReceive.receive_qty;
                    itemReceive.edit_by = User.Identity.Name;
                    itemReceive.edit_date = DateTime.Now;
                    _context.Update(itemReceive);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("ViewSubResource", new { id = itemReceive.InboundItemId });
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItemReceivedExists(itemReceive.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }

            return View(itemReceive);
        }

        public async Task<IActionResult> DeleteReceived(Guid id)
        {
            if (id == Guid.Empty || id == null)
            {
                return NotFound();
            }

            var vItemReceive = await _context.ItemReceived.Include(x => x.InboundItem).Include("InboundItem.Item").Include("InboundItem.Item.ItemCategory").Include(x => x.ItemReceivedState).FirstOrDefaultAsync(x => x.Id == id);
            if (vItemReceive == null)
            {
                return NotFound();
            }

            var vInbounditem = await _context.InboundItem.FirstOrDefaultAsync(x => x.Id == vItemReceive.InboundItemId);
            ViewData["RemainQty"] = vInbounditem.remain_qty;
            ViewData["OriginRemainQty"] = vInbounditem.remain_qty + vItemReceive.receive_qty;
            return View(vItemReceive);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteReceived(Guid id, string ipDltTmpRemainQty, [Bind("Id, cost, receive_qty, lot_no, expire_date, receive_date, description, create_by, create_date, edit_by, edit_date, InboundItemId, ItemReceivedStateId")] ItemReceived itemReceive)
        {
            if (id != itemReceive.Id)
            {
                return NotFound();
            }
            var error = ModelState.Values.SelectMany(v => v.Errors);
            if (ModelState.IsValid) // Check binding success
            {
                try
                {
                    var vRemain_Qty = int.Parse(ipDltTmpRemainQty);
                    var vInboundItem = _context.InboundItem.Where(x => x.Id == itemReceive.InboundItemId).FirstOrDefault();
                    vInboundItem.remain_qty = vRemain_Qty;
                    _context.Update(vInboundItem);
                    await _context.SaveChangesAsync();

                    Guid guidInboundItem = itemReceive.InboundItemId;
                    _context.ItemReceived.Remove(itemReceive);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("ViewSubResource", new { id = guidInboundItem });
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItemReceivedExists(itemReceive.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }

            return View(itemReceive);
        }

        public async Task<IActionResult> ViewContent(string status, string ordernumber, int? ordertype, string sexpectdate, DateTime startexpectdate, DateTime endexpectdate, string supplier, string customer, string description, string createby, string screatedate, DateTime startcreatedate, DateTime endcreatedate, string editby, string seditdate, DateTime starteditdate, DateTime endeditdate, string closeby, string sclosedate, DateTime startclosedate, DateTime endclosedate, string closeremark, string clear)
        {
            IQueryable<InboundOrder> vInboundOrder = (from d in _context.InboundOrder.Include(e => e.OrderType).Include(e => e.StatusInboundOrder).Include(e => e.Supplier).Include(e => e.Customer)
                                                      orderby d.create_date ascending
                                                      select d);
            setSearchState(false);
            Temp.lSearch.Clear();
            Temp.lSearch.Add(status);
            Temp.lSearch.Add(ordernumber);
            if (status != null)
            {
                vInboundOrder = vInboundOrder.Where(d => d.StatusInboundOrder.status.Contains(status)).AsQueryable();
                setSearchState(true);
            }
            if (ordernumber != null)
            {
                vInboundOrder = vInboundOrder.Where(d => d.order_no.Contains(ordernumber)).AsQueryable();
                setSearchState(true);
            }
            if (ordertype != null)
            {
                vInboundOrder = vInboundOrder.Where(d => d.OrderTypeId == ordertype).AsQueryable();
                setSearchState(true);
                Temp.lSearch.Add(ordertype.ToString());
            }
            else
            {
                Temp.lSearch.Add(null);
            }
            if (sexpectdate != null && sexpectdate.Trim() == "y")
            {
                vInboundOrder = vInboundOrder.Where(d => d.expect_date >= startexpectdate.Date && d.expect_date < endexpectdate.AddDays(1).Date).AsQueryable();
                setSearchState(true);
                Temp.lSearch.Add(sexpectdate);
                Temp.lSearch.Add(startexpectdate.Date.ToString());
                Temp.lSearch.Add(endexpectdate.Date.ToString());
            }
            else
            {
                Temp.lSearch.Add(null);
                Temp.lSearch.Add(null);
                Temp.lSearch.Add(null);
            }
            if (supplier != null && Guid.Parse(supplier) != Guid.Empty)
            {
                vInboundOrder = vInboundOrder.Where(d => d.SupplierId == Guid.Parse(supplier)).AsQueryable();
                setSearchState(true);
                Temp.lSearch.Add(supplier.ToString());
            }
            else
            {
                Temp.lSearch.Add(null);
            }
            if (customer != null && Guid.Parse(customer) != Guid.Empty)
            {
                vInboundOrder = vInboundOrder.Where(d => d.CustomerId == Guid.Parse(customer)).AsQueryable();
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
                vInboundOrder = vInboundOrder.Where(d => d.StatusInboundOrder.description.Contains(description)).AsQueryable();
                setSearchState(true);
            }
            Temp.lSearch.Add(createby);
            if (createby != null)
            {
                var User = await _userManager.FindByIdAsync(createby.ToString());
                vInboundOrder = vInboundOrder.Where(d => d.create_by.Contains(User.UserName)).AsQueryable();
                setSearchState(true);
            }
            if (screatedate != null && screatedate.Trim() == "y")
            {
                vInboundOrder = vInboundOrder.Where(d => d.create_date >= startcreatedate.Date && d.create_date < endcreatedate.AddDays(1).Date).AsQueryable();
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
                vInboundOrder = vInboundOrder.Where(d => d.edit_by.Contains(User.UserName)).AsQueryable();
                setSearchState(true);
            }
            if (seditdate != null && seditdate.Trim() == "y")
            {
                vInboundOrder = vInboundOrder.Where(d => d.edit_date >= starteditdate.Date && d.edit_date < endeditdate.AddDays(1).Date).AsQueryable();
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
            if (closeby != null)
            {
                var User = await _userManager.FindByIdAsync(closeby.ToString());
                vInboundOrder = vInboundOrder.Where(d => d.close_by.Contains(User.UserName)).AsQueryable();
                setSearchState(true);
                Temp.lSearch.Add(closeby.ToString());
            }
            else
            {
                Temp.lSearch.Add(null);
            }
            if (sclosedate != null && sclosedate.Trim() == "y")
            {
                vInboundOrder = vInboundOrder.Where(d => d.close_date >= startclosedate.Date && d.close_date < endclosedate.AddDays(1).Date).AsQueryable();
                setSearchState(true);
                Temp.lSearch.Add(sclosedate);
                Temp.lSearch.Add(startclosedate.Date.ToString());
                Temp.lSearch.Add(endclosedate.Date.ToString());
            }
            else
            {
                Temp.lSearch.Add(null);
                Temp.lSearch.Add(null);
                Temp.lSearch.Add(null);
            }
            Temp.lSearch.Add(closeremark);
            if (closeremark != null)
            {
                vInboundOrder = vInboundOrder.Where(d => d.close_remark.Contains(closeremark)).AsQueryable();
                setSearchState(true);
            }
            if (Temp.bSearchState == false)
            {
                Temp.lSearch.Clear();
                Temp.iSearchCount = 0;
                ViewData["expectdatestate"] = "n";
                ViewData["createdatestate"] = "n";
                ViewData["editdatestate"] = "n";
                ViewData["closedatestate"] = "n";
            }
            else
            {
                ViewData["status"] = Temp.lSearch[0];
                ViewData["ordernumber"] = Temp.lSearch[1];
                ViewData["ordertype"] = Temp.lSearch[2];
                if (Temp.lSearch[3] != null)
                {
                    ViewData["expectdatestate"] = "y";
                    ViewData["startexpectdate"] = Convert.ToDateTime(Temp.lSearch[4]).Month.ToString() + "/" + Convert.ToDateTime(Temp.lSearch[4]).Day.ToString() + "/" + Convert.ToDateTime(Temp.lSearch[4]).Year.ToString();
                    ViewData["endexpectdate"] = Convert.ToDateTime(Temp.lSearch[5]).Month.ToString() + "/" + Convert.ToDateTime(Temp.lSearch[5]).Day.ToString() + "/" + Convert.ToDateTime(Temp.lSearch[5]).Year.ToString();
                }
                else
                {
                    ViewData["expectdatestate"] = "n";
                }
                ViewData["supplier"] = Temp.lSearch[6];
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
                ViewData["closeby"] = Temp.lSearch[17];
                if (Temp.lSearch[18] != null)
                {
                    ViewData["closedatestate"] = "y";
                    ViewData["startclosedate"] = Convert.ToDateTime(Temp.lSearch[19]).Month.ToString() + "/" + Convert.ToDateTime(Temp.lSearch[19]).Day.ToString() + "/" + Convert.ToDateTime(Temp.lSearch[19]).Year.ToString();
                    ViewData["endclosedate"] = Convert.ToDateTime(Temp.lSearch[20]).Month.ToString() + "/" + Convert.ToDateTime(Temp.lSearch[20]).Day.ToString() + "/" + Convert.ToDateTime(Temp.lSearch[20]).Year.ToString();
                }
                else
                {
                    ViewData["closedatestate"] = "n";
                }
                ViewData["closeremark"] = Temp.lSearch[21];
                Temp.iSearchCount += 1;
            }

            var tempData = SetPageNumber(vInboundOrder.Count(), Temp.bSearchState, clear);
            vInboundOrder = vInboundOrder.Skip(tempData.SkipRec).Take(tempData.PerPage);


            var vOrderType = _context.OrderType.Where(x => x.type.Contains("I") || x.type.Contains("IO")).Select(s => new { Id = (int?)s.Id, Type = s.order_type }).ToList();
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

            var vSupplier = _context.Supplier.Where(x => x.active == true).OrderBy(x => x.supplier_name).Select(s => new { Id = s.Id.ToString(), Name = s.supplier_code + ": " + s.supplier_name }).ToList();
            vSupplier.Insert(0, new
            {
                Id = String.Empty,
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
            ViewData["SupplierList"] = new SelectList(vSupplier, "Id", "Name");
            ViewData["UserList"] = new SelectList(vUser, "Id", "Username");
            ViewBag.btn_edit = "Y";
            ViewBag.btn_del = "Y";
            ViewBag.Mode = "inbound";
            return View(await vInboundOrder.ToListAsync());
        }

        public IActionResult ViewResource(Guid id)
        {

            var tempData = SetPageNumberItem(id);
            var inboundItem = (from S in _context.InboundItem.Include(e => e.InboundOrder).Include(e => e.Item).Include("Item.ItemCategory").Where(e => e.InboundOrderId == id)
                               orderby S.create_date ascending
                               select S).Skip(tempData.SkipRecItm).Take(tempData.PerPageItm);
            string[] lHeaderItem = { "Line Number", "Item Name", "Item Type", "Cost", "Quantity Order", "Remain Quantity", "Create By", "Create Date", "Edit By", "Edit Date" };
            ViewData["HeaderSubMenu"] = lHeaderItem;
            ViewData["InboundItem"] = inboundItem;
            ViewBag.btn_receive = "Y";
            ViewBag.btn_store = "N";
            return View();
        }

        public IActionResult ViewSubResource(Guid id)
        {
            var tempData = SetPageNumberReceive(id);
            var itemReceive = (from S in _context.ItemReceived.Include(e => e.InboundItem).Include(e => e.ItemReceivedState).Include("InboundItem.InboundOrder").Include("InboundItem.Item").Include("InboundItem.Item.ItemCategory").Where(e => e.InboundItemId == id)
                                orderby S.create_date ascending
                                select S).Skip(tempData.SkipRecSubItm).Take(tempData.PerPageSubItm);

            string[] lHeaderReceive = { "Order Number", "Item Detail", "State", "Receive Quantity", "Cost", "Lot Number", "Expire Date", "Receive Date", "Description", "Create By", "Create Date", "Edit By", "Edit Date" };
            ViewData["HeaderReceive"] = lHeaderReceive;
            ViewData["ItemReceived"] = itemReceive;
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
                PerPage = HttpContext.Session.GetInt32("IOPerPage") ?? 20
            };
            if (searchState == true)
            {
                if (Temp.iSearchCount == 1)
                {
                    HttpContext.Session.SetInt32("IOPageNo", 1);
                    temp.PageNo = 1;
                }
                else
                {
                    temp.PageNo = HttpContext.Session.GetInt32("IOPageNo") ?? 1;
                }
                temp.TotalRec = (int)total;
            }
            else
            {
                if (sClear != null)
                {
                    HttpContext.Session.SetInt32("IOPageNo", 1);
                    temp.PageNo = 1;
                }
                else
                {
                    temp.PageNo = HttpContext.Session.GetInt32("IOPageNo") ?? 1;
                }
                temp.TotalRec = _context.InboundOrder.Count();
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

            HttpContext.Session.SetInt32("IOPerPage", vPage);
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
                string sSupplier = Guid.Empty.ToString();
                if (Temp.lSearch[6] != null)
                {
                    sSupplier = Temp.lSearch[6];
                }
                string sCustomer = Guid.Empty.ToString();
                if (Temp.lSearch[7] != null)
                {
                    sCustomer = Temp.lSearch[7];
                }

                return RedirectToAction("ViewContent", new { status = Temp.lSearch[0], ordernumber = Temp.lSearch[1], ordertype = iOrderType, sexpectdate = Temp.lSearch[3], startexpectdate = Convert.ToDateTime(Temp.lSearch[4]), endexpectdate = Convert.ToDateTime(Temp.lSearch[5]), supplier = sSupplier, customer = sCustomer, description = Temp.lSearch[8], createby = Temp.lSearch[9], screatedate = Temp.lSearch[10], startcreatedate = Convert.ToDateTime(Temp.lSearch[11]), endcreatedate = Convert.ToDateTime(Temp.lSearch[12]), editby = Temp.lSearch[13], seditdate = Temp.lSearch[14], starteditdate = Convert.ToDateTime(Temp.lSearch[15]), endeditdate = Convert.ToDateTime(Temp.lSearch[16]), closeby = Temp.lSearch[17], sclosedate = Temp.lSearch[18], startclosedate = Convert.ToDateTime(Temp.lSearch[19]), endclosedate = Convert.ToDateTime(Temp.lSearch[20]), closeremark = Temp.lSearch[21] });
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
            HttpContext.Session.SetInt32("IOPageNo", vPageNo);
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
                string sSupplier = Guid.Empty.ToString();
                if (Temp.lSearch[6] != null)
                {
                    sSupplier = Temp.lSearch[6];
                }
                string sCustomer = Guid.Empty.ToString();
                if (Temp.lSearch[7] != null)
                {
                    sCustomer = Temp.lSearch[7];
                }

                return RedirectToAction("ViewContent", new { status = Temp.lSearch[0], ordernumber = Temp.lSearch[1], ordertype = iOrderType, sexpectdate = Temp.lSearch[3], startexpectdate = Convert.ToDateTime(Temp.lSearch[4]), endexpectdate = Convert.ToDateTime(Temp.lSearch[5]), supplier = sSupplier, customer = sCustomer, description = Temp.lSearch[8], createby = Temp.lSearch[9], screatedate = Temp.lSearch[10], startcreatedate = Convert.ToDateTime(Temp.lSearch[11]), endcreatedate = Convert.ToDateTime(Temp.lSearch[12]), editby = Temp.lSearch[13], seditdate = Temp.lSearch[14], starteditdate = Convert.ToDateTime(Temp.lSearch[15]), endeditdate = Convert.ToDateTime(Temp.lSearch[16]), closeby = Temp.lSearch[17], sclosedate = Temp.lSearch[18], startclosedate = Convert.ToDateTime(Temp.lSearch[19]), endclosedate = Convert.ToDateTime(Temp.lSearch[20]), closeremark = Temp.lSearch[21] });
            }
        }

        private ManagePageNumber SetPageNumberItem(Guid id)
        {
            ManagePageNumber temp = new ManagePageNumber
            {
                PerPageItm = HttpContext.Session.GetInt32("IOIPerPage") ?? 20,
                PageNoItm = HttpContext.Session.GetInt32("IOIPageNo") ?? 1,
                TotalRecItm = _context.InboundItem.Where(x => x.InboundOrderId == id).Count()
            };
            int test = _context.InboundItem.Where(x => x.InboundOrderId == id).Count();
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

            HttpContext.Session.SetInt32("IOIPerPage", vPage);
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
            HttpContext.Session.SetInt32("IOIPageNo", vPageNo);
            return RedirectToAction("ViewResource", new { id = Id });
        }

        private ManagePageNumber SetPageNumberReceive(Guid id)
        {
            ManagePageNumber temp = new ManagePageNumber
            {
                PerPageSubItm = HttpContext.Session.GetInt32("RIPerPage") ?? 10,
                PageNoSubItm = HttpContext.Session.GetInt32("RIPageNo") ?? 1,
                TotalRecSubItm = _context.ItemReceived.Where(x => x.InboundItemId == id).Count()
            };
            int test = _context.InboundItem.Where(x => x.InboundOrderId == id).Count();
            temp.MaxPageSubItm = (int)Math.Ceiling((double)temp.TotalRecSubItm / (double)temp.PerPageSubItm);
            if (temp.MaxPageSubItm == 0)
                temp.MaxPageSubItm = 1;

            if ((temp.PageNoSubItm == 0) || (temp.PageNoSubItm > temp.MaxPageSubItm))
            {
                temp.PageNoSubItm = temp.MaxPageSubItm;
            }

            temp.SkipRecSubItm = (temp.PerPageSubItm * (temp.PageNoSubItm - 1));
            if (temp.TotalRecSubItm != 0)
            {
                temp.FirstRecSubItm = temp.SkipRecSubItm + 1;
            }
            else
            {
                temp.FirstRecSubItm = 0;
            }

            temp.LastRecSubItm = temp.FirstRecSubItm + temp.PerPageSubItm - 1 > temp.TotalRecSubItm ? temp.TotalRecSubItm : temp.FirstRecSubItm + temp.PerPageSubItm - 1;

            ViewData["PerPageSubItm"] = temp.PerPageSubItm;
            ViewData["FirstRecSubItm"] = temp.FirstRecSubItm;
            ViewData["LastRecSubItm"] = temp.LastRecSubItm;
            ViewData["PageNoSubItm"] = temp.PageNoSubItm;
            ViewData["MaxPageSubItm"] = temp.MaxPageSubItm;
            ViewData["TotalRecSubItm"] = temp.TotalRecSubItm;
            return temp;
        }

        public IActionResult SetPerPageReceive(int PerPage, Guid Id)
        {
            var vPage = PerPage switch
            {
                0 => 1,
                1 => 2,
                2 => 3,
                _ => 10,
            };

            HttpContext.Session.SetInt32("RIPerPage", vPage);
            return RedirectToAction("ViewSubResource", new { id = Id });
        }

        public IActionResult SetPageNoReceive(string PageNo, Guid Id)
        {
            var vPageNo = PageNo switch
            {
                "First" => 1,
                "Last" => 0,
                _ => Convert.ToInt32(PageNo),
            };
            HttpContext.Session.SetInt32("RIPageNo", vPageNo);
            return RedirectToAction("ViewSubResource", new { id = Id });
        }

        [AcceptVerbs("GET", "POST")]
        public async Task<IActionResult> checkOrderNo(Guid Id, string order_no)
        {

            var vInboundOrder = await _context.InboundOrder.Where(x => x.order_no == order_no).FirstOrDefaultAsync();
            if (vInboundOrder != null)
            {
                if (vInboundOrder.Id == Id)
                {
                    return Json(true);
                }
                else
                {
                    return Json(false);
                }  
            }
            else
            {
                return Json(true);
            }
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
            var vIO = _context.InboundOrder.Where(x => x.order_no.Contains(sDate)).OrderByDescending(x => x.order_no).FirstOrDefault();
            if (vIO != null)
            {
                int iOrderNumber = int.Parse(vIO.order_no[^4..]) + 1;
                string sOutput = string.Empty;
                for (int i = 1; i <= (4 - iOrderNumber.ToString().Length); i++)
                {
                    sOutput += "0";
                }
                sOutput += iOrderNumber.ToString();
                return Json("I" + sDate + sOutput);
            }
            else
            {
                return Json("I" + sDate + "0001");
            }
        }

        private bool ItemExists(Guid id)
        {
            return _context.InboundItem.Any(e => e.Id == id);
        }

        private bool ItemReceivedExists(Guid id)
        {
            return _context.ItemReceived.Any(e => e.Id == id);
        }

        private bool InboundOrderExists(Guid id)
        {
            return _context.InboundOrder.Any(e => e.Id == id);
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

        [AcceptVerbs("GET", "POST")]
        public JsonResult checkRcvQty(int receive_qty, Guid Id, Guid InboundItemId)
        {
            var vInboundItem = _context.InboundItem.Where(x => x.Id == InboundItemId).FirstOrDefault();
            var vItemReceived = _context.ItemReceived.Where(x => x.Id == Id).FirstOrDefault();
            if (receive_qty != 0)
            {
                if (vItemReceived != null)
                {
                    if (receive_qty > (vInboundItem.remain_qty + vItemReceived.receive_qty))
                    {
                        return Json($"Cannot be greater than " + (vInboundItem.remain_qty + vItemReceived.receive_qty).ToString() + ".");
                    }
                    else
                    {
                        return Json(true);
                    }
                }
                else
                {
                    if (receive_qty > vInboundItem.remain_qty)
                    {
                        return Json($"Cannot be greater than " + vInboundItem.remain_qty.ToString() + ".");
                    }
                    else
                    {
                        return Json(true);
                    }
                }
            }
            else
            {
                return Json($"Please Check Receive Quantity.");
            }
        }

        [AcceptVerbs("GET", "POST")]
        public JsonResult checkExpireDate(DateTime? expire_date, Guid InboundItemId)
        {
            var vInboundItem = _context.InboundItem.Include(x => x.Item).Include("Item.QueueType").Where(x => x.Id == InboundItemId).FirstOrDefault();
            if (expire_date == null && vInboundItem.Item.QueueType.category.Trim() == "FEFO")
            {
                return Json(false);
            }
            else
            {
                return Json(true);
            }
        }

        [AcceptVerbs("GET", "POST")]
        public JsonResult CheckStatusDeleteOrder(Guid id)
        {
            var vInboundOrder = _context.InboundOrder.Include(x => x.StatusInboundOrder).Where(x => x.Id == id).FirstOrDefault();
            bool result = true;
            string order_no = string.Empty;
            if (vInboundOrder.StatusInboundOrder.status != "" && vInboundOrder.StatusInboundOrder.status != "open")
            {
                result = false;
                order_no = vInboundOrder.order_no;
            }

            return Json(new { result, order_no });
        }

        [AcceptVerbs("GET", "POST")]
        public JsonResult CheckStatusDeleteItem(Guid id)
        {
            var vInbounditem = _context.InboundItem.Include(x => x.Item).Where(x => x.Id == id).FirstOrDefault();
            bool result = true;
            string item_detail = string.Empty;
            if (vInbounditem.qty > vInbounditem.remain_qty)
            {
                result = false;
                item_detail = "(" + vInbounditem.Item.item_code + " " + vInbounditem.Item.item_name + ")";
            }

            return Json(new { result, item_detail });
        }

        private Boolean CheckReplaceReceived(Guid id)
        {
            var inboundItem = (from S in _context.InboundItem.Include(e => e.InboundOrder).Include(e => e.Item).Include("Item.ItemCategory").Where(e => e.InboundOrderId == id)
                               orderby S.create_date ascending
                               select S).ToList();
            for (int i = 0; i < inboundItem.Count(); i++)
            {
                if (inboundItem[i].remain_qty != 0)
                {
                    return false;
                }
            }
            return true;
        }

        [AcceptVerbs("GET", "POST")]
        public JsonResult CheckQuantity(int qty)
        {
            if (qty == 0)
            {
                return Json($"Quantity must be more than zero.");
            }
            else
            {
                return Json(true);
            }
        }

    }
}
