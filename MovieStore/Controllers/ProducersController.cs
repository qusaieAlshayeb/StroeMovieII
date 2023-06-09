using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieStore.data.DataBase;
using MovieStore.Models;
using MovieStore.Services;

namespace MovieStore.Controllers
{
    public class ProducersController : Controller
    {


        private readonly IProducerService _Context;

        public ProducersController(IProducerService context)
        {
            _Context = context;
        }

        public async Task<IActionResult> Index()
        {
            var AllProducers = await _Context.GetAllAsync();
            return View(AllProducers); return View("NotFound");
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        public async Task<IActionResult> Create([Bind("FullName,ProfilePictureURL,Bio")] Producer producer)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            await _Context.AddAsync(producer);
            return RedirectToAction(nameof(Index));


        }


        public async Task<IActionResult> Details(int id)
        {
            var actorDetails = await _Context.GetbyIdAsync(id);



            if (actorDetails == null) return View("NotFound");
            return View(actorDetails);
        }

            public async Task<IActionResult> Edit(int id)
            {
                var actorDetails = await _Context.GetbyIdAsync(id);
                if (actorDetails == null) return View("NotFound");
                return View(actorDetails);
            }

            [HttpPost]
            public async Task<IActionResult> Edit(int id, [Bind("Id,FullName,ProfilePictureURL,Bio")] Producer producer)
            {
                if (!ModelState.IsValid)
                {
                    return View(producer);
                }
                await _Context.UpdateAsync(id, producer);
                return RedirectToAction(nameof(Index));
            }






        public async Task<IActionResult> Delete(int id)
        {
            var actorDetails = await _Context.GetbyIdAsync(id);



            if (actorDetails == null) return View("NotFound");

            return View(actorDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            var actorDetails = await _Context.GetbyIdAsync(id);



            if (actorDetails == null) return View("NotFound");


            await _Context.DeleteAsync(id);
            return RedirectToAction(nameof(Index));

           





        }
    }
}