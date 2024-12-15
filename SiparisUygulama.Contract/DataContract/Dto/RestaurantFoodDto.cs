using System;
using System.Collections.Generic;
using System.Text;

namespace SiparisUygulama.Contract.DataContract.Dto
{
    public class RestaurantFoodDto
    {
        public int Id { get; set; }
        public int RestaurantId { get; set; }
        public string FoodName { get; set; }
        public int Price { get; set; }
        public RestaurantDto Restaurant { get; set; }
        public bool Control { get; set; }

        public string FoodImgFileName { get; set; }
    }
}
