using SiparisUygulama.Contract.DataContract.Dto;
using SiparisUygulama.Web.Models.RestaurantFood;

namespace SiparisUygulama.Web.Models.Order
{
    public class CartViewModel:ViewModelBase
    {
        public int Id { get; set; }
        public int OrderNumber { get; set; }
        public int UserId { get; set; }
        public int Total { get; set; }
        public int Status { get; set; }
        

    }
}
