using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SiparisUygulama.Data.Entity
{
    [Table("Cart")]
    public class Cart
    {
        public int Id { get; set; }
        public int OrderNumber { get; set; }
        [ForeignKey("UserId")]
        public int UserId { get; set; }
        public int Total { get; set; }
        public User User { get; set; }
        public int Status { get; set; }
        public ICollection<CartDetail> Details { get; set; }
       
    }
}
