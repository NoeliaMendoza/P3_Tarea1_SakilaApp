using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SakilaApp.Data;
using SakilaApp.Models;
using Microsoft.AspNetCore.Authorization;

namespace SakilaApp.Controllers
{
    [Authorize]
    public class LanguagesController : Controller
    {
        private readonly SakilaContext _context;

        public LanguagesController(SakilaContext context)
        {
            _context = context;
        }

        // GET: Languages
        public async Task<IActionResult> Index(int pagina = 1)
        {
            const int pageSize = 10;
            var consulta = _context.Languages.AsQueryable();

            pagina = Math.Max(1, pagina);
            var totalItems = await consulta.CountAsync();
            var totalPages = (int)Math.Ceiling((double)totalItems / pageSize);
            totalPages = Math.Max(1, totalPages);
            pagina = Math.Min(pagina, totalPages);

            var languages = await consulta
                .OrderBy(l => l.Name)
                .Skip((pagina - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            ViewBag.PaginaActual = pagina;
            ViewBag.TotalPaginas = totalPages;

            return View(languages);
        }

        // GET: Languages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var language = await _context.Languages
                .FirstOrDefaultAsync(m => m.LanguageId == id);
            if (language == null)
            {
                return NotFound();
            }

            return View(language);
        }

        // GET: Languages/Create
        [Authorize(Roles = "Administrador")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Languages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Create([Bind("LanguageId,Name,LastUpdate")] Language language)
        {
            if (ModelState.IsValid)
            {
                _context.Add(language);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(language);
        }

        // GET: Languages/Edit/5
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var language = await _context.Languages.FindAsync(id);
            if (language == null)
            {
                return NotFound();
            }
            return View(language);
        }

        // POST: Languages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrador")]

        public async Task<IActionResult> Edit(int id, [Bind("LanguageId,Name,LastUpdate")] Language language)
        {
            if (id != language.LanguageId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(language);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LanguageExists(language.LanguageId))
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
            return View(language);
        }

        // GET: Languages/Delete/5
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var language = await _context.Languages
                .FirstOrDefaultAsync(m => m.LanguageId == id);
            if (language == null)
            {
                return NotFound();
            }

            return View(language);
        }

        // POST: Languages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var language = await _context.Languages.FindAsync(id);
            if (language != null)
            {
                _context.Languages.Remove(language);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LanguageExists(int id)
        {
            return _context.Languages.Any(e => e.LanguageId == id);
        }
    }
}
