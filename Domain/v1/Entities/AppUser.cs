using Microsoft.AspNetCore.Identity;

namespace Domain.v1.Entities
{
    public class AppUser : IdentityUser<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Country { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastActive { get; set; }
        public bool IsAccountActive { get; set; } = true;
        public bool IsPremium { get; set; } = false;
        public ICollection<AppUserRole> UserRoles { get; set; }
    }
}