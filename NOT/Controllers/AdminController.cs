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
    public class AdminController : Controller
    {
        // GET: Admin/ListaUtenti
        public ActionResult ListaUtenti()
        {
            AspNetUserRepository userRepo = new AspNetUserRepository();
            //return View(userRepo.GetAllAspNetUsers());
            return View(AspNetUserRepository.GetListaUtenti());
            
        }

        // GET: Admin/AddUtente
        public ActionResult AddUtente()
        {
            return View(new AddUtenteViewModel());
        }

        // POST: Admion/AddUtente
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
        public ActionResult EditUtente(string id)
        {
            AspNetUserRepository userRepo = new AspNetUserRepository();
            AspNetUser user = AspNetUserRepository.GetListaUtenti().Find(u => u.Id == id);

            //return View(new EditUtenteViewModel() { UserName = user.UserName, Email = user.Email });
            return View(new EditUtenteViewModel() { UserId = user.Id, UserName = user.UserName, Email = user.Email, Ruolo = user.AspNetRoles.Select(x => x == null ? "" : x.Name).First() });
        }

        // POST:Update the details into database
        [HttpPost]
        public ActionResult EditUtente(string id, EditUtenteViewModel obj)
        {
            try
            {
                AspNetUserRepository userRepo = new AspNetUserRepository();
                AspNetUserRepository.UpdateAspNetUser(new AspNetUser()
                                                {
                                                    Email = obj.Email
                                                });
                return RedirectToAction("GetAllUserDetails");
            }
            catch
            {
                return View();
            }
        }

        // GET: Delete  AddUtenteViewModel details by id
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
