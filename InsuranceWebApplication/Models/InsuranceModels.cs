using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

        public bool EvaluateClaim { get; set; }
        
        public string UserId { get; set; }
        
        public virtual ApplicationUser User { get; set; }
        
        public string AgentId { get; set; }

        public virtual ApplicationUser Agent { get; set; }
    }

    partial class ApplicationDbContext
    {
        public DbSet<InsuranceClaim> InsuranceClaims { get; set; }
    }
}