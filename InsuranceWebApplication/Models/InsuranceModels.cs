using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace InsuranceWebApplication.Models
{
    public class InsuranceClaim
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
    }

    partial class ApplicationDbContext
    {
        public DbSet<InsuranceClaim> InsuranceClaims { get; set; }
    }
}