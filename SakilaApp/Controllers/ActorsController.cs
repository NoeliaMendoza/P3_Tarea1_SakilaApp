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
    public class ActorsController : Controller
    {
        private readonly SakilaContext _context;

        public ActorsController(SakilaContext context)
        {
            _context = context;
        }

        // GET: Actors
        /*public async Task<IActionResult> Index()
        {
            return View(await _context.Actors.ToListAsync());
        }*/

        /*public async Task<IActionResult> Index()
        {
            var actores = await _context.Actors
                .Where(a => a.LastName.StartsWith("A"))
                .ToListAsync();

            return View(actores);
        }*/

        /*public async Task<IActionResult> Index(int pagina = 1)
        {
            const int pageSize = 10;
            string letra = "B";

            var consulta = _context.Actors
                .Where(a => EF.Functions.ILike(a.LastName, $"{letra}%"));

            pagina = Math.Max(1, pagina);
            var totalItems = await consulta.CountAsync();
            var totalPages = (int)Math.Ceiling((double)totalItems / pageSize);
            totalPages = Math.Max(1, totalPages);
            pagina = Math.Min(pagina, totalPages);

            var actores = await consulta
                .OrderBy(a => a.LastName)
                .Skip((pagina - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            ViewBag.PaginaActual = pagina;
            ViewBag.TotalPaginas = totalPages;

            return View(actores);
        }*/

        /*
        Ejercicio 12
        Mostrar los 5 actores cuyos nombres empiecen con N o terminen con N.
        */

        public async Task<IActionResult> Index()
        {
            var actores = await _context.Actors
                .Where(a => a.FirstName.StartsWith("N") || a.FirstName.EndsWith("N"))
                .Take(5)
                .ToListAsync();

            return View(actores);
        }





        // GET: Actors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var actor = await _context.Actors
                .FirstOrDefaultAsync(m => m.ActorId == id);
            if (actor == null)
            {
                return NotFound();
            }

            return View(actor);
        }

        // GET: Actors/Create
        [Authorize(Roles = "Administrador,Operador")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Actors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrador,Operador")]
        public async Task<IActionResult> Create([Bind("ActorId,FirstName,LastName,LastUpdate")] Actor actor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(actor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(actor);
        }

        // GET: Actors/Edit/5
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var actor = await _context.Actors.FindAsync(id);
            if (actor == null)
            {
                return NotFound();
            }
            return View(actor);
        }

        // POST: Actors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Edit(int id, [Bind("ActorId,FirstName,LastName,LastUpdate")] Actor actor)
        {
            if (id != actor.ActorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(actor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ActorExists(actor.ActorId))
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
            return View(actor);
        }

        // GET: Actors/Delete/5
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var actor = await _context.Actors
                .FirstOrDefaultAsync(m => m.ActorId == id);
            if (actor == null)
            {
                return NotFound();
            }

            return View(actor);
        }

        // POST: Actors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var actor = await _context.Actors.FindAsync(id);
            if (actor != null)
            {
                _context.Actors.Remove(actor);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ActorExists(int id)
        {
            return _context.Actors.Any(e => e.ActorId == id);
        }
    }
}
