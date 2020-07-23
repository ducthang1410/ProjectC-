using Final_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Final_Project.Controllers.Login
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }
        public bool CheckAccount(string username, string password)
        {
            Account acc = AccountData.AccountList().SingleOrDefault(c => c.Cus_UserName.Equals(username)
            && c.Cus_Password.Equals(password));
            if (acc == null)
            {
                return false;
            }
            return true;
        }
        [HttpPost]
        public ActionResult CheckLogin(string username, string password)
        {
            ViewBag.title = "Login";
            if (CheckAccount(username, password) )
            {
                ViewBag.Message = "User: " + username + password +" Logged in successful";

            }
            else
            {
                ViewBag.Message = "User: " + username + password +" Logged in fail" ;
                //ViewBag.method = new AccountData();
                
                ViewBag.UserName = username;
            }
            return View("LoginResult");

        }
        public ActionResult LogOut()
        {
            Session.Abandon();
            return RedirectToAction("Home", "Home");

        }
    }
}