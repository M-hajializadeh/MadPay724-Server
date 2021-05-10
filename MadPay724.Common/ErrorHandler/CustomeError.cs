using System;
using System.Collections.Generic;
using System.Text;

namespace MadPay724.Common.ErrorHandler
{
    public class CustomeError
    {
        public string Title { get; set; }
        public string Message { get; set; }
        public bool Status { get; set; }
        public int Code { get; set; }
    }
}
