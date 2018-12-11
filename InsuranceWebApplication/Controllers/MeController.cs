using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InsuranceWebApplication.Models;
using Microsoft.AspNet.Identity;

namespace InsuranceWebApplication.Controllers
{
    [Authorize(Roles = "Customer")]
    public class MeController : Controller
    {
        public ActionResult InsuranceClaims()
        {
            using (var db = new ApplicationDbContext())
            {
                var userId = HttpContext.User.Identity.GetUserId();
                var userClaims = db.InsuranceClaims.Where(claim => claim.UserId.Equals(userId)).ToList();
                return View(userClaims);
            }
        }

        public ActionResult EditInsuranceClaim(int? id)
        {
            using (var db = new ApplicationDbContext())
            {
                var claim = db.InsuranceClaims.Find(id);
                if (claim == null)
                {
                    return HttpNotFound();
                }
                return View(claim);
            }
        }

        public ActionResult Delete(int id)
        {
            ApplicationDbContext db = new ApplicationDbContext();


            var claim = db.InsuranceClaims.Find(id);
            return View(claim);


        }

        [HttpPost]
        public ActionResult Delete(int id, InsuranceClaim claim)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var Claim = db.InsuranceClaims.Find(id);
                db.InsuranceClaims.Remove(Claim);
                db.SaveChanges();

                return RedirectToAction("InsuranceClaims");
            }

        }
        









        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditInsuranceClaim(int id, InsuranceClaimViewModel claim)
        {
            if (ModelState.IsValid)
            {
                using (var db = new ApplicationDbContext())
                {
                    var model = db.InsuranceClaims.Find(id);

                    model.Description = claim.Description;

                    db.SaveChanges();
                    return RedirectToAction("InsuranceClaims");
                }

            }
            return View(claim);
        }
    }
}