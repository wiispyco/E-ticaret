using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using SiparisUygulama.Web.Models.Restaurant;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SiparisUygulama.Web.Models.RestaurantFood
{
    public class RestaurantFoodViewModel : ViewModelBase
    {
        public int Id { get; set; }
        public int RestaurantId { get; set; }
        public RestaurantViewModel Restaurant { get; set; }


        [Required(ErrorMessage = "Yemek Adı gereklidir.")]
        public string FoodName { get; set; }


        [Required(ErrorMessage = "Fiyat gereklidir.")]
        [Range(1, int.MaxValue, ErrorMessage = "Lütfen geçerli bir fiyat girin.")]
        public int Price { get; set; }

        public bool Control { get; set; }
        public string RestaurantName { get; set; }
        public string OpeningTime { get; set; }
        public string ClosingTime { get; set; }

        public string FoodImgFileName { get; set; }

        public IFormFile FoodImgFile { get; set; }


    }
}
