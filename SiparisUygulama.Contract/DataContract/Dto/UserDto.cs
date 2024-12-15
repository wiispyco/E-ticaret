using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Text;

namespace SiparisUygulama.Contract.DataContract.Dto
{
    public class UserDto
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Adress { get; set; }
        public RoleDto Role { get; set; }
        public int RoleId { get; set; }
    }
}
