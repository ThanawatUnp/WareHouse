using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Authentication.Data;
using Authentication.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using System.IO;

namespace Authentication.Controllers
{
    [Authorize]
    public class ItemsController : Controller
    {
        private readonly WMContext _context;
        private string[] lHeader = { "Item Code", "Item Name", "Item Category", "Description", "Cost", "Unit", "Export Category", "Create By", "Create Date", "Edit By", "Edit Date" };

        public ItemsController(WMContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var tempData = SetPageNumber(null, false, null);
            var vItem = (from d in _context.Item.Include(e => e.ItemCategory).Include(e => e.QueueType)
                             orderby d.create_date ascending
                             select d).Skip(tempData.SkipRec).Take(tempData.PerPage);

            var itemCategory = _context.ItemCategory.Select(s => new { Id = s.Id.ToString(), Name = s.category_name }).ToList();
            itemCategory.Insert(0, new
            {
                Id = string.Empty,
                Name = "Select Category"
            });

            var queueType = _context.QueueType.Select(s => new { Id = (int?)s.Id, Category = s.category }).ToList();
            queueType.Insert(0, new
            {
                Id = new Nullable<int>(),
                Category = "Select"
            });

            setSearchState(false);
            Temp.lSearch.Clear();
            Temp.iSearchCount = 0;
            ViewData["Header"] = lHeader;
            ViewData["ItemCategoryList"] = new SelectList(itemCategory, "Id", "Name");
            ViewData["QueueTypeList"] = new SelectList(queueType, "Id", "Category");
            ViewBag.btn_edit = "Y";
            ViewBag.btn_del = "Y";
            return View(await vItem.ToListAsync());
        }

        public IActionResult Create()
        {
            var item = new Item();
            item.Id = Guid.NewGuid();
            var itemCategory = _context.ItemCategory.Select(s => new { Id = s.Id.ToString(), Name = s.category_name }).ToList();
            itemCategory.Insert(0, new
            {
                Id = string.Empty,
                Name = "Select Category"
            });

            var queueType = _context.QueueType.Select(s => new { Id = (int?)s.Id, Category = s.category }).ToList();
            queueType.Insert(0, new
            {
                Id = new Nullable<int>(),
                Category = "Select"
            });
            ViewData["ItemCategoryList"] = new SelectList(itemCategory, "Id", "Name");
            ViewData["QueueTypeList"] = new SelectList(queueType, "Id", "Category");
            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id, item_code, item_name, description, cost, unit, create_by, create_date, edit_by, edit_date, file_name, ItemCategoryId, QueueTypeId")] Item item)
        {
            if (ModelState.IsValid) // Check binding success
            {
                var fcus = await _context.Item.FirstOrDefaultAsync(m => m.item_code == item.item_code);
                if (fcus != null)
                {
                    return NotFound();
                }
                if (Request.Form.Files.Count > 0)
                {
                    string path = @"wwwroot\images\item";
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    string[] files = System.IO.Directory.GetFiles(path, item.item_code.ToString() + ".*");
                    foreach (string f in files)
                    {
                        System.IO.File.Delete(f);
                    }
                    var fileName = item.item_code.ToString() + System.IO.Path.GetExtension(Request.Form.Files[0].FileName);
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), path, fileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await Request.Form.Files[0].CopyToAsync(fileStream);
                    }
                    item.file_name = fileName;
                }
                item.create_date = DateTime.Now;
                item.create_by = User.Identity.Name; //Program.username;
                item.edit_date = null;
                _context.Add(item);
                await _context.SaveChangesAsync();
                //return RedirectToAction(nameof(Index));
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

            return View(item);
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _context.Item.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }

            var itemType = _context.ItemCategory.Select(s => new { Id = s.Id.ToString(), Name = s.category_name }).ToList();
            itemType.Insert(0, new
            {
                Id = string.Empty,
                Name = "Select Category"
            });

            var queueType = _context.QueueType.Select(s => new { Id = (int?)s.Id, Category = s.category }).ToList();
            queueType.Insert(0, new
            {
                Id = new Nullable<int>(),
                Category = "Select"
            });

