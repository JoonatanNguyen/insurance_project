
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace InsuranceWebApplication.Models
{
    public class InsuranceClaimViewModel
    {
        public InsuranceClaimViewModel()
        {
        }

        public InsuranceClaimViewModel(InsuranceClaim claim)
        {
            Id = claim.Id;
            Description = claim.Description;
            UserId = claim.UserId;
            EvaluateClaim = claim.EvaluateClaim;
            AgentId = claim.AgentId;
            User = claim.User;
        }
        
        public int Id { get; set; }
        public string Description { get; set; }
        public string UserId { get; set; }
        public bool EvaluateClaim { get; set; }
        public string AgentId { get; set; }

        public ApplicationUser User { get; set; }

        public List<ApplicationUser> Agents { get; set; }

        public SelectList AgentsSelectList
            => new SelectList(Agents.Select(agent => new SelectListItem {Text = agent.UserName, Value = agent.Id}), "Value", "Text");
    }
}