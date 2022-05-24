using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RatingPage.Data;
using RatingPage.Models;
using RatingPage.Services;

namespace RatingPage.Controllers
{
    public class AutoRatesController : Controller
    {
        private readonly IRateService _service;

        public AutoRatesController(RatingPageContext context)
        {
            _service = new RateService();
        }

        // GET: Rates
        public  IActionResult Index()
        {
              return View( _service.GetAllRates());
        }

        public IActionResult Search(string input)
        {
            return View(_service.Search(input));
        }

        // GET: Rates/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rate = _service.Get((int)id);
               
            if (rate == null)
            {
                return NotFound();
            }

            return View(rate);
        }

        // GET: Rates/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Rates/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Rating,Name,Feedback")] Rate rate)
        {
            if (ModelState.IsValid)
            {
                _service.Create(rate.Name,rate.Rating,rate.Feedback);
                return RedirectToAction(nameof(Index));
            }
            return View(rate);
        }

        // GET: Rates/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null )
            {
                return NotFound();
            }

            var rate = _service.Get((int) id);
            if (rate == null)
            {
                return NotFound();
            }
            return View(rate);
        }

        // POST: Rates/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Rating,Name,Feedback")] Rate rate)
        {
            if (id != rate.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                   _service.Edit(rate.Id,rate.Name,rate.Rating, rate.Feedback);
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(rate);
        }

        // GET: Rates/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rate = _service.Get((int)id);
           
                if (rate == null)
            {
                return NotFound();
            }

            return View(rate);
        }

        // POST: Rates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            
            var rate = _service.Get((int)id);
            _service.Delete(id);
            
            return RedirectToAction(nameof(Index));
        }
    }
}
