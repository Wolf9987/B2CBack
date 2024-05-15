using Microsoft.AspNetCore.Identity;

namespace Bit2C
{
    public class AppUser:IdentityUser
    {
        public string FullName { get; set; }
        //public string Email { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }

    }
}
