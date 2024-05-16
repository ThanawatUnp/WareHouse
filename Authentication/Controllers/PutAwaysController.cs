using Authentication.Data;
using Authentication.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Authentication.Controllers
{
    public class PutAwaysController : Controller
    {
        private readonly WMContext _context;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly string[] lHeader = { "Order Number", "Item Detail", "State", "Receive Quantity", "Remain Put Away", "Cost", "Lot Number", "Expire Date", "Receive Date", "Description" };

        public PutAwaysController(WMContext context, RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _context = context;
            _roleManager = roleManager;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IActionResult> Index()
        {
            var tempData = SetPageNumber(null, false, null);
            var vItemReceive = (from S in _context.ItemReceived.Include(e => e.InboundItem).Include(e => e.ItemReceivedState).Include("InboundItem.InboundOrder").Include("InboundItem.Item").Include("InboundItem.Item.ItemCategory").Where(e => e.status.Contains("wait"))
                                orderby S.receive_date ascending
                                select S).Skip(tempData.SkipRec).Take(tempData.PerPage);

            var vItemState = _context.ItemReceivedState.OrderBy(x => x.state).Select(s => new { Id = s.Id.ToString(), State = s.state }).ToList();
            vItemState.Insert(0, new
            {
                Id = string.Empty,
                State = "Select"
            });

            ViewData["Header"] = lHeader;
            ViewData["StateList"] = new SelectList(vItemState, "Id", "State");
            ViewBag.btn_edit = "N";
            ViewBag.btn_del = "N";
            ViewBag.btn_store = "Y";
            ViewBag.Menu = "putaway";
            return View(await vItemReceive.ToListAsync());
        }

        public async Task<IActionResult> PutAway(Guid id)
        {
            if (id == Guid.Empty || id == null)
            {
                return NotFound();
            }

            var vItemReceived = await _context.ItemReceived.Include(x => x.InboundItem).Include("InboundItem.Item").FirstOrDefaultAsync(x => x.Id == id);
            if (vItemReceived == null)
            {
                return NotFound();
            }

            var vInboundItem = _context.InboundItem.Include(x => x.Item).Include("Item.ItemCategory").Where(x => x.Id == vItemReceived.InboundItemId).FirstOrDefault();
            var vLocation = _context.Location.Include(x => x.LocationCategory).OrderBy(x => x.location_code).Select(s => new { Id = s.Id.ToString(), Location = s.location_code + ": " + s.LocationCategory.category_name }).ToList();
            vLocation.Insert(0, new
            {
                Id = string.Empty,
                Location = "Select"
            });

            for (int i = (vLocation.Count - 1); i >= 1; i--)
            {
                var vInventory = _context.Inventory.Include(x => x.StatusInventory).Include(x => x.ItemReceived).Include("ItemReceived.InboundItem").Where(x => x.LocationId == Guid.Parse(vLocation.ElementAt(i).Id) && x.StatusInventory.status.Contains("available")).ToList();
                var vLocate = _context.Location.Where(x => x.Id == Guid.Parse(vLocation.ElementAt(i).Id)).FirstOrDefault();
                for (int j = 0; j < vInventory.Count; j++)
                {
                    if (vInventory.Count == 0)
                    {
                        continue;
                    }
                    else
                    {
                        if (vLocate.mix_item == true)
                        {
                            continue;
                        }
                        else
                        {
                            if (vItemReceived.InboundItem.ItemId == vInventory.ElementAt(j).ItemReceived.InboundItem.ItemId)
                            {
                                if (vLocate.mix_expire == true)
                                {
                                    if (vLocate.mix_lot == true)
                                    {
                                        continue;
                                    }
                                    else
                                    {
                                        if (vItemReceived.lot_no == vInventory.ElementAt(j).ItemReceived.lot_no)
                                        {
                                            continue;
                                        }
                                        else
                                        {
                                            vLocation.RemoveAt(i);
                                        }
                                    }
                                }
                                else
                                {
                                    if (vItemReceived.expire_date == vInventory.ElementAt(j).ItemReceived.expire_date)
                                    {
                                        if (vLocate.mix_lot == true)
                                        {
                                            continue;
                                        }
                                        else
                                        {
                                            if (vItemReceived.lot_no == vInventory.ElementAt(j).ItemReceived.lot_no)
                                            {
                                                continue;
                                            }
                                            else
                                            {
                                                vLocation.RemoveAt(i);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        vLocation.RemoveAt(i);
                                    }
                                }
                            }
                            else
                            {
                                vLocation.RemoveAt(i);
                            }
                        }
                    }
                }
            }

            var Inventory = new Inventory()
            {
                Id = Guid.NewGuid(),
                ItemReceivedId = vItemReceived.Id
            };

            ViewData["LocationList"] = new SelectList(vLocation, "Id", "Location");
            ViewData["ItemDetail"] = vInboundItem.Item.item_code + ": " + vInboundItem.Item.ItemCategory.category_name;
            ViewData["ReceivedQty"] = vItemReceived.receive_qty;
            ViewData["RemainPutAway"] = vItemReceived.remain_putaway;
            return View(Inventory);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PutAway(Guid id, [Bind("Id, qty, status, LocationId, ItemReceivedId")] Inventory inventory)
        {
            if (ModelState.IsValid) // Check binding success
            {
                try
                {
                    var vItemReceived = _context.ItemReceived.FirstOrDefault(x => x.Id == inventory.ItemReceivedId);
                    StatusInventory oSI = new StatusInventory();
                    Guid oStatusId = Guid.NewGuid();
                    oSI.Id = oStatusId;
                    oSI.status = "available";
                    oSI.create_date = DateTime.Now;
                    oSI.create_by = User.Identity.Name;
                    oSI.InventoryId = inventory.Id;
                    _context.Add(oSI);
                    await _context.SaveChangesAsync();

                    inventory.StatusInventoryId = oStatusId;
                    inventory.create_date = DateTime.Now;
                    inventory.create_by = User.Identity.Name; //Program.username;

                    _context.Add(inventory);
                    await _context.SaveChangesAsync();

                    vItemReceived.remain_putaway -= inventory.qty;
                    if (vItemReceived.remain_putaway == 0)
                    {
                        vItemReceived.status = "done";
                    }
                    _context.Update(vItemReceived);
                    await _context.SaveChangesAsync();
                    if (Temp.bSearchState == false)
                    {
                        return RedirectToAction(nameof(ViewContent));
                    }
                    else
                    {
                        int? iState = null;
                        if (Temp.lSearch[3] != null)
                        {
                            iState = int.Parse(Temp.lSearch[3]);
                        }
                        int? iReceiveqty = null;
                        if (Temp.lSearch[4] != null)
                        {
                            iReceiveqty = int.Parse(Temp.lSearch[4]);
                        }
                        double? dCost = null;
                        if (Temp.lSearch[5] != null)
                        {
                            dCost = int.Parse(Temp.lSearch[5]);
                        }

                        return RedirectToAction("ViewContent", new { ordernumber = Temp.lSearch[0], itemcode = Temp.lSearch[1], itemname = Temp.lSearch[2], state = iState, receiveqty = iReceiveqty, cost = dCost, lotnumber = Temp.lSearch[6], sexpiredate = Temp.lSearch[7], startexpiredate = Convert.ToDateTime(Temp.lSearch[8]), endexpiredate = Convert.ToDateTime(Temp.lSearch[9]), sreceivedate = Temp.lSearch[10], startreceivedate = Convert.ToDateTime(Temp.lSearch[11]), endreceivedate = Convert.ToDateTime(Temp.lSearch[12]), description = Temp.lSearch[13] });
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InventoryExists(inventory.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }

            return View(inventory);
        }

        public async Task<IActionResult> ViewContent(string ordernumber, string itemcode, string itemname, int? state, int? receiveqty, double? cost, string lotnumber, string sexpiredate, DateTime startexpiredate, DateTime endexpiredate, string sreceivedate, DateTime startreceivedate, DateTime endreceivedate, string description, string clear)
        {
            IQueryable<ItemReceived> vItemReceived = (from S in _context.ItemReceived.Include(e => e.InboundItem).Include(e => e.ItemReceivedState).Include("InboundItem.InboundOrder").Include("InboundItem.Item").Include("InboundItem.Item.ItemCategory").Where(e => e.status.Contains("wait"))
                                              orderby S.receive_date ascending
                                              select S);
            setSearchState(false);
            Temp.lSearch.Clear();
            Temp.lSearch.Add(ordernumber);
            Temp.lSearch.Add(itemcode);
            Temp.lSearch.Add(itemname);
            if (ordernumber != null)
            {
                vItemReceived = vItemReceived.Where(x => x.InboundItem.InboundOrder.order_no.Contains(ordernumber)).AsQueryable();
                setSearchState(true);
            }
            if (itemcode != null)
            {
                vItemReceived = vItemReceived.Where(x => x.InboundItem.Item.item_code.Contains(itemcode)).AsQueryable();
                setSearchState(true);
            }
            if (itemname != null)
            {
                vItemReceived = vItemReceived.Where(x => x.InboundItem.Item.item_name.Contains(itemname)).AsQueryable();
                setSearchState(true);
            }
            if (state != null)
            {
                vItemReceived = vItemReceived.Where(x => x.ItemReceivedStateId == state).AsQueryable();
                setSearchState(true);
                Temp.lSearch.Add(state.ToString());
            }
            else
            {
                Temp.lSearch.Add(null);
            }
            if (receiveqty != null)
            {
                vItemReceived = vItemReceived.Where(x => x.receive_qty == receiveqty).AsQueryable();
                setSearchState(true);
                Temp.lSearch.Add(receiveqty.ToString());
            }
            else
            {
                Temp.lSearch.Add(null);
            }
            if (cost != null)
            {
                vItemReceived = vItemReceived.Where(x => x.cost == cost).AsQueryable();
                setSearchState(true);
                Temp.lSearch.Add(cost.ToString());
            }
            else
            {
                Temp.lSearch.Add(null);
            }
            Temp.lSearch.Add(lotnumber);
            if (lotnumber != null)
            {
                vItemReceived = vItemReceived.Where(x => x.lot_no.Contains(lotnumber)).AsQueryable();
                setSearchState(true);
            }
            if (sexpiredate != null && sexpiredate.Trim() == "y")
            {
                vItemReceived = vItemReceived.Where(x => x.expire_date >= startexpiredate.Date && x.expire_date < endexpiredate.AddDays(1).Date).AsQueryable();
                setSearchState(true);
                Temp.lSearch.Add(sexpiredate);
                Temp.lSearch.Add(startexpiredate.Date.ToString());
                Temp.lSearch.Add(endexpiredate.Date.ToString());
            }
            else
            {
                Temp.lSearch.Add(null);
                Temp.lSearch.Add(null);
                Temp.lSearch.Add(null);
            }
            if (sreceivedate != null && sreceivedate.Trim() == "y")
            {
                vItemReceived = vItemReceived.Where(x => x.receive_date >= startreceivedate.Date && x.receive_date < endreceivedate.AddDays(1).Date).AsQueryable();
                setSearchState(true);
                Temp.lSearch.Add(sreceivedate);
                Temp.lSearch.Add(startreceivedate.Date.ToString());
                Temp.lSearch.Add(endreceivedate.Date.ToString());
            }
            else
            {
                Temp.lSearch.Add(null);
                Temp.lSearch.Add(null);
                Temp.lSearch.Add(null);
            }
            Temp.lSearch.Add(description);
            if (description != null)
            {
                vItemReceived = vItemReceived.Where(x => x.description.Contains(description)).AsQueryable();
                setSearchState(true);
            }
            if (Temp.bSearchState == false)
            {
                Temp.lSearch.Clear();
                Temp.iSearchCount = 0;
                ViewData["expiredatestate"] = "n";
                ViewData["receivedatestate"] = "n";
            }
            else
            {
                ViewData["ordernumber"] = Temp.lSearch[0];
                ViewData["itemcode"] = Temp.lSearch[1];
                ViewData["itemname"] = Temp.lSearch[2];
                ViewData["state"] = Temp.lSearch[3];
                ViewData["receiveqty"] = Temp.lSearch[4];
                ViewData["cost"] = Temp.lSearch[5];
                ViewData["lotnumber"] = Temp.lSearch[6];
                if (Temp.lSearch[7] != null)
                {
                    ViewData["expiredatestate"] = "y";
                    ViewData["startexpiredate"] = Convert.ToDateTime(Temp.lSearch[8]).Month.ToString() + "/" + Convert.ToDateTime(Temp.lSearch[8]).Day.ToString() + "/" + Convert.ToDateTime(Temp.lSearch[8]).Year.ToString();
                    ViewData["endexpiredate"] = Convert.ToDateTime(Temp.lSearch[9]).Month.ToString() + "/" + Convert.ToDateTime(Temp.lSearch[9]).Day.ToString() + "/" + Convert.ToDateTime(Temp.lSearch[9]).Year.ToString();
                }
                else
                {
                    ViewData["expiredatestate"] = "n";
                }

                if (Temp.lSearch[10] != null)
                {
                    ViewData["receivedatestate"] = "y";
                    ViewData["startreceivedate"] = Convert.ToDateTime(Temp.lSearch[11]).Month.ToString() + "/" + Convert.ToDateTime(Temp.lSearch[11]).Day.ToString() + "/" + Convert.ToDateTime(Temp.lSearch[11]).Year.ToString();
                    ViewData["endreceivedate"] = Convert.ToDateTime(Temp.lSearch[12]).Month.ToString() + "/" + Convert.ToDateTime(Temp.lSearch[12]).Day.ToString() + "/" + Convert.ToDateTime(Temp.lSearch[12]).Year.ToString();
                }
                else
                {
                    ViewData["receivedatestate"] = "n";
                }
                ViewData["description"] = Temp.lSearch[13];
                Temp.iSearchCount += 1;
            }
            var tempData = SetPageNumber(vItemReceived.Count(), Temp.bSearchState, clear);
            vItemReceived = vItemReceived.Skip(tempData.SkipRec).Take(tempData.PerPage);

            var vItemState = _context.ItemReceivedState.OrderBy(x => x.state).Select(s => new { Id = s.Id.ToString(), State = s.state }).ToList();
            vItemState.Insert(0, new
            {
                Id = string.Empty,
                State = "Select"
            });

            ViewData["Header"] = lHeader;
            ViewData["StateList"] = new SelectList(vItemState, "Id", "State");
            ViewBag.btn_edit = "N";
            ViewBag.btn_del = "N";
            ViewBag.btn_store = "Y";
            ViewBag.Menu = "putaway";
            return View(await vItemReceived.ToListAsync());
        }

        private void setSearchState(bool state)
        {
            Temp.bSearchState = state;
        }

        private ManagePageNumber SetPageNumber(int? total, bool searchState, string sClear)
        {
            ManagePageNumber temp = new ManagePageNumber
            {
                PerPage = HttpContext.Session.GetInt32("PAPerPage") ?? 20
            };
            if (searchState == true)
            {
                if (Temp.iSearchCount == 1)
                {
                    HttpContext.Session.SetInt32("PAPageNo", 1);
                    temp.PageNo = 1;
                }
                else
                {
                    temp.PageNo = HttpContext.Session.GetInt32("PAPageNo") ?? 1;
                }
                temp.TotalRec = (int)total;
            }
            else
            {
                if (sClear != null)
                {
                    HttpContext.Session.SetInt32("PAPageNo", 1);
                    temp.PageNo = 1;
                }
                else
                {
                    temp.PageNo = HttpContext.Session.GetInt32("PAPageNo") ?? 1;
                }
                temp.TotalRec = _context.ItemReceived.Where(x => x.status.Contains("wait")).Count();
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

            HttpContext.Session.SetInt32("PAPerPage", vPage);
            if (Temp.bSearchState == false)
            {
                return RedirectToAction(nameof(ViewContent));
            }
            else
            {
                int? iState = null;
                if (Temp.lSearch[3] != null)
                {
                    iState = int.Parse(Temp.lSearch[3]);
                }
                int? iReceiveqty = null;
                if (Temp.lSearch[4] != null)
                {
                    iReceiveqty = int.Parse(Temp.lSearch[4]);
                }
                double? dCost = null;
                if (Temp.lSearch[5] != null)
                {
                    dCost = int.Parse(Temp.lSearch[5]);
                }

                return RedirectToAction("ViewContent", new { ordernumber = Temp.lSearch[0], itemcode = Temp.lSearch[1], itemname = Temp.lSearch[2], state = iState, receiveqty = iReceiveqty, cost = dCost, lotnumber = Temp.lSearch[6], sexpiredate = Temp.lSearch[7], startexpiredate = Convert.ToDateTime(Temp.lSearch[8]), endexpiredate = Convert.ToDateTime(Temp.lSearch[9]), sreceivedate = Temp.lSearch[10], startreceivedate = Convert.ToDateTime(Temp.lSearch[11]), endreceivedate = Convert.ToDateTime(Temp.lSearch[12]), description = Temp.lSearch[13] });
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
            HttpContext.Session.SetInt32("PAPageNo", vPageNo);
            if (Temp.bSearchState == false)
            {
                return RedirectToAction(nameof(ViewContent));
            }
            else
            {
                int? iState = null;
                if (Temp.lSearch[3] != null)
                {
                    iState = int.Parse(Temp.lSearch[3]);
                }
                int? iReceiveqty = null;
                if (Temp.lSearch[4] != null)
                {
                    iReceiveqty = int.Parse(Temp.lSearch[4]);
                }
                double? dCost = null;
                if (Temp.lSearch[5] != null)
                {
                    dCost = int.Parse(Temp.lSearch[5]);
                }

                return RedirectToAction("ViewContent", new { ordernumber = Temp.lSearch[0], itemcode = Temp.lSearch[1], itemname = Temp.lSearch[2], state = iState, receiveqty = iReceiveqty, cost = dCost, lotnumber = Temp.lSearch[6], sexpiredate = Temp.lSearch[7], startexpiredate = Convert.ToDateTime(Temp.lSearch[8]), endexpiredate = Convert.ToDateTime(Temp.lSearch[9]), sreceivedate = Temp.lSearch[10], startreceivedate = Convert.ToDateTime(Temp.lSearch[11]), endreceivedate = Convert.ToDateTime(Temp.lSearch[12]), description = Temp.lSearch[13] });
            }
        }

        [AcceptVerbs("GET", "POST")]
        public async Task<JsonResult> GetMixLocationAsync(Guid id)
        {
            var vLocation = await _context.Location.FirstOrDefaultAsync(x => x.Id == id);
            string sMixExpire = string.Empty;
            string sMixItem = string.Empty;
            string sMixLot = string.Empty;
            if (vLocation.mix_expire)
            {
                sMixExpire = "Yes";
            }
            else
            {
                sMixExpire = "No";
            }

            if (vLocation.mix_item)
            {
                sMixItem = "Yes";
            }
            else
            {
                sMixItem = "No";
            }

            if (vLocation.mix_lot)
            {
                sMixLot = "Yes";
            }
            else
            {
                sMixLot = "No";
            }

            return Json(new { sMixExpire, sMixItem, sMixLot });
        }

        private bool InventoryExists(Guid id)
        {
            return _context.Inventory.Any(e => e.Id == id);
        }
    }
}
