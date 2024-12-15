using Microsoft.AspNetCore.Http;
using SiparisUygulama.Contract.DataContract.Dto;
using System.ComponentModel.DataAnnotations;

namespace SiparisUygulama.Web.Models.RestaurantFood
{
    public class RestaurantFoodAddOrUpdateVM
    {
        public int Id { get; set; }
        public int RestaurantId { get; set; }

        [Required(ErrorMessage = "Yemek Adı gereklidir.")]
        public string FoodName { get; set; }


        [Required(ErrorMessage = "Fiyat gereklidir.")]
        [Range(1, int.MaxValue, ErrorMessage = "Lütfen geçerli bir fiyat girin.")]
        public int Price { get; set; }

        public bool Control { get; set; }

       
    }
}
