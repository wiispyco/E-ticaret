using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SiparisUygulama.Data.Entity
{
    [Table("User")]
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Adress { get; set; }
        public Role Role { get; set; }
        [ForeignKey("RoleId")]
        public int RoleId { get; set; }
        public List<Restaurant> Restaurants { get; set; }
    }
}
