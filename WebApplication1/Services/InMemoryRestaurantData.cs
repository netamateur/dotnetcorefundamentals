using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        public InMemoryRestaurantData()
        { 
           _restaurants = new List<Restaurant>
            {
              new Restaurant { Id =1, Name = "Rita's Pizza"},
              new Restaurant { Id =2, Name = "Supernormal"},
              new Restaurant { Id =3, Name = "Nobu"}
            };
    }

        public IEnumerable<Restaurant> GetAll()
        {
            return _restaurants.OrderBy(r => r.Name);
        }

        //abstraction - note: List is not thread safe.
        List<Restaurant> _restaurants;
    }
}