using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Opus.Cookbook.WebApi.Models
{
    public class JsonVm
    {
        public bool Status { get; set; }
        public string Message { get; set; } = string.Empty;
        public string ProcessingTime { get; set; } = string.Empty;
        public object Object { get; set; } = null;
    }
}