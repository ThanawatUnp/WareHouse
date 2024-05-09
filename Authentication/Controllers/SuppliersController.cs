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
    public class SuppliersController : Controller
    {
        private readonly WMContext _context;
        private string[] lHeader = { "Supplier Code", "Supplier Name", "Description", "Address1", "Address2", "Address3", "Province", "District", "Sub-District", "Zipcode", "Phone", "Mobile", "Fax", "E-mail", "Contact", "Active", "Create By", "Create Date", "Edit By", "Edit Date" };

        public SuppliersController(WMContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var tempData = SetPageNumber(null, false, null);
            var vSupplier = (from d in _context.Supplier.Include(e => e.Province).Include(e => e.District).Include(e => e.SubDistrict)
                             orderby d.create_date ascending
                             select d).Skip(tempData.SkipRec).Take(tempData.PerPage);
            var province = _context.Province.Select(s => new { Id = (int?)s.Id, ProvinceName = s.Province_Thai }).ToList();
            province.Insert(0, new
            {
                Id = new Nullable<int>(),
                ProvinceName = "Select Province"
            });

            setSearchState(false);
            Temp.lSearch.Clear();
            Temp.iSearchCount = 0;
            ViewData["Header"] = lHeader;
            ViewData["ProvinceList"] = new SelectList(province, "Id", "ProvinceName");
            ViewBag.btn_edit = "Y";
            ViewBag.btn_del = "Y";
            return View(await vSupplier.ToListAsync());
        }

        public IActionResult Create()
        {
            var supplier = new Supplier();
            supplier.Id = Guid.NewGuid();
            supplier.active = true;
            var province = _context.Province.Select(s => new { Id = (int?)s.Id, ProvinceName = s.Province_Thai }).ToList();
            province.Insert(0, new
            {
                Id = new Nullable<int>(),
                ProvinceName = "Select Province"
            });
            ViewData["ProvinceList"] = new SelectList(province, "Id", "ProvinceName");
            return View(supplier);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id, supplier_code, supplier_name, description, address1, address2, address3, zipcode, phone_no, mobile_no, fax_no, email, contact, active, create_by, create_date, edit_by, edit_date, file_name, ProvinceId, DistrictId, SubDistrictId")] Supplier supplier)
        {
            if (ModelState.IsValid) // Check binding success
            {
                var fcus = await _context.Supplier.FirstOrDefaultAsync(m => m.supplier_code == supplier.supplier_code);
                if (fcus != null)
                {
                    return NotFound();
                }
                if (Request.Form.Files.Count > 0)
                {
                    string path = @"wwwroot\images\supplier";
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    string[] files = System.IO.Directory.GetFiles(path, supplier.supplier_code.ToString() + ".*");
                    foreach (string f in files)
                    {
                        System.IO.File.Delete(f);
                    }
                    var fileName = supplier.supplier_code.ToString() + System.IO.Path.GetExtension(Request.Form.Files[0].FileName);
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), path, fileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await Request.Form.Files[0].CopyToAsync(fileStream);
                    }
                    supplier.file_name = fileName;
                }
                supplier.create_date = DateTime.Now;
                supplier.create_by = User.Identity.Name; //Program.username;
                supplier.edit_date = null;
                _context.Add(supplier);
                await _context.SaveChangesAsync();
                //return RedirectToAction(nameof(Index));
                if (Temp.bSearchState == false)
                {
                    return RedirectToAction(nameof(ViewContent));
                }
                else
                {
                    int? iProvince = null;
                    if (Temp.lSearch[5] != null)
                    {
                        iProvince = int.Parse(Temp.lSearch[5]);
                    }
                    int? iDistrict = null;
                    if (Temp.lSearch[6] != null)
                    {
                        iDistrict = int.Parse(Temp.lSearch[6]);
                    }
                    int? iSubdistrict = null;
                    if (Temp.lSearch[7] != null)
                    {
                        iSubdistrict = int.Parse(Temp.lSearch[7]);
                    }
                    int? iActive = null;
                    if (Temp.lSearch[14] != null)
                    {
                        iActive = int.Parse(Temp.lSearch[14]);
                    }
                    return RedirectToAction("ViewContent", new { suppliercode = Temp.lSearch[0], suppliername = Temp.lSearch[1], address1 = Temp.lSearch[2], address2 = Temp.lSearch[3], address3 = Temp.lSearch[4], province = iProvince, district = iDistrict, subdistrict = iSubdistrict, zipcode = Temp.lSearch[8], phoneno = Temp.lSearch[9], mobileno = Temp.lSearch[10], faxno = Temp.lSearch[11], email = Temp.lSearch[12], contact = Temp.lSearch[13], active = iActive, createby = Temp.lSearch[15], screatedate = Temp.lSearch[16], startcreatedate = Convert.ToDateTime(Temp.lSearch[17]), endcreatedate = Convert.ToDateTime(Temp.lSearch[18]), editby = Temp.lSearch[19], seditdate = Temp.lSearch[20], starteditdate = Convert.ToDateTime(Temp.lSearch[21]), endeditdate = Convert.ToDateTime(Temp.lSearch[22]) });
                }
            }

            return View(supplier);
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supplier = await _context.Supplier.FindAsync(id);
            if (supplier == null)
            {
                return NotFound();
            }

            var province = _context.Province.Select(s => new { Id = (int?)s.Id, ProvinceName = s.Province_Thai }).ToList();
            province.Insert(0, new
            {
                Id = new Nullable<int>(),
                ProvinceName = "Select Province"
            });

            var district = _context.District
                .Where(s => s.ProvinceId == supplier.ProvinceId)
                .Select(s => new { Id = (int?)s.Id, DistrictName = s.District_Thai }).ToList();

            var subdistrict = _context.SubDistrict
                .Where(s => s.DistrictId == supplier.DistrictId)
                .Select(s => new { Id = (int?)s.Id, SubDistrictName = s.SubDistrict_Thai }).ToList();

            ViewData["ProvinceList"] = new SelectList(province, "Id", "ProvinceName");
            ViewData["DistrictList"] = new SelectList(district, "Id", "DistrictName");
            ViewData["SubDistrictList"] = new SelectList(subdistrict, "Id", "SubDistrictName");
            return View(supplier);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id, supplier_code, supplier_name, description, address1, address2, address3, zipcode, phone_no, mobile_no, fax_no, email, contact, active, create_by, create_date, edit_by, edit_date, file_name, ProvinceId, DistrictId, SubDistrictId")] Supplier supplier)
        {
            if (id != supplier.Id)
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
                        string path = @"wwwroot\images\supplier";
                        if (!Directory.Exists(path))
                        {
                            Directory.CreateDirectory(path);
                        }
                        string[] files = System.IO.Directory.GetFiles(path, supplier.supplier_code.ToString() + ".*");
                        foreach (string f in files)
                        {
                            System.IO.File.Delete(f);
                        }
                        var fileName = supplier.supplier_code.ToString() + System.IO.Path.GetExtension(Request.Form.Files[0].FileName);
                        var filePath = Path.Combine(Directory.GetCurrentDirectory(), path, fileName);
                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            await Request.Form.Files[0].CopyToAsync(fileStream);
                        }
                        supplier.file_name = fileName;
                    }
                    supplier.edit_date = DateTime.Now;
                    supplier.edit_by = User.Identity.Name;
                    _context.Update(supplier);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SupplierExists(supplier.Id))
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
                    int? iProvince = null;
                    if (Temp.lSearch[5] != null)
                    {
                        iProvince = int.Parse(Temp.lSearch[5]);
                    }
                    int? iDistrict = null;
                    if (Temp.lSearch[6] != null)
                    {
                        iDistrict = int.Parse(Temp.lSearch[6]);
                    }
                    int? iSubdistrict = null;
                    if (Temp.lSearch[7] != null)
                    {
                        iSubdistrict = int.Parse(Temp.lSearch[7]);
                    }
                    int? iActive = null;
                    if (Temp.lSearch[14] != null)
                    {
                        iActive = int.Parse(Temp.lSearch[14]);
                    }
                    return RedirectToAction("ViewContent", new { suppliercode = Temp.lSearch[0], suppliername = Temp.lSearch[1], address1 = Temp.lSearch[2], address2 = Temp.lSearch[3], address3 = Temp.lSearch[4], province = iProvince, district = iDistrict, subdistrict = iSubdistrict, zipcode = Temp.lSearch[8], phoneno = Temp.lSearch[9], mobileno = Temp.lSearch[10], faxno = Temp.lSearch[11], email = Temp.lSearch[12], contact = Temp.lSearch[13], active = iActive, createby = Temp.lSearch[15], screatedate = Temp.lSearch[16], startcreatedate = Convert.ToDateTime(Temp.lSearch[17]), endcreatedate = Convert.ToDateTime(Temp.lSearch[18]), editby = Temp.lSearch[19], seditdate = Temp.lSearch[20], starteditdate = Convert.ToDateTime(Temp.lSearch[21]), endeditdate = Convert.ToDateTime(Temp.lSearch[22]) });
                }
            }
            return View(supplier);
        }

        public async Task<IActionResult> Details(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var vSupplier = (from d in _context.Supplier.Include(e => e.Province).Include(e => e.District).Include(e => e.SubDistrict)
                             orderby d.Id ascending
                             select d);
            var supplier = await _context.Supplier
                .Include(e => e.Province).Include(e => e.District).Include(e => e.SubDistrict)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (supplier == null)
            {
                return NotFound();
            }
            return View(supplier);
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var supplier = await _context.Supplier.FindAsync(id);
            if (supplier == null)
            {
                return NotFound();
            }
            return View(supplier);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Guid id, [Bind("Id, supplier_code, supplier_name, description, address1, address2, address3, zipcode, phone_no, mobile_no, fax_no, email, contact, active, create_by, create_date, edit_by, edit_date, file_name, ProvinceId, DistrictId, SubDistrictId")] Supplier supplier)
        {
            if (id != supplier.Id)
            {
                return NotFound();
            }
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            if (ModelState.IsValid)
            {
                try
                {
                    var vSupplier = await _context.Supplier.FindAsync(supplier.Id);
                    string path = @"wwwroot\images\supplier";
                    if (Directory.Exists(path))
                    {
                        string[] files = System.IO.Directory.GetFiles(path, supplier.supplier_code.ToString() + ".*");
                        foreach (string f in files)
                        {
                            System.IO.File.Delete(f);
                        }
                    }
                    _context.Supplier.Remove(vSupplier);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SupplierExists(supplier.Id))
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
                    int? iProvince = null;
                    if (Temp.lSearch[5] != null)
                    {
                        iProvince = int.Parse(Temp.lSearch[5]);
                    }
                    int? iDistrict = null;
                    if (Temp.lSearch[6] != null)
                    {
                        iDistrict = int.Parse(Temp.lSearch[6]);
                    }
                    int? iSubdistrict = null;
                    if (Temp.lSearch[7] != null)
                    {
                        iSubdistrict = int.Parse(Temp.lSearch[7]);
                    }
                    int? iActive = null;
                    if (Temp.lSearch[14] != null)
                    {
                        iActive = int.Parse(Temp.lSearch[14]);
                    }
                    return RedirectToAction("ViewContent", new { suppliercode = Temp.lSearch[0], suppliername = Temp.lSearch[1], address1 = Temp.lSearch[2], address2 = Temp.lSearch[3], address3 = Temp.lSearch[4], province = iProvince, district = iDistrict, subdistrict = iSubdistrict, zipcode = Temp.lSearch[8], phoneno = Temp.lSearch[9], mobileno = Temp.lSearch[10], faxno = Temp.lSearch[11], email = Temp.lSearch[12], contact = Temp.lSearch[13], active = iActive, createby = Temp.lSearch[15], screatedate = Temp.lSearch[16], startcreatedate = Convert.ToDateTime(Temp.lSearch[17]), endcreatedate = Convert.ToDateTime(Temp.lSearch[18]), editby = Temp.lSearch[19], seditdate = Temp.lSearch[20], starteditdate = Convert.ToDateTime(Temp.lSearch[21]), endeditdate = Convert.ToDateTime(Temp.lSearch[22]) });
                }
            }
            return View(supplier);
        }

        public async Task<IActionResult> ViewContent(string suppliercode, string suppliername, string address1, string address2, string address3, int? province, int? district, int? subdistrict, string zipcode, string phoneno, string mobileno, string faxno, string email, string contact, int? active, string createby, string screatedate, DateTime startcreatedate, DateTime endcreatedate, string editby, string seditdate, DateTime starteditdate, DateTime endeditdate, string clear)
        {
            IQueryable<Supplier> vSupplier = (from d in _context.Supplier.Include(e => e.Province).Include(e => e.District).Include(e => e.SubDistrict)
                             orderby d.create_date ascending
                             select d);
            setSearchState(false);
            Temp.lSearch.Clear();
            Temp.lSearch.Add(suppliercode);
            Temp.lSearch.Add(suppliername);
            Temp.lSearch.Add(address1);
            Temp.lSearch.Add(address2);
            Temp.lSearch.Add(address3);
            if (suppliercode != null)
            {
                vSupplier = vSupplier.Where(d => d.supplier_code.Contains(suppliercode)).AsQueryable();
                setSearchState(true);
            }
            if (suppliername != null)
            {
                vSupplier = vSupplier.Where(d => d.supplier_name.Contains(suppliername)).AsQueryable();
                setSearchState(true);
            }
            if (address1 != null)
            {
                vSupplier = vSupplier.Where(d => d.address1.Contains(address1)).AsQueryable();
                setSearchState(true);
            }
            if (address2 != null)
            {
                vSupplier = vSupplier.Where(d => d.address2.Contains(address2)).AsQueryable();
                setSearchState(true);
            }
            if (address3 != null)
            {
                vSupplier = vSupplier.Where(d => d.address3.Contains(address3)).AsQueryable();
                setSearchState(true);
            }
            if (province != null)
            {
                vSupplier = vSupplier.Where(d => d.ProvinceId == province).AsQueryable();
                setSearchState(true);
                Temp.lSearch.Add(province.ToString());
            }
            else
            {
                Temp.lSearch.Add(null);
            }
            if (district != null)
            {
                vSupplier = vSupplier.Where(d => d.DistrictId == district).AsQueryable();
                setSearchState(true);
                Temp.lSearch.Add(district.ToString());
            }
            else
            {
                Temp.lSearch.Add(null);
            }
            if (subdistrict != null)
            {
                vSupplier = vSupplier.Where(d => d.SubDistrictId == subdistrict).AsQueryable();
                setSearchState(true);
                Temp.lSearch.Add(subdistrict.ToString());
            }
            else
            {
                Temp.lSearch.Add(null);
            }
            Temp.lSearch.Add(zipcode);
            Temp.lSearch.Add(phoneno);
            Temp.lSearch.Add(mobileno);
            Temp.lSearch.Add(faxno);
            Temp.lSearch.Add(email);
            Temp.lSearch.Add(contact);
            if (zipcode != null)
            {
                vSupplier = vSupplier.Where(d => d.zipcode.Contains(zipcode)).AsQueryable();
                setSearchState(true);
            }
            if (phoneno != null)
            {
                vSupplier = vSupplier.Where(d => d.phone_no.Contains(phoneno)).AsQueryable();
                setSearchState(true);
            }
            if (mobileno != null)
            {
                vSupplier = vSupplier.Where(d => d.mobile_no.Contains(mobileno)).AsQueryable();
                setSearchState(true);
            }
            if (faxno != null)
            {
                vSupplier = vSupplier.Where(d => d.fax_no.Contains(faxno)).AsQueryable();
                setSearchState(true);
            }
            if (email != null)
            {
                vSupplier = vSupplier.Where(d => d.email.Contains(email)).AsQueryable();
                setSearchState(true);
            }
            if (contact != null)
            {
                vSupplier = vSupplier.Where(d => d.contact.Contains(contact)).AsQueryable();
                setSearchState(true);
            }
            if (active != null)
            {
                if (active == 1)
                {
                    vSupplier = vSupplier.Where(d => d.active == true).AsQueryable();
                    setSearchState(true);
                    Temp.lSearch.Add(active.ToString());
                }
                else
                {
                    vSupplier = vSupplier.Where(d => d.active == false).AsQueryable();
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
                vSupplier = vSupplier.Where(d => d.create_by.Contains(createby)).AsQueryable();
                setSearchState(true);
            }
            if (screatedate != null && screatedate.Trim() == "y")
            {
                vSupplier = vSupplier.Where(d => d.create_date >= startcreatedate.Date && d.create_date < endcreatedate.AddDays(1).Date).AsQueryable();
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
                vSupplier = vSupplier.Where(d => d.edit_by.Contains(editby)).AsQueryable();
                setSearchState(true);
            }
            if (seditdate != null && seditdate.Trim() == "y")
            {
                vSupplier = vSupplier.Where(d => d.edit_date >= starteditdate.Date && d.edit_date < endeditdate.AddDays(1).Date).AsQueryable();
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
                ViewData["suppliercode"] = Temp.lSearch[0];
                ViewData["suppliername"] = Temp.lSearch[1];
                ViewData["address1"] = Temp.lSearch[2];
                ViewData["address2"] = Temp.lSearch[3];
                ViewData["address3"] = Temp.lSearch[4];
                ViewData["province"] = Temp.lSearch[5];
                ViewData["district"] = Temp.lSearch[6];
                ViewData["subdistrict"] = Temp.lSearch[7];
                ViewData["zipcode"] = Temp.lSearch[8];
                ViewData["phoneno"] = Temp.lSearch[9];
                ViewData["mobileno"] = Temp.lSearch[10];
                ViewData["faxno"] = Temp.lSearch[11];
                ViewData["email"] = Temp.lSearch[12];
                ViewData["contact"] = Temp.lSearch[13];
                if (Temp.lSearch[14] == null)
                {
                    ViewData["active"] = "Select";
                }
                else
                {
                    ViewData["active"] = Temp.lSearch[14];
                }
                ViewData["createby"] = Temp.lSearch[15];
                if (Temp.lSearch[16] != null)
                {
                    ViewData["createdatestate"] = "y";
                    ViewData["startcreatedate"] = Convert.ToDateTime(Temp.lSearch[17]).Month.ToString() + "/" + Convert.ToDateTime(Temp.lSearch[17]).Day.ToString() + "/" + Convert.ToDateTime(Temp.lSearch[17]).Year.ToString();
                    ViewData["endcreatedate"] = Convert.ToDateTime(Temp.lSearch[18]).Month.ToString() + "/" + Convert.ToDateTime(Temp.lSearch[18]).Day.ToString() + "/" + Convert.ToDateTime(Temp.lSearch[18]).Year.ToString();
                }
                else
                {
                    ViewData["createdatestate"] = "n";
                }
                ViewData["editby"] = Temp.lSearch[19];
                if (Temp.lSearch[20] != null)
                {
                    ViewData["editdatestate"] = "y";
                    ViewData["starteditdate"] = Convert.ToDateTime(Temp.lSearch[21]).Month.ToString() + "/" + Convert.ToDateTime(Temp.lSearch[21]).Day.ToString() + "/" + Convert.ToDateTime(Temp.lSearch[21]).Year.ToString();
                    ViewData["endeditdate"] = Convert.ToDateTime(Temp.lSearch[22]).Month.ToString() + "/" + Convert.ToDateTime(Temp.lSearch[22]).Day.ToString() + "/" + Convert.ToDateTime(Temp.lSearch[22]).Year.ToString();
                }
                else
                {
                    ViewData["editdatestate"] = "n";
                }
                Temp.iSearchCount += 1;
            }
            var tempData = SetPageNumber(vSupplier.Count(), Temp.bSearchState, clear);
            vSupplier = vSupplier.Skip(tempData.SkipRec).Take(tempData.PerPage);

            var vProvince = _context.Province.Select(s => new { Id = (int?)s.Id, ProvinceName = s.Province_Thai }).ToList();
            vProvince.Insert(0, new
            {
                Id = new Nullable<int>(),
                ProvinceName = "Select Province"
            });
            var vDistrict = _context.District
                .Where(s => s.ProvinceId == province)
                .Select(s => new { Id = (int?)s.Id, DistrictName = s.District_Thai }).ToList();
            vDistrict.Insert(0, new
            {
                Id = new Nullable<int>(),
                DistrictName = "Select District"
            });

            var vSubdistrict = _context.SubDistrict
                .Where(s => s.DistrictId == district)
                .Select(s => new { Id = (int?)s.Id, SubDistrictName = s.SubDistrict_Thai }).ToList();
            vSubdistrict.Insert(0, new
            {
                Id = new Nullable<int>(),
                SubDistrictName = "Select Sub-District"
            });


            ViewData["Header"] = lHeader;
            ViewData["ProvinceList"] = new SelectList(vProvince, "Id", "ProvinceName");
            ViewData["DistrictList"] = new SelectList(vDistrict, "Id", "DistrictName");
            ViewData["SubDistrictList"] = new SelectList(vSubdistrict, "Id", "SubDistrictName");
            ViewBag.btn_edit = "Y";
            ViewBag.btn_del = "Y";
            return View(await vSupplier.ToListAsync());
        }

        public JsonResult getDistrict(int province_id)
        {
            var district = _context.District
                .Where(s => s.ProvinceId == province_id)
                .Select(s => new { Id = (int?)s.Id, DistrictName = s.District_Thai }).ToList();
            district.Insert(0, new
            {
                Id = new Nullable<int>(),
                DistrictName = "Select District"
            });
            return Json(new SelectList(district, "Id", "DistrictName"));
        }

        public JsonResult getSubDistrict(int district_id)
        {
            var subdistrict = _context.SubDistrict
                .Where(s => s.DistrictId == district_id)
                .Select(s => new { Id = (int?)s.Id, SubDistrictName = s.SubDistrict_Thai }).ToList();
            subdistrict.Insert(0, new
            {
                Id = new Nullable<int>(),
                SubDistrictName = "Select Sub-District"
            });
            return Json(new SelectList(subdistrict, "Id", "SubDistrictName"));
        }

        public JsonResult getZipcode(int subdistrict_id)
        {
            var zipcode = _context.SubDistrict
                .Where(s => s.Id == subdistrict_id)
                .Select(s => new { Zipcode = s.zipcode }).ToList();

            return Json(zipcode);
        }

        [AcceptVerbs("GET", "POST")]
        public async Task<IActionResult> checkSupplierCode(string supplier_code)
        {

            var fcus = await _context.Supplier.FirstOrDefaultAsync(m => m.supplier_code == supplier_code);
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
        public JsonResult checkSupplierName(string supplier_name)
        {
            if ((supplier_name == null) || (supplier_name.Trim().Length == 0))
            {
                return Json(false);
            }
            else
            {
                return Json(true);
            }
        }

        [AcceptVerbs("GET", "POST")]
        public JsonResult checkPhoneNumber(string phone_no)
        {
            if (phone_no != null)
            {
                if (phone_no.Trim() != "")
                {
                    double iPhoune_Number;
                    if (double.TryParse(phone_no.ToString().Trim(), out iPhoune_Number))
                    {
                        if (phone_no.Trim().Length != 9)
                        {
                            return Json($"Please enter 9 digits.");
                        }
                        else
                        {
                            return Json(true);
                        }
                    }
                    else
                    {
                        return Json($"Please enter a number.");
                    }
                }
                else
                {
                    return Json(true);
                }
            }
            else
            {
                return Json(true);
            }
        }

        [AcceptVerbs("GET", "POST")]
        public JsonResult checkMobileNumber(string mobile_no)
        {
            if (mobile_no != null)
            {
                if (mobile_no.Trim() != "")
                {
                    double iMobile_Number;
                    if (double.TryParse(mobile_no.ToString().Trim(), out iMobile_Number))
                    {
                        if (mobile_no.Trim().Length != 10)
                        {
                            return Json($"Please enter 10 digits.");
                        }
                        else
                        {
                            return Json(true);
                        }
                    }
                    else
                    {
                        return Json($"Please enter a number.");
                    }
                }
                else
                {
                    return Json(true);
                }
            }
            else
            {
                return Json(true);
            }
        }

        private bool SupplierExists(Guid id)
        {
            return _context.Supplier.Any(e => e.Id == id);
        }

        private void setSearchState(bool state)
        {
            Temp.bSearchState = state;
        }

        private ManagePageNumber SetPageNumber(int? total, bool searchState, string sClear)
        {
            ManagePageNumber temp = new ManagePageNumber();

            temp.PerPage = HttpContext.Session.GetInt32("SPerPage") ?? 20;

            if (searchState == true)
            {
                if (Temp.iSearchCount == 1)
                {
                    HttpContext.Session.SetInt32("SPageNo", 1);
                    temp.PageNo = 1;
                }
                else
                {
                    temp.PageNo = HttpContext.Session.GetInt32("SPageNo") ?? 1;
                }
                temp.TotalRec = (int)total;
            }
            else
            {
                if (sClear != null)
                {
                    HttpContext.Session.SetInt32("SPageNo", 1);
                    temp.PageNo = 1;
                }
                else
                {
                    temp.PageNo = HttpContext.Session.GetInt32("SPageNo") ?? 1;
                }
                temp.TotalRec = _context.Supplier.Count();
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

            HttpContext.Session.SetInt32("SPerPage", vPage);
            if (Temp.bSearchState == false)
            {
                return RedirectToAction(nameof(ViewContent));
            }
            else
            {
                int? iProvince = null;
                if (Temp.lSearch[5] != null)
                {
                    iProvince = int.Parse(Temp.lSearch[5]);
                }
                int? iDistrict = null;
                if (Temp.lSearch[6] != null)
                {
                    iDistrict = int.Parse(Temp.lSearch[6]);
                }
                int? iSubdistrict = null;
                if (Temp.lSearch[7] != null)
                {
                    iSubdistrict = int.Parse(Temp.lSearch[7]);
                }
                int? iActive = null;
                if (Temp.lSearch[14] != null)
                {
                    iActive = int.Parse(Temp.lSearch[14]);
                }
                return RedirectToAction("ViewContent", new { suppliercode = Temp.lSearch[0], suppliername = Temp.lSearch[1], address1 = Temp.lSearch[2], address2 = Temp.lSearch[3], address3 = Temp.lSearch[4], province = iProvince, district = iDistrict, subdistrict = iSubdistrict, zipcode = Temp.lSearch[8], phoneno = Temp.lSearch[9], mobileno = Temp.lSearch[10], faxno = Temp.lSearch[11], email = Temp.lSearch[12], contact = Temp.lSearch[13], active = iActive, createby = Temp.lSearch[15], screatedate = Temp.lSearch[16], startcreatedate = Convert.ToDateTime(Temp.lSearch[17]), endcreatedate = Convert.ToDateTime(Temp.lSearch[18]), editby = Temp.lSearch[19], seditdate = Temp.lSearch[20], starteditdate = Convert.ToDateTime(Temp.lSearch[21]), endeditdate = Convert.ToDateTime(Temp.lSearch[22]) });
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
            HttpContext.Session.SetInt32("SPageNo", vPageNo);
            if (Temp.bSearchState == false)
            {
                return RedirectToAction(nameof(ViewContent));
            }
            else
            {
                int? iProvince = null;
                if (Temp.lSearch[5] != null)
                {
                    iProvince = int.Parse(Temp.lSearch[5]);
                }
                int? iDistrict = null;
                if (Temp.lSearch[6] != null)
                {
                    iDistrict = int.Parse(Temp.lSearch[6]);
                }
                int? iSubdistrict = null;
                if (Temp.lSearch[7] != null)
                {
                    iSubdistrict = int.Parse(Temp.lSearch[7]);
                }
                int? iActive = null;
                if (Temp.lSearch[14] != null)
                {
                    iActive = int.Parse(Temp.lSearch[14]);
                }
                return RedirectToAction("ViewContent", new { suppliercode = Temp.lSearch[0], suppliername = Temp.lSearch[1], address1 = Temp.lSearch[2], address2 = Temp.lSearch[3], address3 = Temp.lSearch[4], province = iProvince, district = iDistrict, subdistrict = iSubdistrict, zipcode = Temp.lSearch[8], phoneno = Temp.lSearch[9], mobileno = Temp.lSearch[10], faxno = Temp.lSearch[11], email = Temp.lSearch[12], contact = Temp.lSearch[13], active = iActive, createby = Temp.lSearch[15], screatedate = Temp.lSearch[16], startcreatedate = Convert.ToDateTime(Temp.lSearch[17]), endcreatedate = Convert.ToDateTime(Temp.lSearch[18]), editby = Temp.lSearch[19], seditdate = Temp.lSearch[20], starteditdate = Convert.ToDateTime(Temp.lSearch[21]), endeditdate = Convert.ToDateTime(Temp.lSearch[22]) });
            }
        }
    }
}
