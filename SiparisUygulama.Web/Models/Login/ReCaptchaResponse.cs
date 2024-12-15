using Newtonsoft.Json;

namespace SiparisUygulama.Web.Models.Login
{
    public class ReCaptchaResponse
    {
        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("score")]
        public float Score { get; set; }
    }
}
