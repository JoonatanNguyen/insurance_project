using InsuranceWebApplication.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InsuranceWebApplication.Controllers
{
    public class AgentController : Controller
    {
        private ApplicationUserManager _userManager;
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
        // GET: Agent
        public ActionResult Index()
        {
            ApplicationDbContext db = new ApplicationDbContext();
            var Role = db.Roles.First(role => role.Name == "Agent");
            var customers = db.Users.Where(x => x.Roles.Any(role => Role.Id == role.RoleId)).ToList();

            return View(customers);
        }

        // GET: Agent/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Agent/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Agent/Create
        [HttpPost]
        public ActionResult Create(AgentViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email, PhoneNumber = model.PhoneNumber };
                var result =  UserManager.Create(user, model.Password);
                if (result.Succeeded)
                {

                    var currentUser = UserManager.FindByName(user.UserName);
                    var roleresult = UserManager.AddToRole(currentUser.Id, "Agent");
      
                    return RedirectToAction("Index", "Agent");
                }
         
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        // GET: Agent/Edit/5
        public ActionResult Edit(string id)
        {
            ApplicationDbContext db = new ApplicationDbContext();

            ApplicationUser agent = db.Users.Find(id);
            if (agent == null)
            {
                return HttpNotFound();
            }
            return View(agent);
        }

        // POST: Agent/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, ApplicationUser agent)
        {
            if (ModelState.IsValid)
            {
                // TODO: Add update logic here
                ApplicationDbContext db = new ApplicationDbContext();


                var Model = db.Users.Find(id);
                Model.PhoneNumber = agent.PhoneNumber;

                var UserName = agent.UserName;

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        // GET: Agent/Delete/5
        public ActionResult Delete(string id)
        {
            ApplicationDbContext db = new ApplicationDbContext();


            var user = db.Users.Find(id);
            return View(user);
        }

        // POST: Agent/Delete/5
        [HttpPost]
        public ActionResult Delete(string id, string UserId)
        {
            if (ModelState.IsValid)
            {
                // TODO: Add update logic here
                using (ApplicationDbContext db = new ApplicationDbContext())
                {


                    var Agents = db.InsuranceClaims.Where(agent => agent.UserId == UserId);
                    var Model = UserManager.FindById(id);


                    foreach (var Agent in Agents)
                    {
                        db.InsuranceClaims.Remove(Agent);
                    }
                    db.SaveChanges();
                    UserManager.Delete(Model);


                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction("Index");
        }
    }
}
