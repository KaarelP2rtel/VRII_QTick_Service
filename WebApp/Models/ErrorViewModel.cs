using System;
using System.Collections.Generic;

namespace WebApp.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }
        public List<string> Messages { get; set; } = new List<string>();

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}