using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InsuranceWebApplication.Models
{
    public class InsuranceViewModels
    {
        public class InsuranceClaimViewModel
        {
            public string Name { get; set; }
            public string Gender { get; set; }
            public string PhoneNumber { get; set; }
            public string Email { get; set; }
            public string Address { get; set; }
            public string Description { get; set; }
        }
    }
}