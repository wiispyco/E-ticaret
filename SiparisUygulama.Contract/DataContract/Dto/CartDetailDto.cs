using System;
using System.Collections.Generic;
using System.Text;

namespace SiparisUygulama.Contract.DataContract.Dto
{
    public class CartDetailDto
    {
        public int Id { get; set; }
        public int RestaurantFoodId { get; set; }
        public RestaurantFoodDto RestaurantFood { get; set; }
        public CartDto Cart { get; set; }
        public int CartId { get; set; }
        public int Quantity { get; set; }
        public int Total { get; set; }
    }
}
