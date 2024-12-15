using System;
using System.Collections.Generic;
using System.Text;

namespace SiparisUygulama.Contract.DataContract.Model
{
    public class BaseResponse
    {
        public bool hasError { get; set; }
        public string message { get; set; }

        public long returnId { get; set; }
        public bool returnResult { get; set; }

        public BaseResponse SetError(string message = "İşlem sırasında bir hata oluştu!")
        {
            this.message = message;
            this.hasError = true;

            return this;
        }

        public BaseResponse SetSuccess(string message = "İşlem Başarılı!")
        {
            this.message = message;
            this.hasError = false;

            return this;
        }
    }
}