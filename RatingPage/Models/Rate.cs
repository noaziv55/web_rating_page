using System.ComponentModel.DataAnnotations;

namespace RatingPage.Models
{
    public class Rate
    {
       
        public int Id { get; set; }
        
        [Required]
        //didnt work
        [Range(1,5)]
        public int Rating { get; set; }

        [Display(Name="Name")]
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(200)]
  
        public string Feedback { get; set; }
       
        public string Time { get; set; }
       
    }
}
