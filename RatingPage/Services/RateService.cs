using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RatingPage.Data;
using RatingPage.Models;

namespace RatingPage.Services
{
    public class RateService
    {
        private readonly RatingPageContext _context;

        public RateService(RatingPageContext context)
        {
            _context = context;
        }

        // GET: Rates

        public DbSet<Rate>? GetRate()
        {
            return _context.Rate;
        }

        public async Task<ICollection<Rate>?> GetAllRates()
        {
            return await _context.Rate.ToListAsync();
        }
        
        public async Task<ICollection<Rate>?> GetRateBySearch (string query)
        {
            var q = from rate in _context.Rate
                    where rate.Feedback.Contains(query)
                    select rate;
            return await q.ToListAsync();
        }

        public async Task<Rate> GetRateById(int id)
        {
            return await _context.Rate.FindAsync(id);
        }

        public async Task<Rate?> GetRateByID(int? id)
        {
            return await _context.Rate
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task AddRate(Rate rate)
        {
            _context.Add(rate);
            await _context.SaveChangesAsync();
            return;
        }

        public async Task UpdateRate(Rate rate)
        {
            _context.Update(rate);
            await _context.SaveChangesAsync();
            return;
        }

        public async Task RemoveRate(Rate rate)
        {
            _context.Rate.Remove(rate);
            await _context.SaveChangesAsync();
            return;
        }

        public bool RateExists(int id)
        {
            return _context.Rate.Any(e => e.Id == id);
        }

    }
}
