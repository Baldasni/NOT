using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using NOT.Models;
using Owin;
using System.Linq;
using System.Web;

[assembly: OwinStartupAttribute(typeof(NOT.Startup))]
namespace NOT
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateRolesandUsers(app);
        }

        private void CreateRolesandUsers(IAppBuilder app)
        {
            //HttpContext.GetOwinContext().Get<XYZManager>()

            //ApplicationDbContext context = HttpContext.Current.GetOwinContext().Get<ApplicationDbContext>(); //new ApplicationDbContext();
            ApplicationDbContext context = new ApplicationDbContext();

            var RoleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            //////Get admin role
            ////var adminRole = RoleManager.FindByName("Administrator");
            //////nicola
            ////if (UserManager.Users.Where(x => x.Roles.Any(role => role.RoleId == adminRole.Id)).ToList().Count() > 1)
            ////    throw new System.Exception("L'amministratore deve essere uno solo!!");

            ////if (true || UserManager.Users.Where(x => x.Roles.Any(role => role.RoleId == adminRole.Id)).ToList().Count() == 0)
            ////{
            ////    foreach (var user in UserManager.Users)
            ////    {
            ////        UserManager.DeleteAsync(user);
            ////    }
            ////    foreach (var role in RoleManager.Roles)
            ////    {
            ////        RoleManager.DeleteAsync(role);
            ////    }
            ////}
            // In Startup iam creating first Admin Role and creating a default Admin User

            string roleName = "";

            //Admin
            roleName = System.Enum.GetValues(typeof(RuoloEnum)).GetValue(0).ToString();
            if (!RoleManager.RoleExists(roleName))
            {

                // first we create Admin role
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = roleName;
                RoleManager.Create(role);

                //Here we create a Admin super user who will maintain the website 
                var user = new ApplicationUser();
                user.UserName = "Admin";
                user.Email = "Admin@contoso.com";

                string userPWD = "123456789";
                var chkUser = UserManager.Create(user, userPWD);

                //Add default User to Role Admin
                if (chkUser.Succeeded)
                {
                    var result1 = UserManager.AddToRole(user.Id, roleName);
                }
            }

            //Manager
            roleName = System.Enum.GetValues(typeof(RuoloEnum)).GetValue(1).ToString();

            // Creating Manager role
            //  - Gestisce gli utenti
            //  - Vede tutte le pratiche
            //  - Vede tutte le statistiche
            if (!RoleManager.RoleExists(roleName))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = roleName;
                RoleManager.Create(role);
            }

            //Employee
            roleName = System.Enum.GetValues(typeof(RuoloEnum)).GetValue(2).ToString();

            // Creating Employee role
            //  - Vede e modifica tutte le pratiche 
            if (!RoleManager.RoleExists(roleName))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = roleName;
                RoleManager.Create(role);
            }

            //Customer Manager
            roleName = System.Enum.GetValues(typeof(RuoloEnum)).GetValue(3).ToString();

            // Creating Customer Manager role
            //  - vede tutte le pratiche
            if (!RoleManager.RoleExists(roleName))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = roleName;
                RoleManager.Create(role);
            }

            //Customer 
            roleName = System.Enum.GetValues(typeof(RuoloEnum)).GetValue(4).ToString();

            // Creating Customer role
            //  - può vedere solamente la sua pratica
            if (!RoleManager.RoleExists(roleName))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = roleName;
                RoleManager.Create(role);
            }
        }
    }
}
