using SiparisUygulama.Contract.DataContract.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace SiparisUygulama.Contract.DataContract.Model
{
    public class CartSummaryDetailModel
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int Total { get; set; }
        public int FoodPrice { get; set; }
        public string FoodName { get; set; }
        public string RestaurantName { get; set; }

    }
}
