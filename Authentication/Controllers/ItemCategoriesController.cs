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
namespace Authentication.Controllers
{
    [Authorize]
    public class ItemCategoriesController : Controller
    {
        private readonly WMContext _context;
        private string[] lHeader = { "Category Name", "Description", "Active", "Create By", "Create Date", "Edit By", "Edit Date" };
        public ItemCategoriesController(WMContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var tempData = SetPageNumber(null, false, null);
            var vItemCategory = (from d in _context.ItemCategory
                                 orderby d.create_date ascending
                                 select d).Skip(tempData.SkipRec).Take(tempData.PerPage);

            setSearchState(false);
            Temp.lSearch.Clear();
            Temp.iSearchCount = 0;
            ViewData["Header"] = lHeader;
            ViewBag.btn_edit = "Y";
            ViewBag.btn_del = "Y";
            return View(await vItemCategory.ToListAsync());
        }

        public IActionResult Create()
        {
            var itemType = new ItemCategory();
            itemType.Id = Guid.NewGuid();
            itemType.active = true;
            return View(itemType);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id, category_name, description, active, create_by, create_date, edit_by, edit_date")] ItemCategory itemcategory)
        {
            if (ModelState.IsValid) // Check binding success
            {
                itemcategory.create_date = DateTime.Now;
                itemcategory.create_by = User.Identity.Name; //Program.username;
                itemcategory.edit_date = null;
                _context.Add(itemcategory);
                await _context.SaveChangesAsync();

                //return RedirectToAction(nameof(Index));
                if (Temp.bSearchState == false)
                {
                    return RedirectToAction(nameof(ViewContent));
                }
                else
                {
                    int? iActive = null;
                    if (Temp.lSearch[1] != null)
                    {
                        iActive = int.Parse(Temp.lSearch[1]);
                    }
                    return RedirectToAction("ViewContent", new { itemcategory = Temp.lSearch[0], active = iActive, createby = Temp.lSearch[2], screatedate = Temp.lSearch[3], startcreatedate = Convert.ToDateTime(Temp.lSearch[4]), endcreatedate = Convert.ToDateTime(Temp.lSearch[5]), editby = Temp.lSearch[6], seditdate = Temp.lSearch[7], starteditdate = Convert.ToDateTime(Temp.lSearch[8]), endeditdate = Convert.ToDateTime(Temp.lSearch[9]) });
                }
            }

            return View(itemcategory);
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itemCategory = await _context.ItemCategory.FindAsync(id);
            if (itemCategory == null)
            {
                return NotFound();
            }

            return View(itemCategory);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id, category_name, description, active, create_by, create_date, edit_by, edit_date")] ItemCategory itemcategory)
        {
            if (id != itemcategory.Id)
            {
                return NotFound();
            }
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            if (ModelState.IsValid)
            {
                try
                {
                    itemcategory.edit_date = DateTime.Now;
                    itemcategory.edit_by = User.Identity.Name;
                    _context.Update(itemcategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItemCategoryExists(itemcategory.Id))
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
                    int? iActive = null;
                    if (Temp.lSearch[1] != null)
                    {
                        iActive = int.Parse(Temp.lSearch[1]);
                    }
                    return RedirectToAction("ViewContent", new { itemcategory = Temp.lSearch[0], active = iActive, createby = Temp.lSearch[2], screatedate = Temp.lSearch[3], startcreatedate = Convert.ToDateTime(Temp.lSearch[4]), endcreatedate = Convert.ToDateTime(Temp.lSearch[5]), editby = Temp.lSearch[6], seditdate = Temp.lSearch[7], starteditdate = Convert.ToDateTime(Temp.lSearch[8]), endeditdate = Convert.ToDateTime(Temp.lSearch[9]) });
                }
            }
            return View(itemcategory);
        }

        public async Task<IActionResult> Details(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var vItemType = (from d in _context.ItemCategory
                             orderby d.Id ascending
                             select d);
            var itemType = await _context.ItemCategory
                .FirstOrDefaultAsync(m => m.Id == id);
            if (itemType == null)
            {
                return NotFound();
            }
            return View(itemType);
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var itemCategory = await _context.ItemCategory.FindAsync(id);
            if (itemCategory == null)
            {
                return NotFound();
            }

            return View(itemCategory);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Guid id, [Bind("Id, category_name, description, active, create_by, create_date, edit_by, edit_date")] ItemCategory itemcategory)
        {
            if (id != itemcategory.Id)
            {
                return NotFound();
            }
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            if (ModelState.IsValid)
            {
                try
                {
                    var itemCategory = await _context.ItemCategory.FindAsync(itemcategory.Id);
                    _context.ItemCategory.Remove(itemCategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItemCategoryExists(itemcategory.Id))
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
                    int? iActive = null;
                    if (Temp.lSearch[1] != null)
                    {
                        iActive = int.Parse(Temp.lSearch[1]);
                    }
                    return RedirectToAction("ViewContent", new { itemcategory = Temp.lSearch[0], active = iActive, createby = Temp.lSearch[2], screatedate = Temp.lSearch[3], startcreatedate = Convert.ToDateTime(Temp.lSearch[4]), endcreatedate = Convert.ToDateTime(Temp.lSearch[5]), editby = Temp.lSearch[6], seditdate = Temp.lSearch[7], starteditdate = Convert.ToDateTime(Temp.lSearch[8]), endeditdate = Convert.ToDateTime(Temp.lSearch[9]) });
                }
            }
            return View(itemcategory);
        }

        public async Task<IActionResult> ViewContent(string itemcategory, int? active, string createby, string screatedate, DateTime startcreatedate, DateTime endcreatedate, string editby, string seditdate, DateTime starteditdate, DateTime endeditdate, string clear)
        {
            IQueryable<ItemCategory> vItemType = (from d in _context.ItemCategory
                                                  orderby d.create_date ascending
                                              select d); ;
            setSearchState(false);
            Temp.lSearch.Clear();
            Temp.lSearch.Add(itemcategory);
            if (itemcategory != null)
            {
                vItemType = vItemType.Where(d => d.category_name.Contains(itemcategory)).AsQueryable();
                setSearchState(true);
            }
            if (active != null)
            {
                if (active == 1)
                {
                    vItemType = vItemType.Where(d => d.active == true).AsQueryable();
                    setSearchState(true);
                    Temp.lSearch.Add(active.ToString());
                }
                else
                {
                    vItemType = vItemType.Where(d => d.active == false).AsQueryable();
                    setSearchState(true);
                    Temp.lSearch.Add(active.ToString());
                }
            }
            else
            {
                Temp.lSearch.Add(null);
            }
            Temp.lSearch.Add(createby);
            if (createby != null)
            {
                vItemType = vItemType.Where(d => d.create_by.Contains(createby)).AsQueryable();
                setSearchState(true);
            }
            if (editby != null)
            {
                vItemType = vItemType.Where(d => d.edit_by.Contains(editby)).AsQueryable();
                setSearchState(true);
            }
            if (screatedate != null && screatedate.Trim() == "y")
            {
                vItemType = vItemType.Where(d => d.create_date >= startcreatedate.Date && d.create_date < endcreatedate.AddDays(1).Date).AsQueryable();
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
            if (seditdate != null && seditdate.Trim() == "y")
            {
                vItemType = vItemType.Where(d => d.edit_date >= starteditdate.Date && d.edit_date < endeditdate.AddDays(1).Date).AsQueryable();
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
                ViewData["active"] = "Select";
            }
            else
            {
                ViewData["itemcategory"] = Temp.lSearch[0];
                if (Temp.lSearch[1] == null)
                {
                    ViewData["active"] = "Select";
                }
                else
                {
                    ViewData["active"] = Temp.lSearch[1];
                }
                ViewData["createby"] = Temp.lSearch[2];
                if (Temp.lSearch[3] != null)
                {
                    ViewData["createdatestate"] = "y";
                    ViewData["startcreatedate"] = Convert.ToDateTime(Temp.lSearch[4]).Month.ToString() + "/" + Convert.ToDateTime(Temp.lSearch[4]).Day.ToString() + "/" + Convert.ToDateTime(Temp.lSearch[4]).Year.ToString();
                    ViewData["endcreatedate"] = Convert.ToDateTime(Temp.lSearch[5]).Month.ToString() + "/" + Convert.ToDateTime(Temp.lSearch[5]).Day.ToString() + "/" + Convert.ToDateTime(Temp.lSearch[5]).Year.ToString();
                }
                else
                {
                    ViewData["createdatestate"] = "n";
                }
                ViewData["editby"] = Temp.lSearch[6];
                if (Temp.lSearch[7] != null)
                {
                    ViewData["editdatestate"] = "y";
                    ViewData["starteditdate"] = Convert.ToDateTime(Temp.lSearch[8]).Month.ToString() + "/" + Convert.ToDateTime(Temp.lSearch[8]).Day.ToString() + "/" + Convert.ToDateTime(Temp.lSearch[8]).Year.ToString();
                    ViewData["endeditdate"] = Convert.ToDateTime(Temp.lSearch[9]).Month.ToString() + "/" + Convert.ToDateTime(Temp.lSearch[9]).Day.ToString() + "/" + Convert.ToDateTime(Temp.lSearch[9]).Year.ToString();
                }
                else
                {
                    ViewData["editdatestate"] = "n";
                }
                Temp.iSearchCount += 1;
            }
            var tempData = SetPageNumber(vItemType.Count(), Temp.bSearchState, clear);
            vItemType = vItemType.Skip(tempData.SkipRec).Take(tempData.PerPage);
            ViewData["Header"] = lHeader;
            ViewBag.btn_edit = "Y";
            ViewBag.btn_del = "Y";
            return View(await vItemType.ToListAsync());
        }

        [AcceptVerbs("GET", "POST")]
        public JsonResult checkItemCategory(string category_name)
        {
            if ((category_name == null) || (category_name.Trim().Length == 0))
            {
                return Json(false);
            }
            else
            {
                return Json(true);
            }
        }

        private bool ItemCategoryExists(Guid id)
        {
            return _context.ItemCategory.Any(e => e.Id == id);
        }

        private void setSearchState(bool state)
        {
            Temp.bSearchState = state;
        }

        private ManagePageNumber SetPageNumber(int? total, bool searchState, string sClear)
        {
            ManagePageNumber temp = new ManagePageNumber();

            temp.PerPage = HttpContext.Session.GetInt32("ICPerPage") ?? 20;

            if (searchState == true)
            {
                if (Temp.iSearchCount == 1)
                {
                    HttpContext.Session.SetInt32("ICPageNo", 1);
                    temp.PageNo = 1;
                }
                else
                {
                    temp.PageNo = HttpContext.Session.GetInt32("ICPageNo") ?? 1;
                }
                temp.TotalRec = (int)total;
            }
            else
            {
                if (sClear != null)
                {
                    HttpContext.Session.SetInt32("ICPageNo", 1);
                    temp.PageNo = 1;
                }
                else
                {
                    temp.PageNo = HttpContext.Session.GetInt32("ICPageNo") ?? 1;
                }
                temp.TotalRec = _context.ItemCategory.Count();
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

            HttpContext.Session.SetInt32("ICPerPage", vPage);
            if (Temp.bSearchState == false)
            {
                return RedirectToAction(nameof(ViewContent));
            }
            else
            {
                int? iActive = null;
                if (Temp.lSearch[1] != null)
                {
                    iActive = int.Parse(Temp.lSearch[1]);
                }
                return RedirectToAction("ViewContent", new { itemcategory = Temp.lSearch[0], active = iActive, createby = Temp.lSearch[2], screatedate = Temp.lSearch[3], startcreatedate = Convert.ToDateTime(Temp.lSearch[4]), endcreatedate = Convert.ToDateTime(Temp.lSearch[5]), editby = Temp.lSearch[6], seditdate = Temp.lSearch[7], starteditdate = Convert.ToDateTime(Temp.lSearch[8]), endeditdate = Convert.ToDateTime(Temp.lSearch[9]) });
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
            HttpContext.Session.SetInt32("ICPageNo", vPageNo);
            if (Temp.bSearchState == false)
            {
                return RedirectToAction(nameof(ViewContent));
            }
            else
            {
                int? iActive = null;
                if (Temp.lSearch[1] != null)
                {
                    iActive = int.Parse(Temp.lSearch[1]);
                }
                return RedirectToAction("ViewContent", new { itemcategory = Temp.lSearch[0], active = iActive, createby = Temp.lSearch[2], screatedate = Temp.lSearch[3], startcreatedate = Convert.ToDateTime(Temp.lSearch[4]), endcreatedate = Convert.ToDateTime(Temp.lSearch[5]), editby = Temp.lSearch[6], seditdate = Temp.lSearch[7], starteditdate = Convert.ToDateTime(Temp.lSearch[8]), endeditdate = Convert.ToDateTime(Temp.lSearch[9]) });
            }
        }
    }
}
