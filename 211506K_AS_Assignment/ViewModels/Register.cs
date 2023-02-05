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
        [DataType(DataType.CreditCard)]
        public string? CreditCard { get; set; }
        [Required]
        [BindProperty]
        public IFormFile? Photo { get; set; }
        [Required]
        [BindProperty]
        public string AboutMe { get; set; }

    }
}
