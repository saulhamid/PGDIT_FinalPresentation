using SunBeam.Domain.Models;
using SunBeam.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SunBeam.Web.Controllers
{
    public class AuthController : Controller
    {
        // GET: Auth
        private readonly IUsersBL repo;
        public AuthController(IUsersBL _repo)
        {
            this.repo = _repo;
        }

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(User model, string returnUrl)
        {
            try
            {
                var count = repo.GetAllUsers().Result.FirstOrDefault(m => m.UserName.TrimEnd().Equals(model.UserName.TrimEnd()) && m.Password.TrimEnd() == model.Password.TrimEnd());
                if (count != null)
                {
                    FormsAuthentication.SetAuthCookie(model.UserName, model.Remember);
                    ////return RedirectToAction("Index", "UOM", "Config");
                    //return RedirectToAction("Index", "Home", new { area = "Config" });
                    return RedirectToAction("Index", "Home");
                    //return RedirectToLocal(returnUrl);
                }
                else
                {
                    ModelState.AddModelError("", "The user name or password provided is incorrect.");
                }
            }
            catch (Exception ex)
            {
                return View(model);
            }
            return RedirectToAction("Index", "Home");
            //return RedirectToAction("Index", "Home", new { area = "Config" });

            // If we got this far, something failed, redisplay form
        }
        [HttpGet]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Registration(User data)
        {
            string result = string.Empty;
            try
            {
                result = await repo.InsertUsers(data);
                return View("Login");
            }
            catch (Exception ex)
            {
                ViewBag.error = ex.Message.ToString(); ;
                return View();

            }

        }
    }
}