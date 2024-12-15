using Microsoft.AspNetCore.Mvc.Rendering;
using SiparisUygulama.Web.Models.Login;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SiparisUygulama.Web.Models.Restaurant
{
    public class MainRestaurantViewModel: ViewModelBase
    {
        public List<RestaurantViewModel> Restaurants { get; set; }

        public SelectList RestaurantList { get; set; }


    }
}