            ViewData["ItemCategoryList"] = new SelectList(itemType, "Id", "Name");
            ViewData["QueueTypeList"] = new SelectList(queueType, "Id", "Category");
            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id, item_code, item_name, description, cost, unit, create_by, create_date, edit_by, edit_date, file_name, ItemCategoryId, QueueTypeId")] Item item)
        {
            if (id != item.Id)
            {
                return NotFound();
            }
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            if (ModelState.IsValid)
            {
                try
                {
                    if (Request.Form.Files.Count > 0)
                    {
                        string path = @"wwwroot\images\item";
                        if (!Directory.Exists(path))
                        {
                            Directory.CreateDirectory(path);
                        }
                        string[] files = System.IO.Directory.GetFiles(path, item.item_code.ToString() + ".*");
                        foreach (string f in files)
                        {
                            System.IO.File.Delete(f);
                        }
                        var fileName = item.item_code.ToString() + System.IO.Path.GetExtension(Request.Form.Files[0].FileName);
                        var filePath = Path.Combine(Directory.GetCurrentDirectory(), path, fileName);
                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            await Request.Form.Files[0].CopyToAsync(fileStream);
                        }
                        item.file_name = fileName;
                    }
                    item.edit_date = DateTime.Now;
                    item.edit_by = User.Identity.Name;
                    _context.Update(item);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItemExists(item.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                //return RedirectToAction(nameof(Index));
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
            return View(item);
        }

        public async Task<IActionResult> Details(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var item = await _context.Item
                .Include(e => e.ItemCategory).Include(e => e.QueueType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            return View(item);
        }
        public async Task<IActionResult> Delete(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var item = await _context.Item.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Guid id, [Bind("Id, item_code, item_name, description, cost, unit, create_by, create_date, edit_by, edit_date, file_name, ItemCategoryId, QueueTypeId")] Item item)
        {
            if (id != item.Id)
            {
                return NotFound();
            }
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            if (ModelState.IsValid)
            {
                try
                {
                    var vItem = await _context.Item.FindAsync(item.Id);
                    string path = @"wwwroot\images\item";
                    if (Directory.Exists(path))
                    {
                        string[] files = System.IO.Directory.GetFiles(path, item.item_code.ToString() + ".*");
                        foreach (string f in files)
                        {
                            System.IO.File.Delete(f);
                        }
                    }
                    _context.Item.Remove(vItem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItemExists(item.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                //return RedirectToAction(nameof(Index));
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
            return View(item);
        }

        public async Task<IActionResult> ViewContent(string itemcode, string itemname, string itemcategory, int? cost, int? unit, int? queuetype, string createby, string screatedate, DateTime startcreatedate, DateTime endcreatedate, string editby, string seditdate, DateTime starteditdate, DateTime endeditdate, string clear)
        {
            IQueryable<Item> vItem = (from d in _context.Item.Include(e => e.ItemCategory).Include(e => e.QueueType)
                                      orderby d.create_date ascending
                                      select d);
            setSearchState(false);
            Temp.lSearch.Clear();
            Temp.lSearch.Add(itemcode);
            Temp.lSearch.Add(itemname);
            if (itemcode != null)
            {
                vItem = vItem.Where(d => d.item_code.Contains(itemcode)).AsQueryable();
                setSearchState(true);
            }
            if (itemname != null)
            {
                vItem = vItem.Where(d => d.item_name.Contains(itemname)).AsQueryable();
                setSearchState(true);
            }
            if (itemcategory != null && Guid.Parse(itemcategory) != Guid.Empty)
            {
                vItem = vItem.Where(d => d.ItemCategoryId == Guid.Parse(itemcategory)).AsQueryable();
                setSearchState(true);
                Temp.lSearch.Add(itemcategory.ToString());
            }
            else
            {
                Temp.lSearch.Add(null);
            }
            if (cost != null)
            {
                vItem = vItem.Where(d => d.cost == cost).AsQueryable();
                setSearchState(true);
                Temp.lSearch.Add(cost.ToString());
            }
            else
            {
                Temp.lSearch.Add(null);
            }
            if (unit != null)
            {
                vItem = vItem.Where(d => d.unit == unit).AsQueryable();
                setSearchState(true);
                Temp.lSearch.Add(unit.ToString());
            }
            else
            {
                Temp.lSearch.Add(null);
            }
            if (queuetype != null)
            {
                vItem = vItem.Where(d => d.QueueTypeId == queuetype).AsQueryable();
                setSearchState(true);
                Temp.lSearch.Add(queuetype.ToString());
            }
            else
            {
                Temp.lSearch.Add(null);
            }
            Temp.lSearch.Add(createby);
            if (createby != null)
            {
                vItem = vItem.Where(d => d.create_by.Contains(createby)).AsQueryable();
                setSearchState(true);
            }
            if (screatedate != null && screatedate.Trim() == "y")
            {
                vItem = vItem.Where(d => d.create_date >= startcreatedate.Date && d.create_date < endcreatedate.AddDays(1).Date).AsQueryable();
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
                vItem = vItem.Where(d => d.edit_by.Contains(editby)).AsQueryable();
                setSearchState(true);
            }
            if (seditdate != null && seditdate.Trim() == "y")
            {
                vItem = vItem.Where(d => d.edit_date >= starteditdate.Date && d.edit_date < endeditdate.AddDays(1).Date).AsQueryable();
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

            if (Temp.bSearchState == false)
            {
                Temp.lSearch.Clear();
                Temp.iSearchCount = 0;
                ViewData["createdatestate"] = "n";
                ViewData["editdatestate"] = "n";
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
                ViewData["cost"] = Temp.lSearch[3];
                ViewData["unit"] = Temp.lSearch[4];
                ViewData["queuetype"] = Temp.lSearch[5];
                ViewData["createby"] = Temp.lSearch[6];
                if (Temp.lSearch[7] != null)
                {
                    ViewData["createdatestate"] = "y";
                    ViewData["startcreatedate"] = Convert.ToDateTime(Temp.lSearch[8]).Month.ToString() + "/" + Convert.ToDateTime(Temp.lSearch[8]).Day.ToString() + "/" + Convert.ToDateTime(Temp.lSearch[8]).Year.ToString();
                    ViewData["endcreatedate"] = Convert.ToDateTime(Temp.lSearch[9]).Month.ToString() + "/" + Convert.ToDateTime(Temp.lSearch[9]).Day.ToString() + "/" + Convert.ToDateTime(Temp.lSearch[9]).Year.ToString();
                }
                else
                {
                    ViewData["createdatestate"] = "n";
                }
                ViewData["editby"] = Temp.lSearch[10];
                if (Temp.lSearch[11] != null)
                {
                    ViewData["editdatestate"] = "y";
                    ViewData["starteditdate"] = Convert.ToDateTime(Temp.lSearch[12]).Month.ToString() + "/" + Convert.ToDateTime(Temp.lSearch[12]).Day.ToString() + "/" + Convert.ToDateTime(Temp.lSearch[12]).Year.ToString();
                    ViewData["endeditdate"] = Convert.ToDateTime(Temp.lSearch[13]).Month.ToString() + "/" + Convert.ToDateTime(Temp.lSearch[13]).Day.ToString() + "/" + Convert.ToDateTime(Temp.lSearch[13]).Year.ToString();
                }
                else
                {
                    ViewData["editdatestate"] = "n";
                }
                Temp.iSearchCount += 1;
            }
            var tempData = SetPageNumber(vItem.Count(), Temp.bSearchState, clear);
            vItem = vItem.Skip(tempData.SkipRec).Take(tempData.PerPage);

            var itemType = _context.ItemCategory.Select(s => new { Id = s.Id.ToString(), Name = s.category_name }).ToList();
            itemType.Insert(0, new
            {
                Id = string.Empty,
                Name = "Select Category"
            });

            var queueType = _context.QueueType.Select(s => new { Id = (int?)s.Id, Category = s.category }).ToList();
            queueType.Insert(0, new
            {
                Id = new Nullable<int>(),
                Category = "Select"
            });

            ViewData["Header"] = lHeader;
            ViewData["ItemCategoryList"] = new SelectList(itemType, "Id", "Name");
            ViewData["QueueTypeList"] = new SelectList(queueType, "Id", "Category");
            ViewBag.btn_edit = "Y";
            ViewBag.btn_del = "Y";
            return View(await vItem.ToListAsync());
        }

        [AcceptVerbs("GET", "POST")]
        public async Task<IActionResult> checkItemCode(string item_code)
        {

            var fcus = await _context.Item.FirstOrDefaultAsync(m => m.item_code == item_code);
            if (fcus != null)
            {
                return Json(false);
            }
            else
            {
                return Json(true);
            }
        }

        [AcceptVerbs("GET", "POST")]
        public JsonResult checkItemName(string item_name)
        {
            if ((item_name == null) || (item_name.Trim().Length == 0))
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
            return _context.Item.Any(e => e.Id == id);
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
