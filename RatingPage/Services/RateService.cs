using RatingPage.Models;


namespace RatingPage.Services
{
    public class RateService:IRateService
    {
        private static List<Rate> rates = new List<Rate>();
        public List<Rate> GetAllRates() {
            return rates;
        }
        public Rate Get(int id) {
            return rates.Find(x => x.Id == id);
        }
        public void Create(string name, int rating, string feedback)
        {
            int nextId = 0;
            if (rates.Count > 0)
            {
                nextId = rates.Max(x => x.Id) + 1;

            }
            rates.Add(new Rate() { Id = nextId, Name = name, Rating = rating, Feedback = feedback , Time = DateTime.Now.ToString("MM/dd/yyyy HH:mm") });

        }

        public void Edit(int id, string name, int rating, string feedback) {

            Rate rate = Get(id);
            rate.Name = name;
            rate.Rating = rating;
            rate.Feedback = feedback;
            rate.Time = DateTime.Now.ToString("MM/dd/yyyy HH:mm");
           
        }
        public void Delete(int id) {
            rates.Remove(Get(id));
        }
        public List<Rate> Search ( string query) {

            List<Rate> searchRates = new List<Rate>();

            foreach (Rate rate in rates)
            {
                if (rate.Feedback.Contains(query))
                {
                    searchRates.Add(rate);
                }
            }
            return searchRates;
            
        }
    }
}
