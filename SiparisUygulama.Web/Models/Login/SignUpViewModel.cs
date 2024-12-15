using SiparisUygulama.Contract.DataContract.Dto;
using SiparisUygulama.Data.Entity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SiparisUygulama.Web.Models.Login
{
    public class SignUpViewModel: ViewModelBase
    {

        [Required(ErrorMessage = "Zorunlu alan")]
        [EmailAddress]
        public string Mail { get; set; }


        [Required(ErrorMessage = "Zorunlu alan")]
        [MinLength(6, ErrorMessage = "Şifre en az 6 karakter olmalı")]
        public string Password { get; set; }


        [Required(ErrorMessage ="Zorunlu alan")]
        [Compare("Password", ErrorMessage = "Şifre eşleşmiyor")]
        public string ConfirmPassword { get; set; }


        [Required(ErrorMessage = "Zorunlu alan")]
        public string Name { get; set; }


        [Required(ErrorMessage = "Zorunlu alan")]
        public string Adress { get; set; }


        public RoleDto Role { get; set; }


        [Required(ErrorMessage = "Zorunlu alan")]
        public int? RoleId { get; set; }
    }
}
