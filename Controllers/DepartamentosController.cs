using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Academico.Data;
using Academico.Models;

namespace Academico.Controllers
{
    public class DepartamentosController : Controller
    {
        private readonly AcademicoContext _context;

        public DepartamentosController(AcademicoContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var departamentos = _context.Departamentos.Include(d => d.Instituicao);
            return View(await departamentos.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var departamento = await _context.Departamentos
                .Include(d => d.Instituicao)
                .FirstOrDefaultAsync(m => m.DepartamentoID == id);

            if (departamento == null)
            {
                return NotFound();
            }

            return View(departamento);
        }

        public IActionResult Create()
        {
            ViewData["InstituicaoID"] = new SelectList(_context.Instituicoes, "InstituicaoID", "Nome");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DepartamentoID,Nome,InstituicaoID")] Departamento departamento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(departamento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["InstituicaoID"] = new SelectList(_context.Instituicoes, "InstituicaoID", "Nome", departamento.InstituicaoID);
            return View(departamento);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var departamento = await _context.Departamentos.FindAsync(id);

            if (departamento == null)
            {
                return NotFound();
            }

            ViewData["InstituicaoID"] = new SelectList(_context.Instituicoes, "InstituicaoID", "Nome", departamento.InstituicaoID);
            return View(departamento);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DepartamentoID,Nome,InstituicaoID")] Departamento departamento)
        {
            if (id != departamento.DepartamentoID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(departamento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DepartamentoExists(departamento.DepartamentoID))
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
            ViewData["InstituicaoID"] = new SelectList(_context.Instituicoes, "InstituicaoID", "Nome", departamento.InstituicaoID);
            return View(departamento);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var departamento = await _context.Departamentos
                .Include(d => d.Instituicao)
                .FirstOrDefaultAsync(m => m.DepartamentoID == id);

            if (departamento == null)
            {
                return NotFound();
            }

            return View(departamento);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var departamento = await _context.Departamentos.FindAsync(id);
            if (departamento != null)
            {
                _context.Departamentos.Remove(departamento);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DepartamentoExists(int id)
        {
            return _context.Departamentos.Any(e => e.DepartamentoID == id);
        }
    }
}
