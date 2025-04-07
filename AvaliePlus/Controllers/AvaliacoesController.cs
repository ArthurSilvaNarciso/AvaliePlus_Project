using AvaliePlus.Data;
using AvaliePlus.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace AvaliePlus.Controllers
{
    public class AvaliacoesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AvaliacoesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Create(int filmeId, string comentario)
        {
            if (string.IsNullOrWhiteSpace(comentario))
                return BadRequest("Comentário não pode estar vazio.");

            var filme = await _context.Filmes.FindAsync(filmeId);
            if (filme == null)
                return NotFound("Filme não encontrado.");

            var avaliacao = new Avaliacao
            {
                FilmeId = filmeId,
                Comentario = comentario,
                Usuario = User.Identity?.Name ?? "Anônimo"
            };

            _context.Avaliacoes.Add(avaliacao);
            await _context.SaveChangesAsync();

            TempData["MensagemSucesso"] = "Avaliacao registrada com sucesso!";
            return RedirectToAction("Index", "Home");
        }
        // GET: Avaliacoes/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var avaliacao = await _context.Avaliacoes.FindAsync(id);
            if (avaliacao == null)
                return NotFound();

            return View(avaliacao);
        }

        // POST: Avaliacoes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, string Comentario)
        {
            var avaliacao = await _context.Avaliacoes.FindAsync(id);
            if (avaliacao == null)
                return NotFound();

            avaliacao.Comentario = Comentario;
            await _context.SaveChangesAsync();

            TempData["MensagemSucesso"] = "Avaliacao editada com sucesso!";
            return RedirectToAction("Index", "Home");
        }

        // GET: Avaliacoes/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var avaliacao = await _context.Avaliacoes.FindAsync(id);
            if (avaliacao == null)
                return NotFound();

            _context.Avaliacoes.Remove(avaliacao);
            await _context.SaveChangesAsync();

            TempData["MensagemSucesso"] = "Avaliacao excluida com sucesso!";
            return RedirectToAction("Index", "Home");
        }
    }
}
