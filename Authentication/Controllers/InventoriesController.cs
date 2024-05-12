using Authentication.Data;
using Authentication.Models;
using Authentication.ViewModels;
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

        public IActionResult Index()
        {
            var tempData = SetPageNumber(null, false, null);
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
                         select new Inventories
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
            return View(vItem.ToListAsync());
        }

        public async Task<IActionResult> ViewContent(string itemcode, string itemname, string itemcategory, int? cost, int? unit, string clear)
        {
            return View();
        }

        private void setSearchState(bool state)
        {
            Temp.bSearchState = state;
        }

        private ManagePageNumber SetPageNumber(int? total, bool searchState, string sClear)
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
                temp.TotalRec = _context.Item.Count();
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
                string sItemCategory = Guid.Empty.ToString();
                if (Temp.lSearch[2] != null)
                {
                    sItemCategory = Temp.lSearch[2];
                }
                int? iCost = null;
                if (Temp.lSearch[3] != null)
                {
                    iCost = int.Parse(Temp.lSearch[3]);
                }
                int? iUnit = null;
                if (Temp.lSearch[4] != null)
                {
                    iUnit = int.Parse(Temp.lSearch[4]);
                }
                int? iQueueType = null;
                if (Temp.lSearch[5] != null)
                {
                    iQueueType = int.Parse(Temp.lSearch[5]);
                }
                return RedirectToAction("ViewContent", new { itemcode = Temp.lSearch[0], itemname = Temp.lSearch[1], itemcategory = sItemCategory, cost = iCost, unit = iUnit, queuetype = iQueueType, createby = Temp.lSearch[6], screatedate = Temp.lSearch[7], startcreatedate = Convert.ToDateTime(Temp.lSearch[8]), endcreatedate = Convert.ToDateTime(Temp.lSearch[9]), editby = Temp.lSearch[10], seditdate = Temp.lSearch[11], starteditdate = Convert.ToDateTime(Temp.lSearch[12]), endeditdate = Convert.ToDateTime(Temp.lSearch[13]) });
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
                string sItemCategory = Guid.Empty.ToString();
                if (Temp.lSearch[2] != null)
                {
                    sItemCategory = Temp.lSearch[2];
                }
                int? iCost = null;
                if (Temp.lSearch[3] != null)
                {
                    iCost = int.Parse(Temp.lSearch[3]);
                }
                int? iUnit = null;
                if (Temp.lSearch[4] != null)
                {
                    iUnit = int.Parse(Temp.lSearch[4]);
                }
                int? iQueueType = null;
                if (Temp.lSearch[5] != null)
                {
                    iQueueType = int.Parse(Temp.lSearch[5]);
                }
                return RedirectToAction("ViewContent", new { itemcode = Temp.lSearch[0], itemname = Temp.lSearch[1], itemcategory = sItemCategory, cost = iCost, unit = iUnit, queuetype = iQueueType, createby = Temp.lSearch[6], screatedate = Temp.lSearch[7], startcreatedate = Convert.ToDateTime(Temp.lSearch[8]), endcreatedate = Convert.ToDateTime(Temp.lSearch[9]), editby = Temp.lSearch[10], seditdate = Temp.lSearch[11], starteditdate = Convert.ToDateTime(Temp.lSearch[12]), endeditdate = Convert.ToDateTime(Temp.lSearch[13]) });
            }
        }
    }
}
