using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace _211506K_AS_Assignment.ViewModels
{
    public class RegisterForm
    {
        [Required]
        [BindProperty]
        public string? FirstName { get; set; }
        [Required]
        [BindProperty]
        public string? LastName { get; set; }
        [Required]
        [BindProperty]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }
        [Required]
        [BindProperty]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
        [Required]
        [BindProperty]
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "Password and confirmation password does not match")]
        public string? ConfirmPassword { get; set; }
        [Required]
        [BindProperty]
        [CreditCard]
        [DataType(DataType.CreditCard)]
        public string? CreditCard { get; set; }
        [Required]
        [BindProperty]
        public IFormFile? Photo { get; set; }
        [Required]
        [BindProperty]
        public string? AboutMe { get; set; }
        [Required]
        [BindProperty]
        [DataType(DataType.PostalCode)]
        public string? Address { get; set; }
        [Required]
        [BindProperty]
        [Phone]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\d{8}$", ErrorMessage ="Please enter a 8-digit Phone Number")]
        public string? PhoneNumber { get; set; }


        [BindProperty]
        public string? Gender { get; set; }
        public string[] Genders = new[] { "Male", "Female" };
        [Required]
        public string Token { get; set; }


    }
}
