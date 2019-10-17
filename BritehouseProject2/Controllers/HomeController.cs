using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Google.Authenticator;
using BritehouseProject2.ViewModels;

namespace BritehouseProject2.Controllers
{
    public class HomeController : Controller
    {
        private const string key = "ayg143!@@)(";
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
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel login)
        {
            string message = "";
            bool status = false;

            if (login.username == "Admin" && login.password == "password")
            {
                status = true;
                message = "2FA Verification";
                Session["Username"] = login.username;

                TwoFactorAuthenticator tfa = new TwoFactorAuthenticator();
                string userUniqueKey = login.username + key;
                Session["UserUniqueKey"] = userUniqueKey;
                var setupinfo = tfa.GenerateSetupCode("Dotnet Awesome", login.username, userUniqueKey, 300, 300);
                ViewBag.BarcodeImageUrl = setupinfo.QrCodeSetupImageUrl;
                ViewBag.SetupCode = setupinfo.ManualEntryKey;
            }
            else
            {
                message = "Invalid credential";
            }
            ViewBag.Message = message;
            ViewBag.Status = status;
            return View();
        }

        public ActionResult myProfile()
        {
            if (Session["username"] == null || Session["IsValid2FA"] == null || !(bool)Session["IsValid2FA"])
            {
                return RedirectToAction("Login");
            }
            ViewBag.Message = "Welcome" + Session["username"].ToString();
            return View();
        }
        public ActionResult Verify2FA()
        {
            var token = Request["passcode"];
            TwoFactorAuthenticator tfa = new TwoFactorAuthenticator();
            string userUniqueKey = Session["UserUniqueKey"].ToString();
            bool isValid = tfa.ValidateTwoFactorPIN(userUniqueKey, token);
            if (isValid)
            {
                Session["IsValid2FA"] = true;
                return RedirectToAction("myProfile", "Home");
            }
            return RedirectToAction("Login", "Home");
        }
    } 
}