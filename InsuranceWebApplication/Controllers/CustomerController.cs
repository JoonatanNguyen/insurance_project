using System.Web;
using System.Web.Mvc;
using System.Collections.Generic;
using System.Linq;
using InsuranceWebApplication.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace InsuranceWebApplication.Controllers
{
    public class CustomerController : Controller
    {
       
        private ApplicationUserManager _userManager;

        public ApplicationUserManager UserManager
        {
            get { return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>(); }
            private set { _userManager = value; }
        }

        // GET: Customer
        [Authorize(Roles = "Agent")]
        public ActionResult Index()
        {
            ApplicationDbContext db = new ApplicationDbContext();
            var Role = db.Roles.First(role => role.Name == "Customer");
            var customers = db.Users.Where(x => x.Roles.Any(role => Role.Id == role.RoleId)).ToList();
           
            return View(customers);
           
        }

        // GET: Customer/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Customer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customer/Create
        [HttpPost]
        public ActionResult Create(CustomerViewModels model)
        {
            if (ModelState.IsValid)
            {
                // TODO: Add insert logic here
                var user = new ApplicationUser
                {
                    UserName = model.Email,
                    Email = model.Email,
                    PhoneNumber = model.PhoneNumber
                    
                };
                var result = UserManager.Create(user, model.Password);
                if (result.Succeeded)
                {
                    var currentUser = UserManager.FindByName(user.UserName);
                    var roleresult = UserManager.AddToRole(currentUser.Id, "Customer");

                    return RedirectToAction("Index", "Customer");
                }
            }
            // If we got this far, something failed, redisplay form
            return View(model);
        }


        // GET: Customer/Edit/5
        public ActionResult Edit(string id)
        {
            ApplicationDbContext db = new ApplicationDbContext();

            ApplicationUser customer = db.Users.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);         
        }

        // POST: Customer/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, ApplicationUser user)
        {
            if (ModelState.IsValid)
            { 
            // TODO: Add update logic here
            ApplicationDbContext db = new ApplicationDbContext();


            var Model = db.Users.Find(id);
            Model.PhoneNumber = user.PhoneNumber;

            var UserName = user.UserName;

            db.SaveChanges();
            return RedirectToAction("Index");
            }
                return RedirectToAction("Index");
            
           
        }

        // GET: Customer/Delete/5
        public ActionResult Delete(string id)
        {

            ApplicationDbContext db = new ApplicationDbContext();


            var user = db.Users.Find(id);
            return View(user);
        }

        // POST: Customer/Delete/5
        [HttpPost]      
        public ActionResult Delete(string id, string UserId)


        {
            
            if (ModelState.IsValid)
            {
                // TODO: Add update logic here
                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    

                    var Claims = db.InsuranceClaims.Where(claim => claim.UserId==UserId);
                    var Model = UserManager.FindById(id);
                    

                    foreach(var Claim in Claims)
                    {
                        db.InsuranceClaims.Remove(Claim);
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