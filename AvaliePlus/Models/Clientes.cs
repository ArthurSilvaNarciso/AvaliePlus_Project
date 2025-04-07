using Microsoft.AspNetCore.Identity;

namespace AvaliePlus.Models
{
    public class Clientes : IdentityUser
    {
        public string Nome { get; set; }
    }
}
