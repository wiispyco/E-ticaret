using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SiparisUygulama.Data.Entity
{
    [Table("Restaurant")]
    public class Restaurant
    {
        public int Id { get; set; }
        public string RestaurantName { get; set; }
        [ForeignKey("KullanıcıId")]
        public int UserId { get; set; }
        public User User { get; set; }
        public string OpeningTime { get; set; }
        public string ClosingTime { get; set; }
        public string ImgFileName { get; set; }
    }
}
