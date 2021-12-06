using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using NOT.Models;
using NOT.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace NOT.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        // GET: Admin/ListaUtenti
        [Authorize(Roles = "Admin,Manager")]
        public ActionResult ListaUtenti()
        {
            AspNetUserRepository userRepo = new AspNetUserRepository();
            //return View(userRepo.GetAllAspNetUsers());
            return View(AspNetUserRepository.GetListaUtenti());
            
        }

        // GET: Admin/AddUtente
        [AllowAnonymous]
        public ActionResult AddUtente()
        {
            return View(new AddUtenteViewModel());
        }

        // POST: Admin/AddUtente
        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult> AddUtente(AddUtenteViewModel user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    AccountController ac = new AccountController();
                    await ac.Register(new RegisterViewModel()
                    {
                        UserName = user.UserName,
                        Email = user.Email,
                        Password = user.Password,
                        Ruolo = user.Ruolo
                    });
                    //AspNetUserRepository userRepo = new AspNetUserRepository();
                    //userRepo.AddAspNetUser(new AspNetUser() { UserName = user.UserName,
                    //Email = user.Email, });
                    ViewBag.Message = "Records added successfully.";
                }
                return View(user);
            }
            catch (Exception e)
            {
                ViewBag.Message = e.Message;
                return View();
            }
        }

        // GET: Bind controls to Update details
        [Authorize(Roles = "Admin,Manager")]
        public ActionResult EditUtente(string id)
        {
            AspNetUserRepository userRepo = new AspNetUserRepository();
            AspNetUser user = AspNetUserRepository.GetListaUtenti().Find(u => u.Id == id);

            //return View(new EditUtenteViewModel() { UserName = user.UserName, Email = user.Email });
            return View(new EditUtenteViewModel() { UserId = user.Id, UserName = user.UserName, Email = user.Email, Ruolo = user.AspNetRoles.Select(x => x == null ? "" : x.Name).First() });
        }

        // POST:Update the details into database
        [HttpPost]
        public ActionResult EditUtente(string id, EditUtenteViewModel model)
        {
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    var store = new UserStore<ApplicationUser>(context);
                    var manager = new UserManager<ApplicationUser>(store);
                    ApplicationUser user = new ApplicationUser();

                    user = manager.FindById(id);
                    user.Email = model.Email;
                    user.UserName = model.UserName;

                    Task.WaitAny(manager.UpdateAsync(user));
                
                    if (model.Ruolo != null && model.Ruolo != "")
                    {
                        IList<string> deb = manager.GetRoles(user.Id);
                        Task.WaitAny(manager.RemoveFromRoleAsync(user.Id, manager.GetRoles(user.Id).FirstOrDefault()));
                        Task.WaitAny(manager.AddToRoleAsync(user.Id, model.Ruolo));
                    }
                    Task.WaitAny(context.SaveChangesAsync());
                }

                //AspNetUserRepository userRepo = new AspNetUserRepository();
                //List<AspNetRole> roles = new List<AspNetRole>();
                //roles.Add(AspNetUserRepository.GetRuoloByName(obj.Ruolo));
                //AspNetUserRepository.UpdateAspNetUser(new AspNetUser()
                //                                {
                //                                    Id = id,
                //                                    UserName = obj.UserName,
                //                                    Email = obj.Email,
                //                                    AspNetRoles = roles
                //                                });
                return RedirectToAction("ListaUtenti");
            }
            catch (Exception e)
            {
                return View(e);
            }
        }

        // GET: Delete  AddUtenteViewModel details by id
        [Authorize(Roles = "Admin,Manager")]
        public ActionResult DeleteUtente(string id)
        {
            try
            {
                AspNetUserRepository userRepo = new AspNetUserRepository();
                if (AspNetUserRepository.DeleteAspNetUser(id))
                {
                    ViewBag.AlertMsg = "AddUtenteViewModel details deleted successfully";
                }
                return RedirectToAction("GetAllUserDetails");
            }
            catch
            {
                return RedirectToAction("GetAllUserDetails");
            }
        }
    }
}
