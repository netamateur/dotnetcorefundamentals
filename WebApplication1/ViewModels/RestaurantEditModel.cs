using System.ComponentModel.DataAnnotations;
using WebApplication1.Models;


namespace WebApplication1.ViewModels
{
    public class RestaurantEditModel
    {

        [Required, MaxLength(80)]
        public string Name { get; set;  }
        public CuisineType Cuisine { get; set; }
        
    }
}
