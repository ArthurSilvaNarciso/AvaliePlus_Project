// FILE CONTEXT
using AvaliePlus.Controllers;
using AvaliePlus.Data;
using AvaliePlus.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AvaliePlus.Models;
using AvaliePlus.Data;
using Microsoft.CodeAnalysis.Elfie.Serialization;

namespace AvaliePlus.Controllers
{
    public class FilmesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FilmesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Filmes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Filmes.ToListAsync());
        }

        // GET: Filmes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filme = await _context.Filmes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (filme == null)
            {
                return NotFound();
            }

            return View(filme);
        }

        // GET: Filmes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Filmes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int Id, string Titulo, string Diretor, string Genero, int Ano, int DuracaoMinutos, string Descricao, string ImagemUrl, string Sinopse)
        {
            var filme = new Filme
            {
                Id = Id,
                Titulo = Titulo,
                Diretor = Diretor,
                Genero = Genero,
                Ano = Ano,
                DuracaoMinutos = DuracaoMinutos,
                Descricao = Descricao,
                ImagemUrl = ImagemUrl,
                Sinopse = Sinopse
            };

            if (ModelState.IsValid)
            {
                _context.Add(filme);
                await _context.SaveChangesAsync();

                TempData["MensagemSucesso"] = "Filme cadastrado com sucesso!";
                return RedirectToAction(nameof(Index));
            }

            return View(filme);
        }


        // GET: Filmes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filme = await _context.Filmes.FindAsync(id);
            if (filme == null)
            {
                return NotFound();
            }
            return View(filme);
        }

        // POST: Filmes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, string Titulo, string Diretor, string Genero, int Ano, int DuracaoMinutos, string Descricao, string ImagemUrl, string Sinopse)
        {
            var filmeEncontrado = await _context.Filmes.FindAsync(id);
            if (filmeEncontrado == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                filmeEncontrado.Titulo = Titulo;
                filmeEncontrado.Diretor = Diretor;
                filmeEncontrado.Genero = Genero;
                filmeEncontrado.Ano = Ano;
                filmeEncontrado.DuracaoMinutos = DuracaoMinutos;
                filmeEncontrado.Descricao = Descricao;
                filmeEncontrado.ImagemUrl = ImagemUrl;
                filmeEncontrado.Sinopse = Sinopse;

                try
                {
                    _context.Update(filmeEncontrado);
                    await _context.SaveChangesAsync();

                    TempData["MensagemSucesso"] = "Filme editado com sucesso!";
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Filmes.Any(e => e.Id == id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }

            return View(filmeEncontrado);
        }

        // GET: Filmes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filme = await _context.Filmes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (filme == null)
            {
                return NotFound();
            }

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

            TempData["MensagemSucesso"] = "Filme apagado com sucesso!";
            return RedirectToAction("Index", "Filmes");
        }
    }
}
