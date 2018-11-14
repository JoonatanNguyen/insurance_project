using System.Threading.Tasks;
using InsuranceWebApplication.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Owin;

namespace InsuranceWebApplication
{
    partial class Startup
    {
        public ApplicationUserManager UserManager { get; private set; }
        public RoleManager<IdentityRole> RoleManager { get; private set; }

        public async void ConfigureSeeds(IAppBuilder app)
        {
            UserManager = new ApplicationUserManager(new UserStore<ApplicationUser>(ApplicationDbContext.Create()));
            RoleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(ApplicationDbContext.Create()));

            await CreateRoles(app);
        }

        private async Task CreateRoles(IAppBuilder app)
        {
            //initializing custom roles
            string[] roleNames = {"Manager", "Agent", "Customer"};

            foreach (var roleName in roleNames)
            {
                var roleExist = await RoleManager.RoleExistsAsync(roleName);
                if (!roleExist)
                {
                    //create the roles and seed them to the database: Question 1
                    await RoleManager.CreateAsync(new IdentityRole(roleName));
                }
            }

//            //Here you could create a super user who will maintain the web app
//            var poweruser = new ApplicationUser
//            {
//                UserName = Configuration["AppSettings:UserName"],
//                Email = Configuration["AppSettings:UserEmail"]
//            };
//            //Ensure you have these values in your appsettings.json file
//            string userPWD = Configuration["AppSettings:UserPassword"];
//            var _user = await UserManager.FindByEmailAsync(Configuration["AppSettings:AdminUserEmail"]);
//
//            if (_user == null)
//            {
//                var createPowerUser = await UserManager.CreateAsync(poweruser, userPWD);
//                if (createPowerUser.Succeeded)
//                {
//                    //here we tie the new user to the role
//                    await UserManager.AddToRoleAsync(poweruser, "Admin");
//                }
//            }
        }
    }
}