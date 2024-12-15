using System;
using System.Collections.Generic;
using System.Text;

namespace SiparisUygulama.Contract.DataContract.Dto
{
    public class CartDto
    {
        public int Id { get; set; }
        public int OrderNumber { get; set; } 
        public int UserId { get; set; }
        public int Total { get; set; }
        public int Status {  get; set; }
        public UserDto User { get; set; }
        public List<CartDetailDto> Details { get; set; }



    }
}
