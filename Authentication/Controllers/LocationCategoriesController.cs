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
    public class LocationCategoriesController : Controller
    {
        private readonly WMContext _context;
        private string[] lHeader = { "Category Name", "Description", "Create By", "Create Date", "Edit By", "Edit Date" };

        public LocationCategoriesController(WMContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var tempData = SetPageNumber(null, false, null);
            var vLocationCategory = (from d in _context.LocationCategory
                                 orderby d.create_date ascending
                                 select d).Skip(tempData.SkipRec).Take(tempData.PerPage);

            setSearchState(false);
            Temp.lSearch.Clear();
            Temp.iSearchCount = 0;
            ViewData["Header"] = lHeader;
            ViewBag.btn_edit = "Y";
            ViewBag.btn_del = "Y";
            return View(await vLocationCategory.ToListAsync());
        }

        public IActionResult Create()
        {
            var locationType = new LocationCategory();
            locationType.Id = Guid.NewGuid();
            return View(locationType);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id, category_name, description, create_by, create_date, edit_by, edit_date")] LocationCategory locationcategory)
        {
            if (ModelState.IsValid) // Check binding success
            {
                locationcategory.create_date = DateTime.Now;
                locationcategory.create_by = User.Identity.Name; //Program.username;
                locationcategory.edit_date = null;
                _context.Add(locationcategory);
                await _context.SaveChangesAsync();

                //return RedirectToAction(nameof(Index));
                if (Temp.bSearchState == false)
                {
                    return RedirectToAction(nameof(ViewContent));
                }
                else
                {
                    return RedirectToAction("ViewContent", new { locationcategory = Temp.lSearch[0], createby = Temp.lSearch[1], screatedate = Temp.lSearch[2], startcreatedate = Convert.ToDateTime(Temp.lSearch[3]), endcreatedate = Convert.ToDateTime(Temp.lSearch[4]), editby = Temp.lSearch[5], seditdate = Temp.lSearch[6], starteditdate = Convert.ToDateTime(Temp.lSearch[7]), endeditdate = Convert.ToDateTime(Temp.lSearch[8]) });
                }
            }

            return View(locationcategory);
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var locationCategory = await _context.LocationCategory.FindAsync(id);
            if (locationCategory == null)
            {
                return NotFound();
            }

            return View(locationCategory);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id, category_name, description, create_by, create_date, edit_by, edit_date")] LocationCategory locationcategory)
        {
            if (id != locationcategory.Id)
            {
                return NotFound();
            }
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            if (ModelState.IsValid)
            {
                try
                {
                    locationcategory.edit_date = DateTime.Now;
                    locationcategory.edit_by = User.Identity.Name;
                    _context.Update(locationcategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LocationCategoryExists(locationcategory.Id))
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
                    return RedirectToAction("ViewContent", new { locationcategory = Temp.lSearch[0], createby = Temp.lSearch[1], screatedate = Temp.lSearch[2], startcreatedate = Convert.ToDateTime(Temp.lSearch[3]), endcreatedate = Convert.ToDateTime(Temp.lSearch[4]), editby = Temp.lSearch[5], seditdate = Temp.lSearch[6], starteditdate = Convert.ToDateTime(Temp.lSearch[7]), endeditdate = Convert.ToDateTime(Temp.lSearch[8]) });
                }
            }
            return View(locationcategory);
        }

        public async Task<IActionResult> Details(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var vLocationType = (from d in _context.LocationCategory
                             orderby d.Id ascending
                             select d);
            var locationType = await _context.LocationCategory
                .FirstOrDefaultAsync(m => m.Id == id);
            if (locationType == null)
            {
                return NotFound();
            }
            return View(locationType);
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var locationCategory = await _context.LocationCategory.FindAsync(id);
            if (locationCategory == null)
            {
                return NotFound();
            }

            return View(locationCategory);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Guid id, [Bind("Id, category_name, description, create_by, create_date, edit_by, edit_date")] LocationCategory locationcategory)
        {
            if (id != locationcategory.Id)
            {
                return NotFound();
            }
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            if (ModelState.IsValid)
            {
                try
                {
                    var locationType = await _context.LocationCategory.FindAsync(locationcategory.Id);
                    _context.LocationCategory.Remove(locationType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LocationCategoryExists(locationcategory.Id))
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
                    return RedirectToAction("ViewContent", new { locationcategory = Temp.lSearch[0], createby = Temp.lSearch[1], screatedate = Temp.lSearch[2], startcreatedate = Convert.ToDateTime(Temp.lSearch[3]), endcreatedate = Convert.ToDateTime(Temp.lSearch[4]), editby = Temp.lSearch[5], seditdate = Temp.lSearch[6], starteditdate = Convert.ToDateTime(Temp.lSearch[7]), endeditdate = Convert.ToDateTime(Temp.lSearch[8]) });
                }
            }
            return View(locationcategory);
        }

        public async Task<IActionResult> ViewContent(string locationcategory, string createby, string screatedate, DateTime startcreatedate, DateTime endcreatedate, string editby, string seditdate, DateTime starteditdate, DateTime endeditdate, string clear)
        {
            IQueryable<LocationCategory> vLocationType = (from d in _context.LocationCategory
                                                  orderby d.create_date ascending
                                                  select d);
            setSearchState(false);
            Temp.lSearch.Clear();
            Temp.lSearch.Add(locationcategory);
            Temp.lSearch.Add(createby);
            if (locationcategory != null)
            {
                vLocationType = vLocationType.Where(d => d.category_name.Contains(locationcategory)).AsQueryable();
                setSearchState(true);
            }
            if (createby != null)
            {
                vLocationType = vLocationType.Where(d => d.create_by.Contains(createby)).AsQueryable();
                setSearchState(true);
            }
            if (editby != null)
            {
                vLocationType = vLocationType.Where(d => d.edit_by.Contains(editby)).AsQueryable();
                setSearchState(true);
            }
            if (screatedate != null && screatedate.Trim() == "y")
            {
                vLocationType = vLocationType.Where(d => d.create_date >= startcreatedate.Date && d.create_date < endcreatedate.AddDays(1).Date).AsQueryable();
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
                vLocationType = vLocationType.Where(d => d.edit_date >= starteditdate.Date && d.edit_date < endeditdate.AddDays(1).Date).AsQueryable();
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
                ViewData["locationcategory"] = Temp.lSearch[0];
                ViewData["createby"] = Temp.lSearch[1];
                if (Temp.lSearch[2] != null)
                {
                    ViewData["createdatestate"] = "y";
                    ViewData["startcreatedate"] = Convert.ToDateTime(Temp.lSearch[3]).Month.ToString() + "/" + Convert.ToDateTime(Temp.lSearch[3]).Day.ToString() + "/" + Convert.ToDateTime(Temp.lSearch[3]).Year.ToString();
                    ViewData["endcreatedate"] = Convert.ToDateTime(Temp.lSearch[4]).Month.ToString() + "/" + Convert.ToDateTime(Temp.lSearch[4]).Day.ToString() + "/" + Convert.ToDateTime(Temp.lSearch[4]).Year.ToString();
                }
                else
                {
                    ViewData["createdatestate"] = "n";
                }
                ViewData["editby"] = Temp.lSearch[5];
                if (Temp.lSearch[6] != null)
                {
                    ViewData["editdatestate"] = "y";
                    ViewData["starteditdate"] = Convert.ToDateTime(Temp.lSearch[7]).Month.ToString() + "/" + Convert.ToDateTime(Temp.lSearch[7]).Day.ToString() + "/" + Convert.ToDateTime(Temp.lSearch[7]).Year.ToString();
                    ViewData["endeditdate"] = Convert.ToDateTime(Temp.lSearch[8]).Month.ToString() + "/" + Convert.ToDateTime(Temp.lSearch[8]).Day.ToString() + "/" + Convert.ToDateTime(Temp.lSearch[8]).Year.ToString();
                }
                else
                {
                    ViewData["editdatestate"] = "n";
                }
                Temp.iSearchCount += 1;
            }
            var tempData = SetPageNumber(vLocationType.Count(), Temp.bSearchState, clear);
            vLocationType = vLocationType.Skip(tempData.SkipRec).Take(tempData.PerPage);

            ViewData["Header"] = lHeader;
            ViewBag.btn_edit = "Y";
            ViewBag.btn_del = "Y";
            return View(await vLocationType.ToListAsync());
        }

        [AcceptVerbs("GET", "POST")]
        public JsonResult checkLocationCategory(string category_name)
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

        private bool LocationCategoryExists(Guid id)
        {
            return _context.LocationCategory.Any(e => e.Id == id);
        }

        private void setSearchState(bool state)
        {
            Temp.bSearchState = state;
        }

        private ManagePageNumber SetPageNumber(int? total, bool searchState, string sClear)
        {
            ManagePageNumber temp = new ManagePageNumber();

            temp.PerPage = HttpContext.Session.GetInt32("LCPerPage") ?? 20;

            if (searchState == true)
            {
                if (Temp.iSearchCount == 1)
                {
                    HttpContext.Session.SetInt32("LCPageNo", 1);
                    temp.PageNo = 1;
                }
                else
                {
                    temp.PageNo = HttpContext.Session.GetInt32("LCPageNo") ?? 1;
                }
                temp.TotalRec = (int)total;
            }
            else
            {
                if (sClear != null)
                {
                    HttpContext.Session.SetInt32("LCPageNo", 1);
                    temp.PageNo = 1;
                }
                else
                {
                    temp.PageNo = HttpContext.Session.GetInt32("LCPageNo") ?? 1;
                }
                temp.TotalRec = _context.LocationCategory.Count();
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

            HttpContext.Session.SetInt32("LCPerPage", vPage);
            if (Temp.bSearchState == false)
            {
                return RedirectToAction(nameof(ViewContent));
            }
            else
            {
                return RedirectToAction("ViewContent", new { locationcategory = Temp.lSearch[0], createby = Temp.lSearch[1], screatedate = Temp.lSearch[2], startcreatedate = Convert.ToDateTime(Temp.lSearch[3]), endcreatedate = Convert.ToDateTime(Temp.lSearch[4]), editby = Temp.lSearch[5], seditdate = Temp.lSearch[6], starteditdate = Convert.ToDateTime(Temp.lSearch[7]), endeditdate = Convert.ToDateTime(Temp.lSearch[8]) });
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
            HttpContext.Session.SetInt32("LCPageNo", vPageNo);
            if (Temp.bSearchState == false)
            {
                return RedirectToAction(nameof(ViewContent));
            }
            else
            {
                return RedirectToAction("ViewContent", new { locationcategory = Temp.lSearch[0], createby = Temp.lSearch[1], screatedate = Temp.lSearch[2], startcreatedate = Convert.ToDateTime(Temp.lSearch[3]), endcreatedate = Convert.ToDateTime(Temp.lSearch[4]), editby = Temp.lSearch[5], seditdate = Temp.lSearch[6], starteditdate = Convert.ToDateTime(Temp.lSearch[7]), endeditdate = Convert.ToDateTime(Temp.lSearch[8]) });
            }
        }
    }
}
