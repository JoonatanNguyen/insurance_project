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
        public string Description { get; set; }

        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
    }

    partial class ApplicationDbContext
    {
        public DbSet<InsuranceClaim> InsuranceClaims { get; set; }
    }
}