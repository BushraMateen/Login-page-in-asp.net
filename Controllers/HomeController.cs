using login_page.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;

namespace login_page.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Homepage()
        {
            return View();
        }
        public ActionResult RegisterPage()
        {
            return View();  
        }
        public ActionResult Register(Register register)
        {
            BushraDbEntities4 bushraDbEntities2 = new BushraDbEntities4();

            //if the register.Firstname is present in the regrister table then return the message accordingly
            var existingRecord = bushraDbEntities2.Registers.FirstOrDefault(x => x.FirstName == register.FirstName);

            if(existingRecord == null)
            {
                bushraDbEntities2.Registers.Add(register);
                bushraDbEntities2.SaveChanges(); 
                return View("MessageView");
                 
            }
            else
            {
                ViewBag.error = "Name already exists";
                return RedirectToAction("RegisterPage");
            }
              
        }
        public ActionResult LoginPage()
        {
            return View();
        }
    }
}
    
