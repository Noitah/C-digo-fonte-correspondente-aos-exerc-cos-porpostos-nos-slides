using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Academico.Data;
using Academico.Models;

namespace Academico.Controllers
{
    public class InstituicoesController : Controller
    {
        private readonly AcademicoContext _context;

        public InstituicoesController(AcademicoContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Instituicoes.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var instituicao = await _context.Instituicoes
                .FirstOrDefaultAsync(m => m.InstituicaoID == id);

            if (instituicao == null)
            {
                return NotFound();
            }

            return View(instituicao);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("InstituicaoID,Nome,Endereco")] Instituicao instituicao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(instituicao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(instituicao);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var instituicao = await _context.Instituicoes.FindAsync(id);

            if (instituicao == null)
            {
                return NotFound();
            }

            return View(instituicao);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("InstituicaoID,Nome,Endereco")] Instituicao instituicao)
        {
            if (id != instituicao.InstituicaoID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(instituicao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InstituicaoExists(instituicao.InstituicaoID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(instituicao);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var instituicao = await _context.Instituicoes
                .FirstOrDefaultAsync(m => m.InstituicaoID == id);

            if (instituicao == null)
            {
                return NotFound();
            }

            return View(instituicao);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var instituicao = await _context.Instituicoes.FindAsync(id);
            if (instituicao != null)
            {
                _context.Instituicoes.Remove(instituicao);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InstituicaoExists(int id)
        {
            return _context.Instituicoes.Any(e => e.InstituicaoID == id);
        }
    }
}
