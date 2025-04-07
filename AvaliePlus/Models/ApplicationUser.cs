using Microsoft.AspNetCore.Identity;

namespace AvaliePlus.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Role { get; set; }



        // Campos personalizados, se quiser
    }

}
