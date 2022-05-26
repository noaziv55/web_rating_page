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
    public class RatesController : Controller
    {
        private readonly RateService _service;

        public RatesController(RateService service)
        {
            _service = service;
        }

        // GET: Rates
        public async Task<IActionResult> Index()
        {
              return View(await _service.GetAllRates());
        }

        public async Task<IActionResult> Search()
        {
            return View(await _service.GetAllRates());
        }

        [HttpPost]
        public async Task<ICollection<Rate>?> Search(string query)
        {
            return await _service.GetRateBySearch(query);
        }

        // GET: Rates/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _service.GetRate() == null)
            {
                return NotFound();
            }

            var rate = await _service.GetRate()
                .FirstOrDefaultAsync(m => m.Id == id);
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
        public async Task<IActionResult> Create([Bind("Id,Rating,Name,Feedback,Time")] Rate rate)
        {
            rate.Time = DateTime.Now.ToString("MM/dd/yyyy HH:mm");
            if (ModelState.IsValid)
            {
                await _service.AddRate(rate);
                return RedirectToAction(nameof(Index));
            }
            return View(rate);
        }

        // GET: Rates/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _service.GetRate() == null)
            {
                return NotFound();
            }

            var rate = await _service.GetRateByID(id);
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
        public async Task<IActionResult> Edit(int id, [Bind("Id,Rating,Name,Feedback,Time")] Rate rate)
        {
            rate.Time = DateTime.Now.ToString("MM/dd/yyyy HH:mm");
            if (id != rate.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _service.UpdateRate(rate);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_service.RateExists(rate.Id))
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
            return View(rate);
        }

        // GET: Rates/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _service.GetRate() == null)
            {
                return NotFound();
            }

            var rate = await _service.GetRateByID(id);
            if (rate == null)
            {
                return NotFound();
            }

            return View(rate);
        }

        // POST: Rates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_service.GetRate() == null)
            {
                return Problem("Entity set 'RatingPageContext.Rate'  is null.");
            }
            var rate = await _service.GetRateById(id);
            if (rate != null)
            {
                await _service.RemoveRate(rate);
            }
            
            return RedirectToAction(nameof(Index));
        }
    }
}
