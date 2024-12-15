using System.ComponentModel;

namespace SiparisUygulama.Web.Models.Login
{
    public class LoginViewModel: ViewModelBase
    {
        [DisplayName("Mail")]
        public string Mail { get; set; }

        [DisplayName("Password")]
        public string Password { get; set; }
    }
}
