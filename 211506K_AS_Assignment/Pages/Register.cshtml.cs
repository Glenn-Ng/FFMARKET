using _211506K_AS_Assignment.Model;
using _211506K_AS_Assignment.ViewModels;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;
using System.Text.RegularExpressions;

namespace _211506K_AS_Assignment.Pages.Register
{
    //Initialize the build-in ASP.NET Identity
    public class RegisterModel : PageModel
    {

        private readonly RoleManager<IdentityRole> roleManager;
        private UserManager<ApplicationUser> userManager { get; }
        private SignInManager<ApplicationUser> signInManager { get; }
        public GoogleCaptchaConfig GoogleCaptchaConfig { get; }
        [BindProperty]
        public RegisterForm RModel { get; set; } = new();
        public RegisterModel(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<IdentityRole> roleManager, IOptions<GoogleCaptchaConfig> googleCaptchaConfig)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
            this.GoogleCaptchaConfig = googleCaptchaConfig.Value;
        }

        public void OnGet()
        {
        }

        //Save data into the database
        public async Task<IActionResult> OnPostAsync()
        {
            if (RModel.Photo is null)
            {
                ModelState.AddModelError("", "No file");
            }
            string extension = Path.GetExtension(RModel.Photo.FileName);
            //if (extension != "jpg" & extension != "JPG")
            //{
            //    ModelState.AddModelError("","Jpg file only");
            //}


            if (ModelState.IsValid)
            {
                var dataProtectionProvider = DataProtectionProvider.Create("EncryptData");
                var protector = dataProtectionProvider.CreateProtector("MySecretKey");
                var user = new ApplicationUser()
                {
                    FullName = RModel.FirstName + " " + RModel.LastName,
                    UserName = RModel.Email,
                    Email = RModel.Email,
                    Address = RModel.Address,
                    AboutMe = RModel.AboutMe,
                    PhoneNumber = RModel.PhoneNumber,
                    CreditCard = protector.Protect(RModel.CreditCard)
                };

                //Create the Admin role if NOT exist
                //IdentityRole role = await roleManager.FindByIdAsync("Admin");
                //if (role == null)
                //{
                //    IdentityResult result2 = await roleManager.CreateAsync(new IdentityRole("Admin"));
                //    if (!result2.Succeeded)
                //    {
                //        ModelState.AddModelError("", "Create role admin failed");
                //    }
                //}

                var result = await userManager.CreateAsync(user, RModel.Password);
                if (result.Succeeded)
                {
                    if(user.Email == "1234@gmail.com")
                    {
                        await roleManager.CreateAsync(new IdentityRole("Admin"));
                        await userManager.AddToRoleAsync(user, "Admin");
                    }
                    await signInManager.SignInAsync(user, false);
                    return RedirectToPage("Index");
                }

                var duplicateEmail = await userManager.FindByEmailAsync(RModel.Email);
                if (duplicateEmail is not null)
                {
                    ModelState.AddModelError(nameof(RModel.Email), "Email is already in use");
                    return Page();
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            Console.WriteLine(ModelState.ErrorCount);
            return Page();
        }
    }
}