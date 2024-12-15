namespace SiparisUygulama.Web.Models.Cart
{
    public class AddProductViewModel
    {
        public int RestaurantFoodId { get; set; }
        public int RestaurantFoodPrice { get; set; }
        public int Quantity { get; set; } = 1;
    }
}
