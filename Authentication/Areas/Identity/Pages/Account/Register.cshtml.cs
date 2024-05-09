using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Authentication.Data;
using Authentication.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Authentication.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly WMContext _context;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;

        public RegisterModel(
            WMContext context,
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            RoleManager<IdentityRole> roleManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _logger = logger;
            _emailSender = emailSender;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public class InputModel
        {
            [Required(ErrorMessage = "Please Enter Username.")]
            [PageRemote(
                ErrorMessage = "Username already exists",
                HttpMethod = "post",
                PageHandler = "CheckUsername",
                AdditionalFields = "__RequestVerificationToken"
            )]
            [Display(Name = "Username")]
            public string Username { get; set; }

            [Required(ErrorMessage = "Please Enter Email.")]
            [EmailAddress(ErrorMessage = "Invalid Email Address.")]
            [PageRemote(
                ErrorMessage = "Email address already exists",
                HttpMethod = "post",
                PageHandler = "CheckEmail",
                AdditionalFields = "__RequestVerificationToken"
            )]
            [Display(Name = "Email")]
            public string Email { get; set; }

            //[Required]
            //[StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            //[DataType(DataType.Password)]
            //[Display(Name = "Password")]
            //public string Password { get; set; }

            //[DataType(DataType.Password)]
            //[Display(Name = "Confirm password")]
            //[Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            //public string ConfirmPassword { get; set; }

            [Required(ErrorMessage = "Please select role.")]
            [Display(Name = "Role")]
            public string Role { get; set; }
        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");
            string sRole = Input.Role switch
            {
                "0" => "User",
                "1" => "Admin",
                "2" => "Supervisor",
                _ => "",
            };
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            if (ModelState.IsValid)
            {
                var user = new IdentityUser { UserName = Input.Username, Email = Input.Email };
                var result = await _userManager.CreateAsync(user, "P@ssw0rd123");
                if (result.Succeeded)
                {
                    if (sRole.Trim() != "" && !await _roleManager.RoleExistsAsync(sRole.Trim()))
                    {
                        await _roleManager.CreateAsync(new IdentityRole(sRole.Trim()));
                    }
                    await _userManager.AddToRoleAsync(user, sRole.Trim());
                    var userManagement = new UserMangement
                    {
                        Id = Guid.Parse(user.Id),
                        reset_state = 'Y',
                        language = "EN"
                    };
                    _context.Add(userManagement);
                    await _context.SaveChangesAsync();
                    //_logger.LogInformation("User created a new account with password.");

                    //var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    //code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    //var callbackUrl = Url.Page(
                    //    "/Account/ConfirmEmail",
                    //    pageHandler: null,
                    //    values: new { area = "Identity", userId = user.Id, code = code, returnUrl = returnUrl },
                    //    protocol: Request.Scheme);

                    //await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                    //    $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                    if (_userManager.Options.SignIn.RequireConfirmedAccount)
                    {
                        return RedirectToPage("RegisterConfirmation", new { email = Input.Email, returnUrl = returnUrl });
                    }
                    else
                    {
                        //await _signInManager.SignInAsync(user, isPersistent: false);
                        //return LocalRedirect(returnUrl);

                        return RedirectToAction("ViewContent", "Users");
                    }
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }

        public JsonResult OnPostCheckUsername()
        {
            var user = _context.Users.Where(m => m.UserName == Input.Username).ToList();
            if (user.Count > 0)
            {
                return new JsonResult(false);
            }
            else
            {
                return new JsonResult(true);
            }
        }

        public JsonResult OnPostCheckEmail()
        {
            var user = _userManager.FindByEmailAsync(Input.Email).Result;
            var valid = user == null;
            return new JsonResult(valid);
        }
    }
}
