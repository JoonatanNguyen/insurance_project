using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InsuranceWebApplication.Models
{
    public class AgentViewModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}