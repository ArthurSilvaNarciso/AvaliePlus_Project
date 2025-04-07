using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using AvaliePlus.Models;

namespace AvaliePlus.Data
{
    public class ApplicationDbContext : IdentityDbContext<Usuario>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Filme> Filmes { get; set; }
        public DbSet<Avaliacao> Avaliacoes { get; set; }
        // Não precisa repetir DbSet<Usuario> pois já é gerenciado pelo Identity
    }
}
