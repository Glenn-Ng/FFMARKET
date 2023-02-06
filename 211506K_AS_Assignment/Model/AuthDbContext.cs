using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace _211506K_AS_Assignment.Model;

public class AuthDbContext : IdentityDbContext<ApplicationUser>
{
   public AuthDbContext(DbContextOptions options) : base(options)
   {
   }
}