using System;
using System.Collections.Generic;
using System.Text;

namespace SiparisUygulama.Contract.DataContract.Model
{
    [Serializable]
    public class AuthenticationResponse: BaseResponse
    {
        public bool IsAuthenticated { get; set; }

        /// <summary>
        /// personal identification number
        /// </summary>
        public long UserId { get; set; }

        /// <summary>
        /// username
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// full name
        /// </summary>
        public string FullName { get; set; }

        public string RoleName { get; set; }

        public int? RestaurantId { get; set; }
        
    }

}

