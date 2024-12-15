using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SiparisUygulama.Data.Entity
{
    [Table("CartDetail")]
    public class CartDetail
    {
        public int Id { get; set; }
        [ForeignKey("RestaurantFoodId")]
        public int RestaurantFoodId { get; set; }
        [ForeignKey("CartId")]
        public Cart Cart { get; set; }
        public RestaurantFood RestaurantFood { get; set; }
        public int CartId { get; set; }
        public int Quantity { get; set; }
        public int Total { get; set; }
    }
}
