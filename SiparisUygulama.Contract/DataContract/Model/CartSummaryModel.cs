using SiparisUygulama.Contract.DataContract.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace SiparisUygulama.Contract.DataContract.Model
{
    public class CartSummaryModel
    {
        public int Total { get; set; }
        public int OrderNumber { get; set; }
        public int Status {  get; set; }
        public int UserId { get; set; }
        public int CartId { get; set; }

        public List<CartSummaryDetailModel> Details { get; set; }
        //public CartDetailDto cartDetailDto { get; set; }

    }
}
