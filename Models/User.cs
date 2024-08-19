using Microsoft.AspNetCore.Identity;
namespace LMS.Models
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }
}
