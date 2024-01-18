using login_page.Models;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Xml.Linq;

namespace login_page.Controllers
{
    public class HomeController : Controller
    {
         private BushraDbEntities4 bushraDbEntities2 = new BushraDbEntities4();
        // GET: Home
        public ActionResult Index()
        {
            if (Session["idUser"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("LogIn");
            }
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
        public ActionResult LogIn(string FirstName, string Password)
        {
            BushraDbEntities4 bushraDbEntities2 = new BushraDbEntities4();
            //var v = bushraDbEntities2.Registers.FirstOrDefault(s => s.FirstName.Equals(FirstName) && s.Password.Equals(Password));

            var v = bushraDbEntities2.Registers.FirstOrDefault(s => s.FirstName.Equals(FirstName) && s.Password.Equals(Password));


            if (v != null)
            {
                Session["idUser"] = v.FirstName + " " + v.LastName;
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.error = "login Failed";
                return RedirectToAction("LoginPage");
            }
        
        }
        public ActionResult Logout()
        {
            Session.Clear();//remove session
            return RedirectToAction("Homepage");
        }

    }
}
    
