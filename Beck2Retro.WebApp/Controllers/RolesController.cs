
using Beck2Retro.WebApp.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Linq;
using System.Web.Mvc;

namespace Beck2Retro.WebApp.Controllers
{
    public class RolesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // Show list of roles
        public ActionResult Index()
        {
            return View(db.Roles.ToList());
        }

        //show form to create new role
        public ActionResult Create()
        {
            return View();
        }
        //after pressing the submit button create form 
        [HttpPost] public ActionResult Create(FormCollection collection)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));

            var role = new IdentityRole() 
            {
                Name = collection["Name"]
            };

             var identityResult = roleManager.Create(role);

            if (identityResult.Succeeded)
            {
                return RedirectToAction("Index");
            }

            ViewBag.ErrorMessage = identityResult.Errors.ToString();

            return View();
        }

        public ActionResult Users()
        {
            return View(db.Users.OrderBy(user => user.UserName).ToList());
        }
        [HttpPost]
        public ActionResult ManageUserRoles(FormCollection collection)
        {
            var model = new UserRole();

            var userName = collection["UserName"];
            var identityUser = db.Users.FirstOrDefault(u => u.UserName == userName.Trim());

            if (identityUser != null)
            {
                model.UserName = identityUser.UserName;
                model.UserId = identityUser.Id;

                var identityRoles = db.Roles.ToList();
                foreach (var identityRole in identityRoles)
                {
                    var role = new Role()
                    {
                        Name = identityRole.Name,
                        Id = identityRole.Id,
                        IsChecked = false
                    };

                    if (identityUser.Roles != null)
                    {
                        var roleIds = identityUser.Roles.Select(r => r.RoleId).ToList();
                        if (roleIds.Contains(identityRole.Id))
                        {
                            role.IsChecked = true;
                        }
                        else { role.IsChecked = false; }
                    }
                    model.UserRoles.Add(role);

                }

            }
            else
            {
                model = null;
            }

            return View(model);
        }

        [HttpPost] public ActionResult UpdateRoles(UserRole user)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));

            foreach (var role in user.UserRoles)
            {
                if (role.IsChecked)
                {
                    if(!userManager.IsInRole(user.UserId, role.Name))
                    {
                        userManager.AddToRole(user.UserId, role.Name);
                    }
                }
                else
                {
                    if (userManager.IsInRole(user.UserId, role.Name))
                    {
                        userManager.RemoveFromRole(user.UserId, role.Name); 
                    }
                }
            }

            return RedirectToAction("Index");
        }
    }
}