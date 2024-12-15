using SiparisUygulama.Web.Models.Order;
using SiparisUygulama.Web.Models.RestaurantFood;

namespace SiparisUygulama.Web.Models.CartDetail
{
    public class CartDetailViewModel
    {
        public int Id { get; set; }
        public int RestaurantFoodId { get; set; }
        public int CartId { get; set; }
        public int Quantity { get; set; }
        public int Total { get; set; }
        public CartViewModel Cart { get; set; }
        public RestaurantFoodViewModel RestaurantFood { get; set; } 
    }
}
