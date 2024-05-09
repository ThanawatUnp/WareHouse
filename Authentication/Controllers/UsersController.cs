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
using Microsoft.AspNetCore.Identity;

namespace Authentication.Controllers
{
    [Authorize]
    public class UsersController : Controller
    {
        private readonly WMContext _context;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly string[] lHeader = { "Username", "E-mail", "Role" };

        public UsersController(WMContext context, RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _roleManager = roleManager;
            _userManager = userManager;
        }


        public IActionResult Index()
        {
            var tempData = SetPageNumber(null, false, null);
            var vUser = (from u in _context.Users
                         join ur in _context.UserRoles on u.Id equals ur.UserId
                         join r in _context.Roles on ur.RoleId equals r.Id
                             orderby u.UserName ascending
                             select new { u.Id, u.UserName, u.Email, r.Name } ).Skip(tempData.SkipRec).Take(tempData.PerPage);
            List<UsersViewModel> lUser = new List<UsersViewModel>();
            foreach (var item in vUser)
            {
                var vItem = new UsersViewModel
                {
                    Id = item.Id.ToString(),
                    Username = item.UserName,
                    Email = item.Email,
                    Role = item.Name
                };
                lUser.Add(vItem);
            }
            var role = _context.Roles.Select(s => new { s.Id, RoleName = s.Name }).ToList();
            role.Sort((x, y) => string.Compare(x.RoleName, y.RoleName));
            role.Insert(0, new
            {
                Id = string.Empty,
                RoleName = "Select"
            });

            setSearchState(false);
            Temp.lSearch.Clear();
            Temp.iSearchCount = 0;
            ViewData["Header"] = lHeader;
            ViewData["RoleList"] = new SelectList(role, "Id", "RoleName");
            ViewBag.btn_edit = "Y";
            ViewBag.btn_del = "Y";
            ViewBag.btn_reset = "Y";
            return View(lUser);
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var user = await (from u in _context.Users
                          join ur in _context.UserRoles on u.Id equals ur.UserId
                          join r in _context.Roles on ur.RoleId equals r.Id
                          orderby u.UserName ascending
                          where u.Id.Contains(id.ToString())
                          select new UsersViewModel { Id = u.Id.ToString(), Username = u.UserName, Email = u.Email, EmailConfirmed = u.EmailConfirmed, PhoneNumberConfirmed = u.PhoneNumberConfirmed, TwoFactorEnabled = u.TwoFactorEnabled, LockoutEnabled = u.LockoutEnabled, AccessFailedCount = u.AccessFailedCount, Role = r.Name }).FirstOrDefaultAsync();
            if (user == null)
            {
                return NotFound();
            }
            ViewData["role"] = user.Role;
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id, Username, Email, NormalizedUserName, NormalizedEmail, EmailConfirmed, PasswordHash, SecurityStamp, ConcurrencyStamp, PhoneNumber, PhoneNumberConfirmed, TwoFactorEnabled, LockoutEnd, LockoutEnabled, AccessFailedCount, Role")] UsersViewModel user)
        {
            if (id != Guid.Parse(user.Id))
            {
                return NotFound();
            }
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            if (ModelState.IsValid)
            {
                try
                {
                    var vUser = await _userManager.FindByIdAsync(user.Id.ToString());
                    if (vUser == null)
                    {
                        return NotFound();
                    }
                    else
                    {
                        vUser.Email = user.Email;

                        var result = await _userManager.UpdateAsync(vUser);
                        if (result.Succeeded)
                        {
                            var rolesForUser = await _userManager.GetRolesAsync(vUser);
                            using (var transaction = _context.Database.BeginTransaction())
                            {
                                if (rolesForUser.Count() > 0)
                                {
                                    foreach (var item in rolesForUser.ToList())
                                    {
                                        result = await _userManager.RemoveFromRoleAsync(vUser, item);
                                    }
                                }
                                transaction.Commit();
                            }
                            var vRole = "";
                            if (user.Role.ToString().Trim() == "0")
                            {
                                vRole = "User";
                            }
                            else if (user.Role.ToString().Trim() == "1")
                            {
                                vRole = "Admin";
                            }
                            else if (user.Role.ToString().Trim() == "2")
                            {
                                vRole = "Supervisor";
                            }
                            if (vRole.Trim() != "" && !await _roleManager.RoleExistsAsync(vRole.Trim()))
                            {
                                await _roleManager.CreateAsync(new IdentityRole(vRole.Trim()));
                            }
                            await _userManager.AddToRoleAsync(vUser, vRole.Trim());
                            if (Temp.bSearchState == false)
                            {
                                return RedirectToAction(nameof(ViewContent));
                            }
                            else
                            {
                                return RedirectToAction("ViewContent", new { username = Temp.lSearch[0], email = Temp.lSearch[1], role = Temp.lSearch[2] });
                            }
                        }
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError(string.Empty, error.Description);
                        }
                        return View(user);
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(Guid.Parse(user.Id)))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return View(user);
        }

        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var user = await (from u in _context.Users
                         join ur in _context.UserRoles on u.Id equals ur.UserId
                         join r in _context.Roles on ur.RoleId equals r.Id
                         orderby u.UserName ascending
                         select new { u.Id, u.UserName, u.Email, r.Name }).FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            var mUser = new UsersViewModel
            {
                Id = user.Id.ToString(),
                Username = user.UserName,
                Email = user.Email,
                Role = user.Name
            };
            return View(mUser);
        }

        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var user = await (from u in _context.Users
                              join ur in _context.UserRoles on u.Id equals ur.UserId
                              join r in _context.Roles on ur.RoleId equals r.Id
                              orderby u.UserName ascending
                              select new { u.Id, u.UserName, u.Email, u.EmailConfirmed, u.PhoneNumberConfirmed, u.TwoFactorEnabled, u.LockoutEnabled, u.AccessFailedCount, r.Name }).FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            var mUser = new UsersViewModel
            {
                Id = user.Id.ToString(),
                Username = user.UserName,
                Email = user.Email,
                EmailConfirmed = user.EmailConfirmed,
                PhoneNumberConfirmed = user.PhoneNumberConfirmed,
                TwoFactorEnabled = user.TwoFactorEnabled,
                LockoutEnabled = user.LockoutEnabled,
                AccessFailedCount = user.AccessFailedCount,
                Role = user.Name
            };
            return View(mUser);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Guid id, [Bind("Id, Username, Email, NormalizedUserName, NormalizedEmail, EmailConfirmed, PasswordHash, SecurityStamp, ConcurrencyStamp, PhoneNumber, PhoneNumberConfirmed, TwoFactorEnabled, LockoutEnd, LockoutEnabled, AccessFailedCount, Role")] UsersViewModel user)
        {
            if (id != Guid.Parse(user.Id))
            {
                return NotFound();
            }
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            if (ModelState.IsValid)
            {
                try
                {
                    var vUser = await _userManager.FindByIdAsync(user.Id.ToString());
                    var rolesForUser = await _userManager.GetRolesAsync(vUser);
                    if (vUser.UserName != User.Identity.Name)
                    {
                        using (var transaction = _context.Database.BeginTransaction())
                        {
                            if (rolesForUser.Count() > 0)
                            {
                                foreach (var item in rolesForUser.ToList())
                                {
                                    var result = await _userManager.RemoveFromRoleAsync(vUser, item);
                                }
                            }

                            await _userManager.DeleteAsync(vUser);
                            transaction.Commit();
                        }
                        if (Temp.bSearchState == false)
                        {
                            return RedirectToAction(nameof(ViewContent));
                        }
                        else
                        {
                            return RedirectToAction("ViewContent", new { username = Temp.lSearch[0], email = Temp.lSearch[1], role = Temp.lSearch[2] });
                        }
                    }
                    else
                    {
                        if (Temp.bSearchState == false)
                        {
                            return RedirectToAction("ViewContent", new { bAlertState = true, sMsg = "You cannot delete this account." });
                        }
                        else
                        {
                            return RedirectToAction("ViewContent", new { username = Temp.lSearch[0], email = Temp.lSearch[1], role = Temp.lSearch[2], bAlertState = true, sMsg = "You cannot delete this account." });
                        }
                    }
                    
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(Guid.Parse(user.Id)))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return View(user);
        }

        public async Task<IActionResult> ResetPassword(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var user = await (from u in _context.Users
                              join ur in _context.UserRoles on u.Id equals ur.UserId
                              join r in _context.Roles on ur.RoleId equals r.Id
                              orderby u.UserName ascending
                              select new { u.Id, u.UserName, u.Email, u.EmailConfirmed, u.PhoneNumberConfirmed, u.TwoFactorEnabled, u.LockoutEnabled, u.AccessFailedCount, r.Name }).FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            var mUser = new UsersViewModel
            {
                Id = user.Id.ToString(),
                Username = user.UserName,
                Email = user.Email,
                EmailConfirmed = user.EmailConfirmed,
                PhoneNumberConfirmed = user.PhoneNumberConfirmed,
                TwoFactorEnabled = user.TwoFactorEnabled,
                LockoutEnabled = user.LockoutEnabled,
                AccessFailedCount = user.AccessFailedCount,
                Role = user.Name
            };
            return View(mUser);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPassword(Guid id, [Bind("Id, Username, Email, NormalizedUserName, NormalizedEmail, EmailConfirmed, PasswordHash, SecurityStamp, ConcurrencyStamp, PhoneNumber, PhoneNumberConfirmed, TwoFactorEnabled, LockoutEnd, LockoutEnabled, AccessFailedCount, Role")] UsersViewModel user)
        {
            if (id != Guid.Parse(user.Id))
            {
                return NotFound();
            }
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            if (ModelState.IsValid)
            {
                try
                {
                    var vUser = await _userManager.FindByIdAsync(user.Id.ToString());
                    if (vUser == null)
                    {
                        return NotFound();
                    }
                    else
                    {
                        var token = _userManager.GeneratePasswordResetTokenAsync(vUser).Result;
                        var result = _userManager.ResetPasswordAsync(vUser, token, "P@ssw0rd123").Result;
                        if (result.Succeeded)
                        {
                            var userManagement = new UserMangement
                            {
                                Id = Guid.Parse(vUser.Id),
                                reset_state = 'Y'
                            };
                            _context.Update(userManagement);
                            await _context.SaveChangesAsync();
                            if (Temp.bSearchState == false)
                            {
                                return RedirectToAction("ViewContent", new { bAlertState = true, sMsg = "Reset Password Success." });
                            }
                            else
                            {
                                return RedirectToAction("ViewContent", new { username = Temp.lSearch[0], email = Temp.lSearch[1], role = Temp.lSearch[2], bAlertState = true, sMsg = "Reset Password Success."  });
                            }
                        }
                        else
                        {
                            return View(user);
                        }
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(Guid.Parse(user.Id)))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return View(user);
        }

        public IActionResult ViewContent(string username, string email, string role, string clear, bool bAlertState, string sMsg)
        {
            
            IQueryable<UsersViewModel> vUser = (from u in _context.Users
                                          join ur in _context.UserRoles on u.Id equals ur.UserId
                                          join r in _context.Roles on ur.RoleId equals r.Id
                                          orderby u.UserName ascending
                                          select new UsersViewModel{ Id = u.Id.ToString(), Username = u.UserName, Email = u.Email, Role = r.Name });

            setSearchState(false);
            Temp.lSearch.Clear();
            Temp.lSearch.Add(username);
            Temp.lSearch.Add(email);
            Temp.lSearch.Add(role);
            if (username != null)
            {
                vUser = vUser.Where(d => d.Username.Contains(username)).AsQueryable();
                setSearchState(true);
            }
            if (email != null)
            {
                vUser = vUser.Where(d => d.Email.Contains(email)).AsQueryable();
                setSearchState(true);
            }
            if (role != null)
            {
                if (role.Trim() != "Select")
                {
                    vUser = vUser.Where(d => d.Role.Contains(role)).AsQueryable();
                    setSearchState(true);
                    Temp.lSearch.Add(role.ToString());
                }
            }

            if (Temp.bSearchState == false)
            {
                Temp.lSearch.Clear();
                Temp.iSearchCount = 0;
            }
            else
            {
                ViewData["username"] = Temp.lSearch[0];
                ViewData["email"] = Temp.lSearch[1];
                ViewData["role"] = Temp.lSearch[2];
                Temp.iSearchCount += 1;
            }
            var tempData = SetPageNumber(vUser.Count(), Temp.bSearchState, clear);
            vUser = vUser.Skip(tempData.SkipRec).Take(tempData.PerPage);
            var lUser = vUser.ToList<UsersViewModel>();
            var vRole = _context.Roles.Select(s => new { s.Id, RoleName = s.Name }).ToList();
            vRole.Sort((x, y) => string.Compare(x.RoleName, y.RoleName));
            vRole.Insert(0, new
            {
                Id = string.Empty,
                RoleName = "Select"
            });
            ViewData["Header"] = lHeader;
            ViewData["RoleList"] = new SelectList(vRole, "Id", "RoleName");
            ViewBag.btn_edit = "Y";
            ViewBag.btn_del = "Y";
            ViewBag.btn_reset = "Y";
            if (bAlertState == true)
            {
                ViewData["showAlert"] = true;
                ViewData["alertMessage"] = sMsg;
            }
            return View( lUser );
        }

        private bool UserExists(Guid id)
        {
            return _context.Users.Any(e => e.Id == id.ToString());
        }

        private void setSearchState(bool state)
        {
            Temp.bSearchState = state;
        }

        private ManagePageNumber SetPageNumber(int? total, bool searchState, string sClear)
        {
            ManagePageNumber temp = new ManagePageNumber
            {
                PerPage = HttpContext.Session.GetInt32("UPerPage") ?? 20
            };

            if (searchState == true)
            {
                if (Temp.iSearchCount == 1)
                {
                    HttpContext.Session.SetInt32("UPageNo", 1);
                    temp.PageNo = 1;
                }
                else
                {
                    temp.PageNo = HttpContext.Session.GetInt32("UPageNo") ?? 1;
                }
                temp.TotalRec = (int) total;
            }
            else
            {
                if (sClear != null)
                {
                    HttpContext.Session.SetInt32("UPageNo", 1);
                    temp.PageNo = 1;
                }
                else
                {
                    temp.PageNo = HttpContext.Session.GetInt32("UPageNo") ?? 1;
                }
                temp.TotalRec = _context.Users.Count();
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

            HttpContext.Session.SetInt32("UPerPage", vPage);
            if (Temp.bSearchState == false)
            {
                return RedirectToAction(nameof(ViewContent));
            }
            else
            {
                return RedirectToAction("ViewContent", new { username = Temp.lSearch[0], email = Temp.lSearch[1], role = Temp.lSearch[2] });
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
            HttpContext.Session.SetInt32("UPageNo", vPageNo);
            if (Temp.bSearchState == false)
            {
                return RedirectToAction(nameof(ViewContent));
            }
            else
            {
                return RedirectToAction("ViewContent", new { username = Temp.lSearch[0], email = Temp.lSearch[1], role = Temp.lSearch[2] });
            }
        }

        public async Task<IActionResult> ValidSelfUser(string Id)
        {
            var vUser = await _userManager.FindByNameAsync(User.Identity.Name);
            bool result = true;
            if (vUser.Id != Id)
            {
                result = false;
            }
            return Json(new { result });
        }
    }
}
