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
    public class LocationsController : Controller
    {
        private readonly WMContext _context;
        private string[] lHeader = { "Location Code", "Location Category", "Description", "Mix Item", "Mix Expire", "Mix Lot", "Create By", "Create Date", "Edit By", "Edit Date" };

        public LocationsController(WMContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var tempData = SetPageNumber(null, false, null);
            var vLocation = (from d in _context.Location.Include(e => e.LocationCategory)
                             orderby d.create_date ascending
                             select d).Skip(tempData.SkipRec).Take(tempData.PerPage);
            var locationCategory = _context.LocationCategory.Select(s => new { Id = s.Id.ToString(), Name = s.category_name }).ToList();
            locationCategory.Insert(0, new
            {
                Id = string.Empty,
                Name = "Select Category"
            });

            setSearchState(false);
            Temp.lSearch.Clear();
            Temp.iSearchCount = 0;
            ViewData["Header"] = lHeader;
            ViewData["LocationCategoryList"] = new SelectList(locationCategory, "Id", "Name");
            ViewBag.btn_edit = "Y";
            ViewBag.btn_del = "Y";
            return View(await vLocation.ToListAsync());
        }

        public IActionResult Create()
        {
            var location = new Location();
            location.Id = Guid.NewGuid();
            var locationCategory = _context.LocationCategory.Select(s => new { Id = s.Id.ToString(), Name = s.category_name }).ToList();
            locationCategory.Insert(0, new
            {
                Id = string.Empty,
                Name = "Select Category"
            });
            ViewData["LocationCategoryList"] = new SelectList(locationCategory, "Id", "Name");
            return View(location);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id, location_code, description, mix_expire, mix_item, mix_lot, create_by, create_date, edit_by, edit_date, LocationCategoryId")] Location location)
        {
            if (ModelState.IsValid) // Check binding success
            {
                var fcus = await _context.Location.FirstOrDefaultAsync(m => m.location_code == location.location_code);
                if (fcus != null)
                {
                    return NotFound();
                }
                location.create_date = DateTime.Now;
                location.create_by = User.Identity.Name; //Program.username;
                location.edit_date = null;
                _context.Add(location);
                await _context.SaveChangesAsync();
                //return RedirectToAction(nameof(Index));
                if (Temp.bSearchState == false)
                {
                    return RedirectToAction(nameof(ViewContent));
                }
                else
                {
                    string sLocationCategory = Guid.Empty.ToString();
                    if (Temp.lSearch[1] != null)
                    {
                        sLocationCategory = Temp.lSearch[1];
                    }
                    int? iMixexpire = null;
                    if (Temp.lSearch[2] != null)
                    {
                        iMixexpire = int.Parse(Temp.lSearch[2]);
                    }
                    int? iMixitem = null;
                    if (Temp.lSearch[3] != null)
                    {
                        iMixitem = int.Parse(Temp.lSearch[3]);
                    }
                    int? iMixlot = null;
                    if (Temp.lSearch[4] != null)
                    {
                        iMixlot = int.Parse(Temp.lSearch[4]);
                    }
                    return RedirectToAction("ViewContent", new { locationcode = Temp.lSearch[0], locationcategory = sLocationCategory, mixexpire = iMixexpire, mixitem = iMixitem, mixlot = iMixlot, createby = Temp.lSearch[5], screatedate = Temp.lSearch[6], startcreatedate = Convert.ToDateTime(Temp.lSearch[7]), endcreatedate = Convert.ToDateTime(Temp.lSearch[8]), editby = Temp.lSearch[9], seditdate = Temp.lSearch[10], starteditdate = Convert.ToDateTime(Temp.lSearch[11]), endeditdate = Convert.ToDateTime(Temp.lSearch[12]) });
                }
            }

            return View(location);
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var location = await _context.Location.FindAsync(id);
            if (location == null)
            {
                return NotFound();
            }

            var locationCategory = _context.LocationCategory.Select(s => new { Id = s.Id.ToString(), Name = s.category_name }).ToList();
            locationCategory.Insert(0, new
            {
                Id = string.Empty,
                Name = "Select Category"
            });

            ViewData["LocationCategoryList"] = new SelectList(locationCategory, "Id", "Name");
            return View(location);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id, location_code, description, mix_expire, mix_item, mix_lot, create_by, create_date, edit_by, edit_date, LocationCategoryId")] Location location)
        {
            if (id != location.Id)
            {
                return NotFound();
            }
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            if (ModelState.IsValid)
            {
                try
                {
                    location.edit_date = DateTime.Now;
                    location.edit_by = User.Identity.Name;
                    _context.Update(location);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LocationExists(location.Id))
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
                    string sLocationCategory = Guid.Empty.ToString();
                    if (Temp.lSearch[1] != null)
                    {
                        sLocationCategory = Temp.lSearch[1];
                    }
                    int? iMixexpire = null;
                    if (Temp.lSearch[2] != null)
                    {
                        iMixexpire = int.Parse(Temp.lSearch[2]);
                    }
                    int? iMixitem = null;
                    if (Temp.lSearch[3] != null)
                    {
                        iMixitem = int.Parse(Temp.lSearch[3]);
                    }
                    int? iMixlot = null;
                    if (Temp.lSearch[4] != null)
                    {
                        iMixlot = int.Parse(Temp.lSearch[4]);
                    }
                    return RedirectToAction("ViewContent", new { locationcode = Temp.lSearch[0], locationcategory = sLocationCategory, mixexpire = iMixexpire, mixitem = iMixitem, mixlot = iMixlot, createby = Temp.lSearch[5], screatedate = Temp.lSearch[6], startcreatedate = Convert.ToDateTime(Temp.lSearch[7]), endcreatedate = Convert.ToDateTime(Temp.lSearch[8]), editby = Temp.lSearch[9], seditdate = Temp.lSearch[10], starteditdate = Convert.ToDateTime(Temp.lSearch[11]), endeditdate = Convert.ToDateTime(Temp.lSearch[12]) });
                }
            }
            return View(location);
        }

        public async Task<IActionResult> Details(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var vLocation = (from d in _context.Location.Include(e => e.LocationCategory)
                             orderby d.Id ascending
                             select d);
            var location = await _context.Location
                .Include(e => e.LocationCategory)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (location == null)
            {
                return NotFound();
            }
            return View(location);
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var location = await _context.Location.FindAsync(id);
            if (location == null)
            {
                return NotFound();
            }

            return View(location);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Guid id, [Bind("Id, location_code, description, mix_expire, mix_item, mix_lot, create_by, create_date, edit_by, edit_date, LocationCategoryId")] Location location)
        {
            if (id != location.Id)
            {
                return NotFound();
            }
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            if (ModelState.IsValid)
            {
                try
                {
                    var vLocation = await _context.Location.FindAsync(location.Id);
                    _context.Location.Remove(vLocation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LocationExists(location.Id))
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
                    string sLocationCategory = Guid.Empty.ToString();
                    if (Temp.lSearch[1] != null)
                    {
                        sLocationCategory = Temp.lSearch[1];
                    }
                    int? iMixexpire = null;
                    if (Temp.lSearch[2] != null)
                    {
                        iMixexpire = int.Parse(Temp.lSearch[2]);
                    }
                    int? iMixitem = null;
                    if (Temp.lSearch[3] != null)
                    {
                        iMixitem = int.Parse(Temp.lSearch[3]);
                    }
                    int? iMixlot = null;
                    if (Temp.lSearch[4] != null)
                    {
                        iMixlot = int.Parse(Temp.lSearch[4]);
                    }
                    return RedirectToAction("ViewContent", new { locationcode = Temp.lSearch[0], locationcategory = sLocationCategory, mixexpire = iMixexpire, mixitem = iMixitem, mixlot = iMixlot, createby = Temp.lSearch[5], screatedate = Temp.lSearch[6], startcreatedate = Convert.ToDateTime(Temp.lSearch[7]), endcreatedate = Convert.ToDateTime(Temp.lSearch[8]), editby = Temp.lSearch[9], seditdate = Temp.lSearch[10], starteditdate = Convert.ToDateTime(Temp.lSearch[11]), endeditdate = Convert.ToDateTime(Temp.lSearch[12]) });
                }
            }
            return View(location);
        }

        public async Task<IActionResult> ViewContent(string locationcode, string locationcategory, int? mixexpire, int? mixitem, int? mixlot, string createby, string screatedate, DateTime startcreatedate, DateTime endcreatedate, string editby, string seditdate, DateTime starteditdate, DateTime endeditdate, string clear)
        {
            IQueryable<Location> vLocation = (from d in _context.Location.Include(e => e.LocationCategory)
                                              orderby d.create_date ascending
                                              select d);
            setSearchState(false);
            Temp.lSearch.Clear();
            Temp.lSearch.Add(locationcode);
            if (locationcode != null)
            {
                vLocation = vLocation.Where(d => d.location_code.Contains(locationcode)).AsQueryable();
                setSearchState(true);
            }
            if (locationcategory != null && Guid.Parse(locationcategory) != Guid.Empty)
            {
                vLocation = vLocation.Where(d => d.LocationCategoryId == Guid.Parse(locationcategory)).AsQueryable();
                setSearchState(true);
                Temp.lSearch.Add(locationcategory.ToString());
            }
            else
            {
                Temp.lSearch.Add(null);
            }
            if (mixexpire != null)
            {
                if (mixexpire == 1)
                {
                    vLocation = vLocation.Where(d => d.mix_expire == true).AsQueryable();
                    setSearchState(true);
                    Temp.lSearch.Add(mixexpire.ToString());
                }
                else
                {
                    vLocation = vLocation.Where(d => d.mix_expire == false).AsQueryable();
                    setSearchState(true);
                    Temp.lSearch.Add(mixexpire.ToString());
                }
            }
            else
            {
                Temp.lSearch.Add(null);
            }
            if (mixitem != null)
            {
                if (mixitem == 1)
                {
                    vLocation = vLocation.Where(d => d.mix_item == true).AsQueryable();
                    setSearchState(true);
                    Temp.lSearch.Add(mixitem.ToString());
                }
                else
                {
                    vLocation = vLocation.Where(d => d.mix_item == false).AsQueryable();
                    setSearchState(true);
                    Temp.lSearch.Add(mixitem.ToString());
                }
            }
            else
            {
                Temp.lSearch.Add(null);
            }
            if (mixlot != null)
            {
                if (mixlot == 1)
                {
                    vLocation = vLocation.Where(d => d.mix_lot == true).AsQueryable();
                    setSearchState(true);
                    Temp.lSearch.Add(mixlot.ToString());
                }
                else
                {
                    vLocation = vLocation.Where(d => d.mix_lot == false).AsQueryable();
                    setSearchState(true);
                    Temp.lSearch.Add(mixlot.ToString());
                }
            }
            else
            {
                Temp.lSearch.Add(null);
            }
            Temp.lSearch.Add(createby);
            if (createby != null)
            {
                vLocation = vLocation.Where(d => d.create_by.Contains(createby)).AsQueryable();
                setSearchState(true);
            }
            if (screatedate != null && screatedate.Trim() == "y")
            {
                vLocation = vLocation.Where(d => d.create_date >= startcreatedate.Date && d.create_date < endcreatedate.AddDays(1).Date).AsQueryable();
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
                vLocation = vLocation.Where(d => d.edit_by.Contains(editby)).AsQueryable();
                setSearchState(true);
            }
            if (seditdate != null && seditdate.Trim() == "y")
            {
                vLocation = vLocation.Where(d => d.edit_date >= starteditdate.Date && d.edit_date < endeditdate.AddDays(1).Date).AsQueryable();
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
                ViewData["mixexpire"] = "Select";
                ViewData["mixitem"] = "Select";
                ViewData["mixlot"] = "Select";
            }
            else
            {
                ViewData["locationcode"] = Temp.lSearch[0];
                ViewData["locationcategory"] = Temp.lSearch[1];
                if (Temp.lSearch[2] == null)
                {
                    ViewData["mixexpire"] = "Select";
                }
                else
                {
                    ViewData["mixexpire"] = Temp.lSearch[2];
                }
                if (Temp.lSearch[3] == null)
                {
                    ViewData["mixitem"] = "Select";
                }
                else
                {
                    ViewData["mixitem"] = Temp.lSearch[3];
                }
                if (Temp.lSearch[4] == null)
                {
                    ViewData["mixlot"] = "Select";
                }
                else
                {
                    ViewData["mixlot"] = Temp.lSearch[4];
                }
                ViewData["createby"] = Temp.lSearch[5];
                if (Temp.lSearch[6] != null)
                {
                    ViewData["createdatestate"] = "y";
                    ViewData["startcreatedate"] = Convert.ToDateTime(Temp.lSearch[7]).Month.ToString() + "/" + Convert.ToDateTime(Temp.lSearch[7]).Day.ToString() + "/" + Convert.ToDateTime(Temp.lSearch[7]).Year.ToString();
                    ViewData["endcreatedate"] = Convert.ToDateTime(Temp.lSearch[8]).Month.ToString() + "/" + Convert.ToDateTime(Temp.lSearch[8]).Day.ToString() + "/" + Convert.ToDateTime(Temp.lSearch[8]).Year.ToString();
                }
                else
                {
                    ViewData["createdatestate"] = "n";
                }
                ViewData["editby"] = Temp.lSearch[9];
                if (Temp.lSearch[10] != null)
                {
                    ViewData["editdatestate"] = "y";
                    ViewData["starteditdate"] = Convert.ToDateTime(Temp.lSearch[11]).Month.ToString() + "/" + Convert.ToDateTime(Temp.lSearch[11]).Day.ToString() + "/" + Convert.ToDateTime(Temp.lSearch[11]).Year.ToString();
                    ViewData["endeditdate"] = Convert.ToDateTime(Temp.lSearch[12]).Month.ToString() + "/" + Convert.ToDateTime(Temp.lSearch[12]).Day.ToString() + "/" + Convert.ToDateTime(Temp.lSearch[12]).Year.ToString();
                }
                else
                {
                    ViewData["editdatestate"] = "n";
                }
                Temp.iSearchCount += 1;
            }
            var tempData = SetPageNumber(vLocation.Count(), Temp.bSearchState, clear);
            vLocation = vLocation.Skip(tempData.SkipRec).Take(tempData.PerPage);

            var locationType = _context.LocationCategory.Select(s => new { Id = s.Id.ToString(), Name = s.category_name }).ToList();
            locationType.Insert(0, new
            {
                Id = string.Empty,
                Name = "Select Category"
            });

            ViewData["Header"] = lHeader;
            ViewData["LocationCategoryList"] = new SelectList(locationType, "Id", "Name");
            ViewData["Header"] = lHeader;
            ViewBag.btn_edit = "Y";
            ViewBag.btn_del = "Y";
            return View(await vLocation.ToListAsync());
        }

        [AcceptVerbs("GET", "POST")]
        public async Task<IActionResult> checkLocationCode(string location_code)
        {

            var fcus = await _context.Location.FirstOrDefaultAsync(m => m.location_code == location_code);
            if (fcus != null)
            {
                return Json(false);
            }
            else
            {
                return Json(true);
            }
        }

        private bool LocationExists(Guid id)
        {
            return _context.Location.Any(e => e.Id == id);
        }

        private void setSearchState(bool state)
        {
            Temp.bSearchState = state;
        }

        private ManagePageNumber SetPageNumber(int? total, bool searchState, string sClear)
        {
            ManagePageNumber temp = new ManagePageNumber();

            temp.PerPage = HttpContext.Session.GetInt32("LPerPage") ?? 20;

            if (searchState == true)
            {
                if (Temp.iSearchCount == 1)
                {
                    HttpContext.Session.SetInt32("LPageNo", 1);
                    temp.PageNo = 1;
                }
                else
                {
                    temp.PageNo = HttpContext.Session.GetInt32("LPageNo") ?? 1;
                }
                temp.TotalRec = (int)total;
            }
            else
            {
                if (sClear != null)
                {
                    HttpContext.Session.SetInt32("LPageNo", 1);
                    temp.PageNo = 1;
                }
                else
                {
                    temp.PageNo = HttpContext.Session.GetInt32("LPageNo") ?? 1;
                }
                temp.TotalRec = _context.Location.Count();
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

            HttpContext.Session.SetInt32("LPerPage", vPage);
            if (Temp.bSearchState == false)
            {
                return RedirectToAction(nameof(ViewContent));
            }
            else
            {
                string sLocationCategory = Guid.Empty.ToString();
                if (Temp.lSearch[1] != null)
                {
                    sLocationCategory = Temp.lSearch[1];
                }
                int? iMixexpire = null;
                if (Temp.lSearch[2] != null)
                {
                    iMixexpire = int.Parse(Temp.lSearch[2]);
                }
                int? iMixitem = null;
                if (Temp.lSearch[3] != null)
                {
                    iMixitem = int.Parse(Temp.lSearch[3]);
                }
                int? iMixlot = null;
                if (Temp.lSearch[4] != null)
                {
                    iMixlot = int.Parse(Temp.lSearch[4]);
                }
                return RedirectToAction("ViewContent", new { locationcode = Temp.lSearch[0], locationcategory = sLocationCategory, mixexpire = iMixexpire, mixitem = iMixitem, mixlot = iMixlot, createby = Temp.lSearch[5], screatedate = Temp.lSearch[6], startcreatedate = Convert.ToDateTime(Temp.lSearch[7]), endcreatedate = Convert.ToDateTime(Temp.lSearch[8]), editby = Temp.lSearch[9], seditdate = Temp.lSearch[10], starteditdate = Convert.ToDateTime(Temp.lSearch[11]), endeditdate = Convert.ToDateTime(Temp.lSearch[12]) });
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
            HttpContext.Session.SetInt32("LPageNo", vPageNo);
            if (Temp.bSearchState == false)
            {
                return RedirectToAction(nameof(ViewContent));
            }
            else
            {
                string sLocationCategory = Guid.Empty.ToString();
                if (Temp.lSearch[1] != null)
                {
                    sLocationCategory = Temp.lSearch[1];
                }
                int? iMixexpire = null;
                if (Temp.lSearch[2] != null)
                {
                    iMixexpire = int.Parse(Temp.lSearch[2]);
                }
                int? iMixitem = null;
                if (Temp.lSearch[3] != null)
                {
                    iMixitem = int.Parse(Temp.lSearch[3]);
                }
                int? iMixlot = null;
                if (Temp.lSearch[4] != null)
                {
                    iMixlot = int.Parse(Temp.lSearch[4]);
                }
                return RedirectToAction("ViewContent", new { locationcode = Temp.lSearch[0], locationcategory = sLocationCategory, mixexpire = iMixexpire, mixitem = iMixitem, mixlot = iMixlot, createby = Temp.lSearch[5], screatedate = Temp.lSearch[6], startcreatedate = Convert.ToDateTime(Temp.lSearch[7]), endcreatedate = Convert.ToDateTime(Temp.lSearch[8]), editby = Temp.lSearch[9], seditdate = Temp.lSearch[10], starteditdate = Convert.ToDateTime(Temp.lSearch[11]), endeditdate = Convert.ToDateTime(Temp.lSearch[12]) });
            }
        }
    }
}
