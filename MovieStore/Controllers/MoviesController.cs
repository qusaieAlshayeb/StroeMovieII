using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieStore.data.DataBase;

namespace MovieStore.Controllers
{
    public class MoviesController : Controller
    {
        private readonly AppDbContext _context;

        public MoviesController(AppDbContext context)
        {
            this._context = context;
        }

        public async Task<IActionResult> Index()
        {
            var AllMovies = await _context.Movies.Include(c => c.Cinema).ToListAsync();

            return View(AllMovies);
        }






    }
}