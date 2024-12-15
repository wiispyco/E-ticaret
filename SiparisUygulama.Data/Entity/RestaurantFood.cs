using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SiparisUygulama.Data.Entity
{
    [Table("RestaurantFood")]
    public class RestaurantFood
    {
        public int Id { get; set; }
        public Restaurant Restaurant { get; set; }
        [ForeignKey("RestaurantId")]
        public int RestaurantId { get; set; }
        public string FoodName { get; set; }
        public int Price { get; set; }
        public bool Control { get; set; }
        public string FoodImgFileName { get; set; }
    }
}
