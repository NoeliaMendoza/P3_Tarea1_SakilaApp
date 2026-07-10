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
    public class FilmActorsController : Controller
    {
        private readonly SakilaContext _context;

        public FilmActorsController(SakilaContext context)
        {
            _context = context;
        }

        // GET: FilmActors
        public async Task<IActionResult> Index(int pagina = 1)
        {
            const int pageSize = 10;
            var consulta = _context.FilmActors.Include(f => f.Actor).Include(f => f.Film);

            pagina = Math.Max(1, pagina);
            var totalItems = await consulta.CountAsync();
            var totalPages = (int)Math.Ceiling((double)totalItems / pageSize);
            totalPages = Math.Max(1, totalPages);
            pagina = Math.Min(pagina, totalPages);

            var filmActors = await consulta
                .OrderBy(f => f.ActorId)
                .ThenBy(f => f.FilmId)
                .Skip((pagina - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            ViewBag.PaginaActual = pagina;
            ViewBag.TotalPaginas = totalPages;

            return View(filmActors);
        }

        // GET: FilmActors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filmActor = await _context.FilmActors
                .Include(f => f.Actor)
                .Include(f => f.Film)
                .FirstOrDefaultAsync(m => m.ActorId == id);
            if (filmActor == null)
            {
                return NotFound();
            }

            return View(filmActor);
        }

        // GET: FilmActors/Create
        [Authorize(Roles = "Administrador,Supervisor")]
        public IActionResult Create()
        {
            ViewData["ActorId"] = new SelectList(_context.Actors, "ActorId", "ActorId");
            ViewData["FilmId"] = new SelectList(_context.Films, "FilmId", "FilmId");
            return View();
        }

        // POST: FilmActors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrador,Supervisor")]
        public async Task<IActionResult> Create([Bind("ActorId,FilmId,LastUpdate")] FilmActor filmActor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(filmActor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ActorId"] = new SelectList(_context.Actors, "ActorId", "ActorId", filmActor.ActorId);
            ViewData["FilmId"] = new SelectList(_context.Films, "FilmId", "FilmId", filmActor.FilmId);
            return View(filmActor);
        }

        // GET: FilmActors/Edit/5

        [Authorize(Roles = "Administrador,Supervisor")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filmActor = await _context.FilmActors.FindAsync(id);
            if (filmActor == null)
            {
                return NotFound();
            }
            ViewData["ActorId"] = new SelectList(_context.Actors, "ActorId", "ActorId", filmActor.ActorId);
            ViewData["FilmId"] = new SelectList(_context.Films, "FilmId", "FilmId", filmActor.FilmId);
            return View(filmActor);
        }

        // POST: FilmActors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrador,Supervisor")]
        public async Task<IActionResult> Edit(int id, [Bind("ActorId,FilmId,LastUpdate")] FilmActor filmActor)
        {
            if (id != filmActor.ActorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(filmActor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FilmActorExists(filmActor.ActorId))
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
            ViewData["ActorId"] = new SelectList(_context.Actors, "ActorId", "ActorId", filmActor.ActorId);
            ViewData["FilmId"] = new SelectList(_context.Films, "FilmId", "FilmId", filmActor.FilmId);
            return View(filmActor);
        }

        // GET: FilmActors/Delete/5
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filmActor = await _context.FilmActors
                .Include(f => f.Actor)
                .Include(f => f.Film)
                .FirstOrDefaultAsync(m => m.ActorId == id);
            if (filmActor == null)
            {
                return NotFound();
            }

            return View(filmActor);
        }

        // POST: FilmActors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var filmActor = await _context.FilmActors.FindAsync(id);
            if (filmActor != null)
            {
                _context.FilmActors.Remove(filmActor);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FilmActorExists(int id)
        {
            return _context.FilmActors.Any(e => e.ActorId == id);
        }
    }
}
