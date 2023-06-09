using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using MovieStore.Models;
using MovieStore.Services;

namespace MovieStore.Controllers
{
    public class ActorsController : Controller
    {
        private readonly IActorsService _service;

        public ActorsController(IActorsService service)
        {
            _service = service;
        }



        public async Task<IActionResult> Index()
        {
            var test = await _service.GetAllAsync();
            return View(test); return View("NotFound");

        }
        [HttpGet]
        public  IActionResult Create()
        {
            return View();
        }

        public async Task<IActionResult> Create([Bind("FullName,ProfilePictureURL,Bio")] Actor actor)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            _service.AddAsync(actor);
            return RedirectToAction(nameof(Index));
                

        }




        public async Task<IActionResult> Details(int id)
        {
            var actorDetails = await _service.GetbyIdAsync(id);

         

            if (actorDetails == null) return View("NotFound");
            return View(actorDetails);
        }




        public async Task<IActionResult> Edit(int id)
        {
            var actorDetails = await _service.GetbyIdAsync(id);
            if (actorDetails == null) return View("NotFound");
            return View(actorDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id , [Bind("Id,FullName,ProfilePictureURL,Bio")] Actor actor)
        {
            if (!ModelState.IsValid)
            {
                return View(actor);
            }
            await _service.UpdateAsync( id, actor);
            return RedirectToAction(nameof(Index));
        }






        public async Task<IActionResult> Delete(int id)
        {
            var actorDetails = await _service.GetbyIdAsync(id);



            if (actorDetails == null) return View("NotFound");

            return View(actorDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            var actorDetails = await _service.GetbyIdAsync(id);



            if (actorDetails == null) return View("NotFound");


            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));



        }
    }
}