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
        public async Task<ActionResult> Login(Users model, string returnUrl)
        {
            try
            {
                var count = repo.GetAllUsers().Result.Any(m => m.UserName.Equals(model.UserName) && m.Password == model.Password);
                if (count)
                {
                    FormsAuthentication.SetAuthCookie(model.UserName, model.Remember);
                    ////return RedirectToAction("Index", "UOM", "Config");
                    //return RedirectToAction("Index", "Home", new { area = "Config" });
                    return RedirectToAction("Index", "Home");
                    //return RedirectToLocal(returnUrl);
                }
                else
                {
                    ViewBag.error = "The user name or password provided is incorrect.";
                    return View(model);
                }
            }
            catch (Exception ex)
            {
                ViewBag.error = ex.Message.ToString();
                return View(model);
            }
            //return RedirectToAction("Index", "Home");
            //return RedirectToAction("Index", "Home", new { area = "Config" });

            // If we got this far, something failed, redisplay form
        }
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Registration(Users data)
        {
            string result = string.Empty;
            try
            {
                var cc =  repo.GetAllUsers().Result.Any(x => x.UserName.Equals(data.UserName) || x.Email.Equals(data.Email));
                if (cc)
                {
                    ViewBag.error = "User Name Or Email Already Exit";
                    return View();
                }
                result = await repo.InsertUsers(data);
                ViewBag.error = result;
                return View("Login");
            }
            catch (Exception ex)
            {
                ViewBag.error = ex.Message.ToString(); ;
                return View();
            }
        }
        public ActionResult logout()
        {
            FormsAuthentication.SignOut();
            return View("Login");
        }
    }
}