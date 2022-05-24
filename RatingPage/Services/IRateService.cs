
using RatingPage.Models;

namespace RatingPage.Services
{
    public interface IRateService
    {

        public List<Rate> GetAllRates();

        public Rate Get(int id);

        public void Create(string name, int rating, string feedback);

        public void Edit(int id, string name, int rating, string feedback);

        public void Delete(int id);

        public List<Rate> Search(string query);
       
    }
}
