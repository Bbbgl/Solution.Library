using Proxy.Library;
using Proxy.Library.ServiceViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Library.Controllers
{
    public class AuthController : Controller
    {

        public static Mapper Mapper = new Mapper();//non posso registrarlo in unity.container perchè non ho l'interfaccia, e questo mapper contiene solo metodi statici
       
        
        readonly IUserProxy apiUser;

        //inject dependency
        public AuthController(IUserProxy userProxy)
        {
            this.apiUser = userProxy;
        }
        // GET: Auth
       public ActionResult Login()
        {
            return View();
        }

        // Post:Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login([Bind(Include = "Username,Password")] LoginServiceViewModel lsvm)
        {
            var currentUser = apiUser.Login(lsvm);
            ViewData["CurrentUser"] = currentUser;
            if (currentUser.Role == "Admin")
            {
                return RedirectToAction("Index", "Book");
            }
            else
            {
                return RedirectToAction("IndexForAll", "Book");
            }
            return View();
        }
    }
}