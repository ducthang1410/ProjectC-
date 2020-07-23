using Final_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Configuration;
using System.Collections;

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
            int intNationalityID =int.Parse( frmcol["txtCusInfor_ID"]);
            string strName = frmcol["txtName"];
            bool boolGender = bool.Parse(frmcol["txtGender"]);
            string strAddress = frmcol["txtAddress"];
            DateTime dateBirthDate = DateTime.Parse( frmcol["txtBirthDate"]);
            string strEmail = frmcol["txtEmail"];
            string strPhone = frmcol["txtPhone"];

            Account acc = new Account
            {
                Cus_UserName = strUserName,
                Cus_Password = strPassword
            };

            Customer cus = new Customer
            {
                CusInfor_Name= strName,
                CusInfor_Address=strAddress,
                CusInfor_BirthDate=dateBirthDate,
                CusInfor_Email=strEmail,
                CusInfor_Gender=boolGender,
                CusInfor_ID=intNationalityID,
                Cus_Infor_Phone=strPhone
            };
            CustomerData.CustomersList().Add(cus);
            AccountData.AccountList().Add(acc);
             // loi
            ViewBag.Message = "Account :" + strUserName + " added successful.";
            return View("Register"  );

        }
    }
}