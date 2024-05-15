using Authentication.Data;
using Authentication.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Authentication.Controllers
{
    public class InventoriesController : Controller
    {
        private readonly WMContext _context;
        private string[] lHeader = { "Item Code", "Item Name", "Item Category", "Cost", "Quantity" };

        public InventoriesController(WMContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var tempData = await SetPageNumber(null, false, null);
            var vItem = (from a in _context.Inventory 
                         join b in _context.ItemReceived
                         on a.ItemReceivedId equals b.Id
                         join c in _context.InboundItem
                         on b.InboundItemId equals c.Id
                         join d in _context.Item
                         on c.ItemId equals d.Id
                         join e in _context.ItemCategory
                         on d.ItemCategoryId equals e.Id
                         group new { a, b, c, d, e } by new
                         {
                             d.Id,
                             d.item_code,
                             d.item_name,
                             e.category_name
                         } into temp
                         select new InventoryViewModel
                         {
                             id             = temp.Key.Id,
                             itemCode       = temp.Key.item_code,
                             itemName       = temp.Key.item_name,
                             itemCategory   = temp.Key.category_name,
                             cost           = temp.Sum(x => x.c.cost),
                             unit           = temp.Sum(x => x.a.qty)
                         }).Skip(tempData.SkipRec).Take(tempData.PerPage);

            var itemCategory = _context.ItemCategory.Select(s => new { Id = s.Id.ToString(), Name = s.category_name }).ToList();
            itemCategory.Insert(0, new
            {
                Id = string.Empty,
                Name = "Select Category"
            });

            setSearchState(false);
            Temp.lSearch.Clear();
            Temp.iSearchCount = 0;
            ViewData["Header"] = lHeader;
            ViewData["ItemCategoryList"] = new SelectList(itemCategory, "Id", "Name");
            ViewBag.btn_edit = "N";
            ViewBag.btn_del = "N";
            return View(await vItem.ToListAsync());
        }

        public async Task<IActionResult> Details(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inventory = await (from a in _context.Inventory
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
                              where (c.ItemId == id)
                              select new InventoryDetailViewModel
                              {
                                    orderNo         = d.order_no,
                                    lotNo           = b.lot_no,
                                    itemCode        = e.item_code,
                                    itemName        = e.item_name,
                                    itemCategory    = f.category_name,
                                    cost            = b.cost,
                                    unit            = b.receive_qty,
                                    receiveDate     = b.receive_date,
                                    locationCode    = g.location_code,
                                    locationName    = h.category_name,
                                    status          = b.status
                              }).OrderBy(x => x.receiveDate).ToListAsync();
            return View(inventory);
        }

        public async Task<IActionResult> ViewContent(string itemcode, string itemname, string itemcategory, string clear)
        {
            IQueryable<InventoryViewModel> inventories = (from a in _context.Inventory 
                                                 join b in _context.ItemReceived
                                                 on a.ItemReceivedId equals b.Id
                                                 join c in _context.InboundItem
                                                 on b.InboundItemId equals c.Id
                                                 join d in _context.Item
                                                 on c.ItemId equals d.Id
                                                 join e in _context.ItemCategory
                                                 on d.ItemCategoryId equals e.Id
                                                 group new { a, b, c, d, e } by new
                                                 {
                                                     d.Id,
                                                     d.item_code,
                                                     d.item_name,
                                                     itemCategoryId = e.Id,
                                                     e.category_name
                                                 } into temp
                                                 select new InventoryViewModel
                                                 {
                                                     id             = temp.Key.Id,
                                                     itemCode       = temp.Key.item_code,
                                                     itemName       = temp.Key.item_name,
                                                     itemCategoryId = temp.Key.itemCategoryId,
                                                     itemCategory   = temp.Key.category_name,
                                                     cost           = temp.Sum(x => x.c.cost),
                                                     unit           = temp.Sum(x => x.a.qty)
                                                 });
            setSearchState(false);
            Temp.lSearch.Clear();
            Temp.lSearch.Add(itemcode);
            Temp.lSearch.Add(itemname);
            if (itemcode != null)
            {
                inventories = inventories.Where(d => d.itemCode.Contains(itemcode)).AsQueryable();
                setSearchState(true);
            }
            if (itemname != null)
            {
                inventories = inventories.Where(d => d.itemName.Contains(itemname)).AsQueryable();
                setSearchState(true);
            }
            if (itemcategory != null && Guid.Parse(itemcategory) != Guid.Empty)
            {
                inventories = inventories.Where(d => d.itemCategoryId == Guid.Parse(itemcategory)).AsQueryable();
                setSearchState(true);
                Temp.lSearch.Add(itemcategory.ToString());
            }
            else
            {
                Temp.lSearch.Add(null);
            }

            if (Temp.bSearchState == false)
            {
                Temp.lSearch.Clear();
                Temp.iSearchCount = 0;
            }
            else
            {
                ViewData["itemcode"] = Temp.lSearch[0];
                ViewData["itemname"] = Temp.lSearch[1];
                if (Temp.lSearch[2] != null)
                {
                    ViewData["itemcategory"] = Temp.lSearch[2].ToString();
                }
                else
                {
                    ViewData["itemcategory"] = null;
                }
                
                Temp.iSearchCount += 1;
            }

            var tempData = await SetPageNumber(inventories.Count(), Temp.bSearchState, clear);
            inventories = inventories.Skip(tempData.SkipRec).Take(tempData.PerPage);

            var itemType = _context.ItemCategory.Select(s => new { Id = s.Id.ToString(), Name = s.category_name }).ToList();
            itemType.Insert(0, new
            {
                Id = string.Empty,
                Name = "Select Category"
            });

            ViewData["Header"] = lHeader;
            ViewData["ItemCategoryList"] = new SelectList(itemType, "Id", "Name");
            ViewBag.btn_edit = "N";
            ViewBag.btn_del = "N";
            return View(await inventories.ToListAsync());
        }

        private void setSearchState(bool state)
        {
            Temp.bSearchState = state;
        }

        private async Task<ManagePageNumber> SetPageNumber(int? total, bool searchState, string sClear)
        {
            ManagePageNumber temp = new ManagePageNumber();

            temp.PerPage = HttpContext.Session.GetInt32("IPerPage") ?? 20;

            if (searchState == true)
            {
                if (Temp.iSearchCount == 1)
                {
                    HttpContext.Session.SetInt32("IPageNo", 1);
                    temp.PageNo = 1;
                }
                else
                {
                    temp.PageNo = HttpContext.Session.GetInt32("IPageNo") ?? 1;
                }
                temp.TotalRec = (int)total;
            }
            else
            {
                if (sClear != null)
                {
                    HttpContext.Session.SetInt32("IPageNo", 1);
                    temp.PageNo = 1;
                }
                else
                {
                    temp.PageNo = HttpContext.Session.GetInt32("IPageNo") ?? 1;
                }
                temp.TotalRec = await (from a in _context.Inventory 
                                 join b in _context.ItemReceived
                                 on a.ItemReceivedId equals b.Id
                                 join c in _context.InboundItem
                                 on b.InboundItemId equals c.Id
                                 join d in _context.Item
                                 on c.ItemId equals d.Id
                                 join e in _context.ItemCategory
                                 on d.ItemCategoryId equals e.Id
                                 group new { a, b, c, d, e } by new
                                 {
                                     d.Id,
                                     d.item_code,
                                     d.item_name,
                                     e.category_name
                                 } into tempInventory
                                 select new InventoryViewModel
                                 {
                                     id             = tempInventory.Key.Id,
                                     itemCode       = tempInventory.Key.item_code,
                                     itemName       = tempInventory.Key.item_name,
                                     itemCategory   = tempInventory.Key.category_name,
                                     cost           = tempInventory.Sum(x => x.c.cost),
                                     unit           = tempInventory.Sum(x => x.a.qty)
                                 }).CountAsync();
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

            HttpContext.Session.SetInt32("IPerPage", vPage);
            if (Temp.bSearchState == false)
            {
                return RedirectToAction(nameof(ViewContent));
            }
            else
            {
                string itemCategory = Guid.Empty.ToString();
                if (Temp.lSearch[2] != null)
                {
                    itemCategory = Temp.lSearch[2];
                }
                
                return RedirectToAction("ViewContent", new { itemcode = Temp.lSearch[0], itemname = Temp.lSearch[1], itemcategory = itemCategory });
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
            HttpContext.Session.SetInt32("IPageNo", vPageNo);
            if (Temp.bSearchState == false)
            {
                return RedirectToAction(nameof(ViewContent));
            }
            else
            {
                string itemCategory = Guid.Empty.ToString();
                if (Temp.lSearch[2] != null)
                {
                    itemCategory = Temp.lSearch[2];
                }
                
                return RedirectToAction("ViewContent", new { itemcode = Temp.lSearch[0], itemname = Temp.lSearch[1], itemcategory = itemCategory });
            }
        }
    }
}
