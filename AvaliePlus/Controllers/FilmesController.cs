using AvaliePlus.Data;
using AvaliePlus.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AvaliePlus.Controllers
{
    public class FilmesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FilmesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // ✅ GET: Filmes (com paginação)
        public async Task<IActionResult> Index(int page = 1)
        {
            int pageSize = 8;

            var filmes = await _context.Filmes
                .OrderBy(f => f.Titulo)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            int totalFilmes = await _context.Filmes.CountAsync();
            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = (int)Math.Ceiling(totalFilmes / (double)pageSize);

            return View(filmes);
        }

        // GET: Filmes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var filme = await _context.Filmes.FirstOrDefaultAsync(m => m.Id == id);
            if (filme == null) return NotFound();

            return View(filme);
        }

        // ✅ GET: Filmes/Create
        public IActionResult Create()
        {
            return View();
        }

        // ✅ POST: Filmes/Create (redireciona corretamente para a última página após salvar)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Titulo,Diretor,Genero,Ano,DuracaoMinutos,Descricao,ImagemUrl,Sinopse")] Filme filme)
        {
            if (ModelState.IsValid)
            {
                // 1. Adiciona o novo filme ao contexto
                _context.Add(filme);
                await _context.SaveChangesAsync(); // 2. Salva no banco de dados

                // 3. Reconta o total de filmes e calcula a última página
                int totalFilmes = await _context.Filmes.CountAsync();
                int pageSize = 8;
                int ultimaPagina = (int)Math.Ceiling(totalFilmes / (double)pageSize);

                // 4. Redireciona para a última página
                return RedirectToAction("Index", new { page = ultimaPagina });
            }

            // 5. Se houver erro de validação, retorna à view
            return View(filme);
        }

        // GET: Filmes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var filme = await _context.Filmes.FindAsync(id);
            if (filme == null) return NotFound();

            return View(filme);
        }

        // POST: Filmes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Titulo,Diretor,Genero,Ano,DuracaoMinutos,Descricao,ImagemUrl,Sinopse")] Filme filme)
        {
            if (id != filme.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(filme);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FilmeExists(filme.Id)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(filme);
        }

        // GET: Filmes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var filme = await _context.Filmes.FirstOrDefaultAsync(m => m.Id == id);
            if (filme == null) return NotFound();

            return View(filme);
        }

        // POST: Filmes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var filme = await _context.Filmes.FindAsync(id);
            if (filme != null)
            {
                _context.Filmes.Remove(filme);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FilmeExists(int id)
        {
            return _context.Filmes.Any(e => e.Id == id);
        }
    }
}
