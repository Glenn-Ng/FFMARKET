using Microsoft.AspNetCore.Identity;

namespace _211506K_AS_Assignment.Model
{
    public class ApplicationUser : IdentityUser
    {
        public string? FullName { get; set; }
        public string? CreditCard { get; set; }
        public string? Gender { get; set; }
        public string? MobileNumber { get; set; }
        public string? Address { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? ConfirmPassword { get; set; }
        public string? Photo { get; set; }
        public string? AboutMe { get; set; }



    }
}
