using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Authentication.Data;
using Authentication.Models;

namespace Authentication.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class LoginModel : PageModel
    {
        private readonly WMContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ILogger<LoginModel> _logger;

        public LoginModel(
            WMContext context,
            SignInManager<IdentityUser> signInManager, 
            ILogger<LoginModel> logger,
            UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public string ReturnUrl { get; set; }

        [TempData]
        public string ErrorMessage { get; set; }

        public class InputModel
        {
            [Required]
            public string Username { get; set; }

            [EmailAddress]
            public string Email { get; set; }

            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            [Display(Name = "Remember me?")]
            public bool RememberMe { get; set; }
        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            if (!string.IsNullOrEmpty(ErrorMessage))
            {
                ModelState.AddModelError(string.Empty, ErrorMessage);
            }

            returnUrl ??= Url.Content("~/");

            // Initial Queue Type into database
            var vQueueType = _context.QueueType.ToList();
            if (vQueueType.Count == 0)
            {
                QueueType oQueueType = new QueueType
                {
                    category = "FIFO"

                };
                _context.Add(oQueueType);
                await _context.SaveChangesAsync();
                oQueueType = new QueueType
                {
                    category = "FEFO"

                };
                _context.Add(oQueueType);
                await _context.SaveChangesAsync();
            }

            // Initial Queue Type into database
            var vOrderType = _context.OrderType.ToList();
            if (vOrderType.Count == 0)
            {
                OrderType oOrderType = new OrderType
                {
                    order_type = "PO",
                    type = "I"

                };
                _context.Add(oOrderType);
                await _context.SaveChangesAsync();
                oOrderType = new OrderType
                {
                    order_type = "Return",
                    type = "IO"
                };
                _context.Add(oOrderType);
                await _context.SaveChangesAsync();

                oOrderType = new OrderType
                {
                    order_type = "SO",
                    type = "O"
                };
                _context.Add(oOrderType);
                await _context.SaveChangesAsync();
            }

            // Initial Received Item State into database
            var vItemReceiveState = _context.ItemReceivedState.ToList();
            if (vItemReceiveState.Count == 0)
            {
                ItemReceivedState oItemReceiveState = new ItemReceivedState
                {
                    state = "Complete"

                };
                _context.Add(oItemReceiveState);
                await _context.SaveChangesAsync();

                oItemReceiveState = new ItemReceivedState
                {
                    state = "Damage"

                };
                _context.Add(oItemReceiveState);
                await _context.SaveChangesAsync();
            }

            // Clear the existing external cookie to ensure a clean login process
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");

            byte[] time = BitConverter.GetBytes(DateTime.UtcNow.ToBinary());
            byte[] key = Guid.NewGuid().ToByteArray();
            string sToken = Convert.ToBase64String(time.Concat(key).ToArray());
            _ = sToken.Length;
            if (ModelState.IsValid)
            {
                // This doesn't count login failures towards account lockout
                // To enable password failures to trigger account lockout, set lockoutOnFailure: true
                var user = await _userManager.FindByNameAsync(Input.Username);
                if (user == null)
                {
                    ModelState.AddModelError(string.Empty, "User: " + Input.Username +  " does not exist in the system. Please contact to admin.");
                    return Page();
                }
                var valid = await _signInManager.UserManager.CheckPasswordAsync(user, Input.Password);
                if (valid == false)
                {
                    ModelState.AddModelError(string.Empty, "Password is invalid.");
                    return Page();
                }
                var state = await _context.UserMangement.FindAsync(Guid.Parse(user.Id));
                if (state.reset_state == 'Y')
                {
                    return RedirectToPage("./ResetPassword", new { username = Input.Username, code = _userManager.GeneratePasswordResetTokenAsync(user).Result });
                }
                else
                {
                    var result = await _signInManager.PasswordSignInAsync(Input.Username, Input.Password, Input.RememberMe, lockoutOnFailure: false);
                    if (result.Succeeded)
                    {
                        return LocalRedirect(returnUrl);
                    }
                    if (result.RequiresTwoFactor)
                    {
                        return RedirectToPage("./LoginWith2fa", new { ReturnUrl = returnUrl, RememberMe = Input.RememberMe });
                    }
                    if (result.IsLockedOut)
                    {
                        _logger.LogWarning("User account locked out.");
                        return RedirectToPage("./Lockout");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                        return Page();
                    }
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
