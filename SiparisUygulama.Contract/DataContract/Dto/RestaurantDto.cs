using System;
using System.Collections.Generic;
using System.Text;

namespace SiparisUygulama.Contract.DataContract.Dto
{
    public class RestaurantDto
    {
        public int Id { get; set; }
        public string RestaurantName { get; set; }
        public int UserId { get; set; }
        public UserDto User { get; set; }
        public string OpeningTime { get; set; }
        public string ClosingTime { get; set; }
        public string RestaurantImgFileName { get; set; }
    }
}
