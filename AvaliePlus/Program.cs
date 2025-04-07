using AvaliePlus.Data;
using AvaliePlus.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AvaliePlus
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // ✅ Configura o EF com SQL Server
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("ApplicationDbContext")
                    ?? throw new InvalidOperationException("Connection string 'ApplicationDbContext' not found.")));

            // ✅ Configura a identidade (autenticação com Identity)
            builder.Services.AddIdentity<Usuario, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            // ✅ Adiciona suporte a sessão
            builder.Services.AddSession();

            // ✅ Adiciona suporte a MVC e Razor Pages com TempData baseado em sessão
            builder.Services.AddControllersWithViews()
                .AddSessionStateTempDataProvider();
            builder.Services.AddRazorPages();

            var app = builder.Build();

            // ✅ Aplica migrations e insere dados iniciais
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                var db = services.GetRequiredService<ApplicationDbContext>();
                db.Database.Migrate(); // Aplica migrations

                if (!db.Filmes.Any())
                {
                    db.Filmes.Add(new Filme
                    {
                        Titulo = "Aniquilação",
                        Genero = "Ficção Científica",
                        Diretor = "Alex Garland",
                        DuracaoMinutos = 115,
                        Sinopse = "Uma bióloga se junta a uma expedição secreta em uma zona misteriosa.",
                        ImagemUrl = "/images/aniquilacao.jpg",
                        Descricao = "Uma cientista entra em uma zona misteriosa conhecida como Área X."
                    });

                    db.SaveChanges();
                }

                // ✅ Criação de roles e usuário admin
                var userManager = services.GetRequiredService<UserManager<Usuario>>();
                var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

                string[] roles = { "Admin", "Usuario" };
                foreach (var role in roles)
                {
                    if (!await roleManager.RoleExistsAsync(role))
                    {
                        await roleManager.CreateAsync(new IdentityRole(role));
                    }
                }

                string adminEmail = "admin@admin.com";
                var existingUser = await userManager.FindByEmailAsync(adminEmail);
                if (existingUser == null)
                {
                    var adminUser = new Usuario
                    {
                        UserName = adminEmail,
                        Email = adminEmail,
                        Nome = "Administrador",
                        EmailConfirmed = true,
                        Role = "Admin"
                    };

                    var result = await userManager.CreateAsync(adminUser, "Admin@123");

                    if (result.Succeeded)
                    {
                        await userManager.AddToRoleAsync(adminUser, "Admin");
                    }
                }
            }

            // ✅ Configuração do pipeline HTTP
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseSession(); // <-- Adiciona isso antes da autenticação

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapRazorPages();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
