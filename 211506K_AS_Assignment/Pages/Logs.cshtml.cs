using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace _211506K_AS_Assignment.Pages
{
    [Authorize(Roles ="Admin")]
    public class LogsModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
