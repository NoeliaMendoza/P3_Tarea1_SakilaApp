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
    public class FilmsController : Controller
    {
        private readonly SakilaContext _context;

        public FilmsController(SakilaContext context)
        {
            _context = context;
        }

        // GET: Films
        /*public async Task<IActionResult> Index()
        {
            var sakilaContext = _context.Films
                .Include(f => f.Language)
                .Include(f => f.OriginalLanguage);

            // Duración de la película mayor que 0 y menor o igual a 6
            var films = await sakilaContext
                .Where(f => f.RentalDuration > 0 && f.RentalDuration <= 6)
                .ToListAsync();

            return View(films);
        }*/

        //Quiero alquilar una pelicula de mas o igual a 6 días
        /* public async Task<IActionResult> Index()
         {
             var sakilaContext = _context.Films
                 .Include(f => f.Language)
                 .Include(f => f.OriginalLanguage);

             var films = await sakilaContext
                 .Where(f => f.RentalDuration >= 6)
                 .OrderByDescending(f => f.RentalDuration)
                 .ToListAsync();

             return View(films);
         }*/

        /*public async Task<IActionResult> Index()
        {
            var sakilaContext = _context.Films
                .Include(f => f.Language)
                .Include(f => f.OriginalLanguage);

            // Pelicula que duracion de 1:30 a 2:00
            var films = await sakilaContext
                .Where(f => f.Length >= 90 && f.Length <= 120)
                .OrderBy(f => f.Length)
                .ToListAsync();

            return View(films);
        }*/

        /*public async Task<IActionResult> Index()
        {
            var sakilaContext = _context.Films
                .Include(f => f.Language)
                .Include(f => f.OriginalLanguage);

            //Peliculas que sean de drama
            string palabra = "drama";
            var films = await sakilaContext
                .Where(f => EF.Functions.ILike(f.Description, $"%{palabra}%"))
                .WHere(f => EF.Functions.Ilike(f.Description, $"%{palabra}%"))
                .Where(f => EF.Functions.ILike(f.Description, $"%{palabra}%"))
                .Where(f => EF.Fuctions.ILike(f.Description, $"%{palabra}%"))
                .ToListAsync();

            return View(films);
        }*/

        /*public async Task<IActionResult> Index()
        {
            var peliculas = await _context.Films
                .Where(f => f.Title.StartsWith("A"))
                .ToListAsync();
            return View(peliculas);
        }*/

        //Registros que terminen en A
        /*public async Task<IActionResult> Index()
        {
            var peliculas = await _context.Films
                .Where(f => f.Title.EndsWith("A"))
                .ToListAsync();

            return View(peliculas);
        }*/
        /*public async Task<IActionResult> Index()
        {
            var peliculas = await _context.Films
                .Where(f => f.Title.Contains("DINO"))
                .ToListAsync();

            return View(peliculas);
        }*/
        /*public async Task<IActionResult> Index()
        {
            var peliculas = await _context.Films
                .Where(f => f.Title.Contains("DINO"))
                .ToListAsync();

            return View(peliculas);
        }*/

        /*
        Mostrar todas las peliculas cuya d
        150
        */
        /*public async Task<IActionResult> Index()
        {
            var peliculas = await _context.Films
                .Where(f => f.Length >= 150)
                .ToListAsync();

            return View(peliculas);
        }*/
        /*public async Task<IActionResult> Index()
        {
            var peliculas = await _context.Films
                .Where(f => f.ReplacementCost > 25.50m)
                .ToListAsync();

            return View(peliculas);
        }*/


        //mayor a 100 min y tarifa de alquiler mayor o igual a 3,50
        /*public async Task<IActionResult> Index()
        {
            var peliculas = await _context.Films
                .Where(f => f.Length > 100 && f.RentalRate >= 3.50m)
                .ToListAsync();

            return View(peliculas);
        }*/


        // mayor a 100 min, titulo con LOVE, 
        /*public async Task<IActionResult> Index()
        {
            var peliculas = await _context.Films
                .Where(f => f.Length > 100 || f.Title.Contains("LOVE") && )
            
                .ToListAsync();

            return View(peliculas);
        }*/
        /*public async Task<IActionResult> Index()
        {
            var films = await _context.Films
                .Where(f => f.RentalDuration > 0 && f.RentalDuration <= 6)
                .ToListAsync();
            return View(films);
        }*/

        /*public async Task<IActionResult> Index()
        {
            var peliculas = await _context.Films
                .Join(_context.Languages,
                    film => film.LanguageId,
                    language => language.LanguageId,
                    (film, language) => film)
                .OrderBy(f => f.Title)
                .ToListAsync();

            return View(peliculas);
        }*/

        /*public async Task<IActionResult> Index()
        {
            var peliculas = await _context.Films
                .Join(_context.Languages,
                    film => film.LanguageId,
                    language => language.LanguageId,
                    (film, language) => new { film, language })
                .Where(x => x.language.Name == "English")
                .OrderBy(x => x.film.Title)
                .Select(x => x.film)
                .ToListAsync();

            return View(peliculas);
        }*/

        /*public async Task<IActionResult> Index()
        {
            var peliculas = await _context.Films
                .Join(_context.FilmCategories,
                    film => film.FilmId,
                    filmCategory => filmCategory.FilmId,
                    (film, filmCategory) => new { film, filmCategory })
                .Join(_context.Categories,
                    temp => temp.filmCategory.CategoryId,
                    category => category.CategoryId,
                    (temp, category) => new { temp.film, category })
                .Where(x => x.category.Name == "Action")
                .OrderBy(x => x.film.Title)
                .Select(x => x.film)
                .ToListAsync();

            return View(peliculas);
        }*/

        /*public async Task<IActionResult> Index()
        {
            var peliculas = await _context.Films
                .Join(_context.FilmCategories,
                    film => film.FilmId,
                    filmCategory => filmCategory.FilmId,
                    (film, filmCategory) => new { film, filmCategory })
                .Join(_context.Categories,
                    temp => temp.filmCategory.CategoryId,
                    category => category.CategoryId,
                    (temp, category) => new { temp.film, category })
                .Where(x => x.category.Name == "Drama")
                .OrderByDescending(x => x.film.Length)
                .Take(10)
                .Select(x => x.film)
                .ToListAsync();

            return View(peliculas);
        }*/

        /*public async Task<IActionResult> Index()
        {
            var peliculas = await _context.Films
                .Join(_context.Languages,
                    film => film.LanguageId,
                    language => language.LanguageId,
                    (film, language) => new { film, language })
                .Join(_context.FilmCategories,
                    temp => temp.film.FilmId,
                    filmCategory => filmCategory.FilmId,
                    (temp, filmCategory) => new { temp.film, temp.language, filmCategory })
                .Join(_context.Categories,
                    temp => temp.filmCategory.CategoryId,
                    category => category.CategoryId,
                    (temp, category) => new { temp.film, temp.language, category })
                .Where(x => x.language.Name == "English"
                         && x.category.Name == "Comedy"
                         && x.film.Title.StartsWith("A"))
                .OrderBy(x => x.film.Title)
                .Select(x => x.film)
                .ToListAsync();

            return View(peliculas);
        }*/

        /*public async Task<IActionResult> Index(string? buscar)
        {
            var consulta = _context.Films.AsQueryable();
            if (!string.IsNullOrWhiteSpace(buscar))
            {
                consulta = consulta.Where(f => f.Title.Contains(buscar));
            }
            var peliculas = await consulta
                .OrderBy(f => f.Title)
                .ToListAsync();
            ViewBag.Buscar = buscar;
            return View(peliculas);
        }*/

        /*public async Task<IActionResult> Index(string? buscar, int? duracionMinima, int pagina = 1)
        {
            const int pageSize = 10;
            var consulta = _context.Films.AsQueryable();

            if (!string.IsNullOrWhiteSpace(buscar))
            {
                consulta = consulta.Where(f => f.Title.Contains(buscar));
            }

            if (duracionMinima.HasValue)
            {
                consulta = consulta.Where(f => f.Length >= duracionMinima.Value);
            }

            pagina = Math.Max(1, pagina);
            var totalItems = await consulta.CountAsync();
            var totalPages = (int)Math.Ceiling((double)totalItems / pageSize);
            totalPages = Math.Max(1, totalPages);
            pagina = Math.Min(pagina, totalPages);

            var peliculas = await consulta
                .OrderBy(f => f.Title)
                .Skip((pagina - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            ViewBag.Buscar = buscar;
            ViewBag.DuracionMinima = duracionMinima;
            ViewBag.PaginaActual = pagina;
            ViewBag.TotalPaginas = totalPages;
            ViewBag.PageSize = pageSize;

            return View(peliculas);
        }*/

        /*public async Task<IActionResult> Index()
        {
            var peliculas = await _context.Films
                .Join(_context.FilmCategories,
                    film => film.FilmId,
                    filmCategory => filmCategory.FilmId,
                    (film, filmCategory) => new { film, filmCategory })
                .Join(_context.Categories,
                    temp => temp.filmCategory.CategoryId,
                    category => category.CategoryId,
                    (temp, category) => new { temp.film, category })
                .Join(_context.FilmActors,
                    temp => temp.film.FilmId,
                    filmActor => filmActor.FilmId,
                    (temp, filmActor) => new { temp.film, temp.category, filmActor })
                .Join(_context.Actors,
                    temp => temp.filmActor.ActorId,
                    actor => actor.ActorId,
                    (temp, actor) => new { temp.film, temp.category, actor })
                .Where(x => x.category.Name == "Horror"
                         && x.actor.LastName.EndsWith("S"))
                .Select(x => x.film)
                .Distinct()
                .Take(10)
                .ToListAsync();

            return View(peliculas);
        }*/

        /*public async Task<IActionResult> Index()
        {
            var peliculas = await _context.Films
                .Join(_context.FilmCategories,
                    film => film.FilmId,
                    filmCategory => filmCategory.FilmId,
                    (film, filmCategory) => new { film, filmCategory })
                .Join(_context.Categories,
                    temp => temp.filmCategory.CategoryId,
                    category => category.CategoryId,
                    (temp, category) => new { temp.film, category })
                .Join(_context.FilmActors,
                    temp => temp.film.FilmId,
                    filmActor => filmActor.FilmId,
                    (temp, filmActor) => new { temp.film, temp.category, filmActor })
                .Join(_context.Actors,
                    temp => temp.filmActor.ActorId,
                    actor => actor.ActorId,
                    (temp, actor) => new { temp.film, temp.category, actor })
                .Where(x => x.category.Name == "Horror"
                         && x.actor.LastName.EndsWith("S"))
                .Select(x => x.film)
                .Distinct()
                .Take(10)
                .ToListAsync();

            return View(peliculas);
        }*/

        /*public async Task<IActionResult> Index()
        {
            var peliculas = await _context.Films
            .Include(f => f.FilmCategories)
                .ThenInclude(fc => fc.Category)
            .Include(f => f.FilmActors)
                .ThenInclude(fa => fa.Actor)
            .Where(f =>
                f.FilmCategories.Any(fc => fc.Category.Name == "Horror") &&
                f.FilmActors.Any(fa => fa.Actor.LastName.EndsWith("S")))
            .Take(10)
            .ToListAsync();
            return View(peliculas);
        }*/

        /*public async Task<IActionResult> Index()
        {
            var peliculas = await _context.Films
            .Include(f => f.FilmActors)
                .ThenInclude(fa => fa.Actor)
            .Where(f => f.FilmActors
                .Any(fa => fa.Actor.LastName.StartsWith("S")))
            .Take(10)
            .ToListAsync();
            return View(peliculas);
        }*/


        /*
        Ejercicio 25
        Mostrar las 10 películas de categoría Family ordenadas por título.

        */
        /*public async Task<IActionResult> Index()
        {
            var peliculas = await _context.Films
            .Include(f => f.FilmCategories)
                .ThenInclude(fa => fa.Category)
            .Where(f => f.FilmCategories
                .Any(fc => fc.Category.Name == "Family"))
            .OrderBy(f => f.Title)
            .ToListAsync();
            return View(peliculas);
        }*/

        /*
        Ejercicio 24
        Mostrar las 5 películas de categoría Horror omitiendo la primera.
        */

        /*public async Task<IActionResult> Index()
        {
            var peliculas = await _context.Films
            .Include(f => f.FilmCategories)
                .ThenInclude(fa => fa.Category)
            .Where(f => f.FilmCategories.Any(fc => fc.Category.Name == "Horror"))
            .Skip(1)
            .Take(5)
            .ToListAsync();
            return View(peliculas);
        }*/

        /*
        Ejercicio 26
        Mostrar las 10 películas de categoría Animation cuya duración sea mayor a 100 minutos.

        */

        /*public async Task<IActionResult> Index()
        {
            var peliculas = await _context.Films
            .Include(f => f.FilmCategories)
                .ThenInclude(fa => fa.Category)
            .Where(f => f.FilmCategories.Any(fc => fc.Category.Name == "Animation") && f.Length > 100)
            .Take(10)
            .ToListAsync();
            return View(peliculas);
        }*/

        /*
        Ejercicio 10
        Mostrar las 10 películas cuyo título empiece con A o termine con N.
        */
        /*public async Task<IActionResult> Index()
        {
            var peliculas = await _context.Films
                .Where(f => f.Title.StartsWith("A") || f.Title.EndsWith("N"))
                .Take(10)
                .ToListAsync();
            return View(peliculas);
        }*/

        /*
        Ejercicio 31
        Mostrar las 10 películas en las que participe un actor cuyo apellido empiece con S.
        */

        /*public async Task<IActionResult> Index()
        {
            var peliculas = await _context.Films
            .Include(f => f.FilmActors)
                .ThenInclude(fa => fa.Actor)
            .Where(f => f.FilmActors.Any(fa => fa.Actor.FirstName.StartsWith("S")))
            .Take(10)
            .ToListAsync();
            return View(peliculas);
        }*/


        /*
        Ejercicio 3
        Mostrar las 10 películas cuyo título contenga la palabra LOVE.
        */
        /*public async Task<IActionResult> Index()
        {
            var peliculas = await _context.Films
            .Where(f => f.Title.Contains("LOVE"))
            .Take(10)
            .ToListAsync();
            return View(peliculas);
        }*/

        /*public async Task<IActionResult> Index()
        {
            var peliculas = await _context.Films
            .Where(f => f.Title.Contains("LOVE") || f.RentalRate == 4.99m)
            .Take(10)
            .ToListAsync();
            return View(peliculas);
        }*/


        /* public async Task<IActionResult> Index()
         {
             var peliculas = await _context.Films
             .Where(f => f.Title.StartsWith("A") || f.Title.EndsWith("N"))
             .Take(10)
             .ToListAsync();
             return View(peliculas);
         }

        public async Task<IActionResult> Index()
        {
            var peliculas = await _context.Films
            .Include(f => f.Language)
            .Where(f => f.Language.Name.Trim() != "English")
            .OrderByDescending(f => f.Length)
            .Take(5)
            .ToListAsync();
            return View(peliculas);
        }
        


        public async Task<IActionResult> Index()
        {
            var peliculas = await _context.Films
            .Include(f => f.Language)
            .Where(f => f.Language.Name.Trim() == "English")
            .OrderByDescending(f => f.Length)
            .Skip(1)
            .Take(10)
            .ToListAsync();
            return View(peliculas);
        }


        public async Task<IActionResult> Index()
        {
            var peliculas = await _context.Films
            .Include(f => f.FilmCategories)
                .ThenInclude(fc => fc.Category)
            .Where(f => f.FilmCategories.Any(fc => fc.Category.Name == "Comedy")
                    && f.Length > 120)
            .Take(5)
            .ToListAsync();
            return View(peliculas);
        }

        public async Task<IActionResult> Index()
        {
            var peliculas = await _context.Films
            .Include(f => f.FilmCategories)
                .ThenInclude(fc => fc.Category)
            .Where(f => f.FilmCategories.Any(fc => fc.Category.Name == "Drama")
                    && f.Title.StartsWith("M"))
            .Take(10)
            .ToListAsync();
            return View(peliculas);
        }
        



        public async Task<IActionResult> Index()
        {
            var peliculas = await _context.Films
            .Include(f => f.FilmCategories)
                .ThenInclude(fc => fc.Category)
            .Include(f => f.FilmActors)
                .ThenInclude(fa => fa.Actor)
            .Where(f => f.FilmCategories.Any(fc => fc.Category.Name == "Horror")
                    && f.FilmActors.Any(fa => fa.Actor.LastName.EndsWith("S")))
            .Take(10)
            .ToListAsync();
            return View(peliculas);
        }
        


        public async Task<IActionResult> Index()
        {
            var peliculas = await _context.Films
            .Include(f => f.FilmCategories)
                .ThenInclude(fc => fc.Category)
            .Include(f => f.FilmActors)
                .ThenInclude(fa => fa.Actor)
            .Where(f => f.FilmCategories.Any(fc => fc.Category.Name == "Family")
                    && f.FilmActors.Any(fa => fa.Actor.FirstName.StartsWith("J")))
            .Take(5)
            .ToListAsync();
            return View(peliculas);
        }
*/


        /*public async Task<IActionResult> Index()
        {
            var peliculas = await _context.Films
            .Include(f => f.FilmCategories)
                .ThenInclude(fc => fc.Category)
            .Include(f => f.FilmActors)
                .ThenInclude(fa => fa.Actor)
            .Where(f => f.FilmCategories.Any(fc => fc.Category.Name == "Comedy")
                    && f.FilmActors.Any(fa => fa.Actor.LastName.Contains("R"))
                    && f.Length > 100)
            .Take(10)
            .ToListAsync();
            return View(peliculas);
        }*/

        public async Task<IActionResult> Index()
        {
            var peliculas = await _context.Films
            .Include(f => f.FilmCategories)
                .ThenInclude(fc => fc.Category)
            .Where(f => f.FilmCategories.Any(fc => fc.Category.Name == "Family"))
            .OrderByDescending(f => f.Length)
            .Take(5)
            .ToListAsync();
            return View(peliculas);
        }


        // GET: Films/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var film = await _context.Films
                .Include(f => f.Language)
                .Include(f => f.OriginalLanguage)
                .FirstOrDefaultAsync(m => m.FilmId == id);
            if (film == null)
            {
                return NotFound();
            }

            return View(film);
        }

        // GET: Films/Create
        [Authorize(Roles = "Administrador,Supervisor")]
        public IActionResult Create()
        {
            ViewData["LanguageId"] = new SelectList(_context.Languages, "LanguageId", "LanguageId");
            ViewData["OriginalLanguageId"] = new SelectList(_context.Languages, "LanguageId", "LanguageId");
            return View();
        }

        // POST: Films/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrador,Supervisor")]
        public async Task<IActionResult> Create([Bind("FilmId,Title,Description,ReleaseYear,LanguageId,OriginalLanguageId,RentalDuration,RentalRate,Length,ReplacementCost,LastUpdate,SpecialFeatures,Fulltext")] Film film)
        {
            if (ModelState.IsValid)
            {
                _context.Add(film);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LanguageId"] = new SelectList(_context.Languages, "LanguageId", "LanguageId", film.LanguageId);
            ViewData["OriginalLanguageId"] = new SelectList(_context.Languages, "LanguageId", "LanguageId", film.OriginalLanguageId);
            return View(film);
        }

        // GET: Films/Edit/5
        [Authorize(Roles = "Administrador,Supervisor")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var film = await _context.Films.FindAsync(id);
            if (film == null)
            {
                return NotFound();
            }
            ViewData["LanguageId"] = new SelectList(_context.Languages, "LanguageId", "LanguageId", film.LanguageId);
            ViewData["OriginalLanguageId"] = new SelectList(_context.Languages, "LanguageId", "LanguageId", film.OriginalLanguageId);
            return View(film);
        }

        // POST: Films/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrador,Supervisor")]

        public async Task<IActionResult> Edit(int id, [Bind("FilmId,Title,Description,ReleaseYear,LanguageId,OriginalLanguageId,RentalDuration,RentalRate,Length,ReplacementCost,LastUpdate,SpecialFeatures,Fulltext")] Film film)
        {
            if (id != film.FilmId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(film);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FilmExists(film.FilmId))
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
            ViewData["LanguageId"] = new SelectList(_context.Languages, "LanguageId", "LanguageId", film.LanguageId);
            ViewData["OriginalLanguageId"] = new SelectList(_context.Languages, "LanguageId", "LanguageId", film.OriginalLanguageId);
            return View(film);
        }

        // GET: Films/Delete/5
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var film = await _context.Films
                .Include(f => f.Language)
                .Include(f => f.OriginalLanguage)
                .FirstOrDefaultAsync(m => m.FilmId == id);
            if (film == null)
            {
                return NotFound();
            }

            return View(film);
        }

        // POST: Films/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var film = await _context.Films.FindAsync(id);
            if (film != null)
            {
                _context.Films.Remove(film);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FilmExists(int id)
        {
            return _context.Films.Any(e => e.FilmId == id);
        }
    }
}
