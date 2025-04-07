using AvaliePlus.Data;
using AvaliePlus.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AvaliePlus.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UsuariosController(ApplicationDbContext context)
        {
            _context = context;
        }

        private bool UsuarioEhAdmin()
        {
            return HttpContext.Session.GetString("UserRole") == "Admin";
        }

        // GET: Usuarios
        public IActionResult Index()
        {
            if (!UsuarioEhAdmin())
                return RedirectToAction("Index", "Home");

            var usuarios = _context.Users.ToList();
            return View(usuarios);
        }

        // GET: Usuarios/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (!UsuarioEhAdmin())
                return RedirectToAction("Index", "Home");

            if (id == null) return NotFound();

            var usuario = await _context.Users.FindAsync(id);
            if (usuario == null) return NotFound();

            return View(usuario);
        }

        // POST: Usuarios/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, Usuario usuario)
        {
            if (!UsuarioEhAdmin())
                return RedirectToAction("Index", "Home");

            if (id != usuario.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    var user = await _context.Users.FindAsync(id);
                    if (user == null) return NotFound();

                    user.Nome = usuario.Nome;
                    user.Email = usuario.Email;
                    user.UserName = usuario.Email;
                    user.Role = usuario.Role;

                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Users.Any(u => u.Id == usuario.Id))
                        return NotFound();
                    else
                        throw;
                }

                return RedirectToAction(nameof(Index));
            }
            return View(usuario);
        }

        // GET: Usuarios/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (!UsuarioEhAdmin())
                return RedirectToAction("Index", "Home");

            if (id == null) return NotFound();

            var usuario = await _context.Users.FindAsync(id);
            if (usuario == null) return NotFound();

            return View(usuario);
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (!UsuarioEhAdmin())
                return RedirectToAction("Index", "Home");

            var usuario = await _context.Users.FindAsync(id);
            if (usuario != null)
            {
                _context.Users.Remove(usuario);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
