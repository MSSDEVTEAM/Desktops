using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using PWA_Test.Models;


namespace PWA_Test.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            return View();
        }

        public ActionResult Login()
        {
            Session["UserName"] = null;

            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(tbl_User objUser)
        {
            if (ModelState.IsValid)
            {

                string encryptedPassword = Security.EncryptPassword(objUser.UserPassword);

                PWA_TestContext context  = new PWA_TestContext();


                if (Request.Form["Login"] != null)
                {
                    // Get Guid for Operations user type
                    var userType = context.tbl_UserType.Where(m => m.Type == "Operations").FirstOrDefault();

                    UspLogin_Result login_Result = context.UspLogin(objUser.UserName, encryptedPassword, userType.ID).FirstOrDefault();

                    if (login_Result.Error == string.Empty)
                    {
                        fillsessions(login_Result);
                        var routeValues = new RouteValueDictionary {
                                                        { "id",login_Result.UserId }
                                                        };

                        return View("VerifyCode");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, login_Result.Error);
                    }
                }


            }

            return View(objUser);
        }

        public void fillsessions(UspLogin_Result UserDetails)
            {
                Session["UserName"] = UserDetails.FullName;
                Session["UserId"] = UserDetails.UserId;
                Session["UserType"] = UserDetails.UserType;
                Session["Email"] = UserDetails.Email;
                Session["MFAPIN"] = UserDetails.MFAPIN;


            }
        

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult VerifyCode(tbl_User objUser)
        {
            ViewBag.ShowCodeGen = false;
            ViewBag.CodeGenSuccess = false;
            if (Request.Form["VerifyCode"] != null)
            {

                if (Request.Form["mfaPin"] != null)
                {
                    string mfaPin = Request.Form["mfaPin"];
                    if (mfaPin.Equals(string.Empty))
                    {
                        ModelState.AddModelError(string.Empty, "Please enter your code");

                        return View();
                    }
                    else if (mfaPin == Session["MFAPIN"].ToString())
                    {

                        Session["Authenticated"] = "1";
                        var routeValues = new RouteValueDictionary {
                                                        { "id",Session["UserId"] }
                                                        };
                        return RedirectToAction("Index", "CaseLanding", routeValues);
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Incorrect Code");
                        ViewBag.ShowCodeGen = true;
                        return View();
                    }
                }

            }

            else if (Request.Form["NewCode"] != null)
            {
                try
                {
                    PWA_TestContext context = new PWA_TestContext();
                   // PWA_TestContext entities = new NewBuildOperationsEntities();

                    context.UspCodeGen(Session["UserId"].ToString());

                    ViewBag.Message = "New code sent";
                    ViewBag.ShowCodeGen = false;
                    ViewBag.CodeGenSuccess = true;
                    ModelState.SetModelValue("MFAPIN", null);

                }
                catch (Exception ex)
                {
                    ViewBag.Message = "Error: Please contact your system administrator with the following message: " + ex.Message;

                }

            }
            return View();
        }

        public ActionResult RecoverPassword()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RecoverPassword(tbl_User objUser)
        {

            ViewBag.ShowSuccess = false;
            ViewBag.ShowFailure = false;

            if (Request.Form["SendPasswordResetLink"] != null)
            {
                PWA_TestContext context = new PWA_TestContext();

               // NewBuildOperationsEntities entities = new NewBuildOperationsEntities();

                UspPasswordresetRequestEmail_Result result = context.UspPasswordresetRequestEmail(objUser.Email).FirstOrDefault();

                string response = result.Response;

                if (response == "success")
                {
                    ViewBag.ShowSuccess = true;
                    ViewBag.ShowFailure = false;
                }
                else
                {
                    ViewBag.ShowFailure = true;
                    ViewBag.ShowSuccess = false;
                }
            }

            return View(objUser);
        }

        public ActionResult ResetPassword(tbl_User objUser)
        {
            ViewBag.ShowErrorDiv = false;
            ViewBag.ShowPasswordDiv = false;
            ViewBag.ResultSuccess = false;
            ViewBag.ResultFailure = false;

            if (Request.Form["ResetSuccessLogin"] != null)
            {
                return View("Login");
            }

            if (Request.Form["btnConfirmPasswordChange"] != null)
            {

                string resp;

                string urluid = Session["urluid"].ToString();
                string encryptedpwd = Security.EncryptPassword(Request.Form["NewPassword"]);
                try
                {
                    PWA_TestContext context = new PWA_TestContext();
                   // NewBuildOperationsEntities entities = new NewBuildOperationsEntities();
                    UspPasswordUpdate_Result pswdUpdateResult = context.UspPasswordUpdate(urluid, encryptedpwd).FirstOrDefault();
                    resp = pswdUpdateResult.Response;
                    if (resp == "success")
                    {
                        ViewBag.ResultSuccess = true;
                        ViewBag.ResultFailure = false;
                    }
                    else
                    {
                        ViewBag.ResultSuccess = false;
                        ViewBag.ResultFailure = true;
                    }

                }
                catch
                {
                    ViewBag.ResultSuccess = false;
                    ViewBag.ResultFailure = true;
                }
            }
            else
            {
                if (Request.QueryString["uid"] != null)
                {
                    uidcheck();
                }

            }

            return View();
        }

        private void uidcheck()
        {

            string urluid = Request.QueryString["uid"].ToString();

            Session["urluid"] = urluid;

            PWA_TestContext context = new PWA_TestContext();

            // NewBuildOperationsEntities entities = new NewBuildOperationsEntities();
          

            UspPasswordUidCheck_Result uidCheck_Result = context.UspPasswordUidCheck(urluid).FirstOrDefault();

            if (uidCheck_Result.Error != string.Empty)
            {
                ViewBag.ShowErrorDiv = true;
                ViewBag.ShowPasswordDiv = false;
            }
            else
            {
                ViewBag.ShowErrorDiv = false;
                ViewBag.ShowPasswordDiv = true;

            }
        }
}
}
    




