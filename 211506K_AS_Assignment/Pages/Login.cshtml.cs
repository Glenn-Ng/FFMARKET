using _211506K_AS_Assignment.Model;
using _211506K_AS_Assignment.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;
using System.Security.Claims;

namespace _211506K_AS_Assignment.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public Login LModel { get; set; } = new();
        private readonly SignInManager<ApplicationUser> signInManager;
        public GoogleCaptchaConfig GoogleCaptchaConfig { get; }
        public LoginModel(SignInManager<ApplicationUser> signInManager, IOptions<GoogleCaptchaConfig> googleCaptchaConfig)
        {
            this.signInManager = signInManager;
            this.GoogleCaptchaConfig = googleCaptchaConfig.Value;
        }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var identityResult = await signInManager.PasswordSignInAsync(LModel.Email, LModel.Password, LModel.RememberMe, false);
                if (identityResult.Succeeded)
                {
                    //Create the security context
                    var claims = new List<Claim> {
                        new Claim(ClaimTypes.Name, "c@c.com"),
                        new Claim(ClaimTypes.Email, "c@c.com"),
                        new Claim("Department", "HR")
                    };

                    var i = new ClaimsIdentity(claims, "MyCookieAuth");
                    ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(i);
                    await HttpContext.SignInAsync("MyCookieAuth", claimsPrincipal);

                    return RedirectToPage("Index");
                }
                ModelState.AddModelError("", "Username or Password incorrect");
            }
            return Page();
        }
    }
}
