using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Inventory.CORE.Models
{
    public class ResponseModel<T>
    {
        public bool success { get; set; }
        public T result { get; set; }
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public string errorMessage { get; set; }
        public bool RepeatOption { get; set; }
        public string MethodToRepeat { get; set; }
        public string successMessage { get; set; }
        public bool confirmMail { get; set; }
    }
}
