using System;
using System.Collections.Generic;
using System.Text;

namespace SiparisUygulama.Contract.DataContract
{
    public  static class Enums
    {
        public enum CartStatusEnum
        {
            Draft=1,
            Created=2,
            Preparing=3,
            SetOut=4,
            Delivered=5,
            Deleted=6
        }
    }
}
