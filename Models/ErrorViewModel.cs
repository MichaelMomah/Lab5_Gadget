using System;

namespace Lab5_Gadgets.Models
{
    public class ErrorViewModel
    {
        //Error page getters and setters
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
