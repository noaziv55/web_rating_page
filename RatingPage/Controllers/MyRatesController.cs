using Microsoft.AspNetCore.Mvc;
using RatingPage.Models;
using RatingPage.Services;

namespace RatingPage.Controllers
{
    public class MyRatesController : Controller
    {

        private IRateService service;

        public MyRatesController()
        {
            service = new RateService();
        }
        
        public IActionResult Index()
        {
            return View(service.GetAllRates());
        }

        public IActionResult Search()
        {
            return View( service.GetAllRates());
        }

        [HttpPost]
        public IActionResult Search(string query)

        {
            var q = from rate in service.GetAllRates()
                    where rate.Feedback.Contains(query)
                    select rate;

            return View(q.ToList());
        }

        public IActionResult Details(int id)
        {
            return View(service.Get(id));
        }
        public IActionResult Create()
        {
           
            return View();
        }
        [HttpPost]
        public IActionResult Create(string name, int rating , string feedback)
        {
            service.Create(name, rating, feedback);

            return RedirectToAction(nameof(Index));
        }
        public IActionResult Edit(int id)
        {
            
            return View(service.Get(id));
        }
        [HttpPost]
        public IActionResult Edit(int id,string name, int rating, string feedback)
        {
           service.Edit(id, name, rating, feedback);

            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int id)
        {
          
            return View(service.Get(id));
        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteForReal(int id)
        {
            service.Delete(id);
         
            return RedirectToAction(nameof(Index));
        }
    }
}
