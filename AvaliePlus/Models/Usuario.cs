using Microsoft.AspNetCore.Identity;

namespace AvaliePlus.Models
{
    public class Usuario : IdentityUser
    {
        public string Nome { get; set; }
        public string Role { get; set; }
    }
}
