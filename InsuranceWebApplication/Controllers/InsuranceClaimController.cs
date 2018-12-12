using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InsuranceWebApplication.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace InsuranceWebApplication.Controllers
{
    public class InsuranceClaimController : Controller
    {
        private ApplicationUserManager _userManager;

        public ApplicationUserManager UserManager
        {
            get { return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>(); }
            private set { _userManager = value; }
        }

        // GET: InsuranceClaim
        public ActionResult Index()
        {
            return View();
        }

        // GET: InsuranceClaim/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        [Authorize(Roles = "Agent,Manager")]
        public ActionResult List()
        {
            ApplicationDbContext db = new ApplicationDbContext();
            var claims = db.InsuranceClaims.ToList();
            return View(claims);
        }

        // GET: InsuranceClaim/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: InsuranceClaim/Create
        [HttpPost]
        [Authorize(Roles = "Customer")]
        public ActionResult Create(InsuranceClaimViewModel model)
        {
            try
            {
                using (var db = new ApplicationDbContext())
                {
                    db.InsuranceClaims.Add(new InsuranceClaim
                    {
                        Description = model.Description,
                        UserId = User.Identity.GetUserId(),
                        EvaluateClaim = false
                    });

                    db.SaveChanges();
                }
                
                return RedirectToAction("InsuranceClaims", "Me");
            }
            catch
            {
                return View();
            }
        }

        // GET: InsuranceClaim/Edit/5
        public ActionResult Edit(int? id)
        {
            using (var db = new ApplicationDbContext())
            {
                var claim = db.InsuranceClaims.Find(id);
                if (claim == null)
                {
                    return HttpNotFound();
                }

                var claimViewModel = new InsuranceClaimViewModel(claim);

                var agentRole = db.Roles.First(role => role.Name.Equals("Agent"));
                claimViewModel.Agents =
                    db.Users.Where(user => user.Roles.Any(role => role.RoleId.Equals(agentRole.Id))).ToList();

                return View(claimViewModel);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, InsuranceClaimViewModel claim)
        {
            if (ModelState.IsValid)
            {
                ApplicationDbContext db = new ApplicationDbContext();


                var Model = db.InsuranceClaims.Find(id);
                Model.Description = claim.Description;
                Model.EvaluateClaim = claim.EvaluateClaim;
                Model.AgentId = claim.AgentId;
                db.SaveChanges();
                return RedirectToAction("List");
            }
            return View(claim);
        }

        // POST: InsuranceClaim/Edit/5


        // GET: InsuranceClaim/Delete/5
        public ActionResult Delete(int id)
        {
            ApplicationDbContext db = new ApplicationDbContext();


            var claim = db.InsuranceClaims.Find(id);
            return View(claim);
            
        }

        // POST: InsuranceClaim/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, InsuranceClaim claim)
        {
            if (ModelState.IsValid)
            {
                using (ApplicationDbContext db = new ApplicationDbContext())
                {


                    var Claim = db.InsuranceClaims.Find(id);
                    db.InsuranceClaims.Remove(Claim);                    
                    db.SaveChanges();


                    return RedirectToAction("List");
                }
            }
            return RedirectToAction("Index");
        }
    }
}