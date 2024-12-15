using Microsoft.AspNetCore.Http;
using SiparisUygulama.Web.Models.Login;
using System.ComponentModel.DataAnnotations;

namespace SiparisUygulama.Web.Models.Restaurant
{
    public class RestaurantViewModel:ViewModelBase
    {
        public int Id { get; set; }
        public string RestaurantName { get; set; }
        public int UserId { get; set; }
        [Display(Name = "Açılış Saati")]
        [RegularExpression(@"^(?:0?[0-9]|1[0-9]|2[0-3]):[0-5][0-9]$", ErrorMessage = "Saat Formatı HH:MM ")]
        public string OpeningTime { get; set; }
        [Display(Name = "Kapanış Saati")]
        [RegularExpression(@"^(?:0?[0-9]|1[0-9]|2[0-3]):[0-5][0-9]$", ErrorMessage = "Saat Formatı HH:MM ")]
        public string ClosingTime { get; set; }

        public string RestaurantImgFileName { get; set; }

        public IFormFile RestaurantImgFile { get; set; }


    }
}
