using Final_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Final_Project.Controllers.Register
{
    public class RegisterController : Controller
    {
        // GET: Register
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ViewResult Register(FormCollection frmcol)
        {
            string strUserName = frmcol["txtUserName"];
            string strPassword = frmcol["txtPassword"];
            string strNationalityID = frmcol["txtCusInfor_ID"];
            string strName = frmcol["txtName"];
            //string strGender = frmcol["txtGender"];
            //string strBirthDate = frmcol["txtBirthDate"];
            Customer acc = new Customer
            {
                Cus_UserName = strUserName,
                Cus_Password = strPassword
            };
            AccountData.AccountList().Add(acc);
            ViewBag.Message = "Account :" + strUserName + " added successful.";
            return View("Index");

        }
    }
}