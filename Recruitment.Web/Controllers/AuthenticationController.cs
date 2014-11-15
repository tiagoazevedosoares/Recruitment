using Recruitment.Data;
using Recruitment.Web.Helpers;
using Recruitment.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Recruitment.Web.Controllers
{
    public class AuthenticationController : Controller
    {
        private UnitOfWork unitOfWork = new UnitOfWork();

        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var recruiter = unitOfWork.RecruiterRepository.Login(model.Username, model.Password);
                if (recruiter != null)
                {
                    if (model.RememberMe)
                        this.SetUserCookie(recruiter);

                    SessionHelper.UserId = recruiter.RecruiterId;
                    SessionHelper.UserFullName = string.Format("{0} {1}", recruiter.FirstName, recruiter.LastName);

                    FormsAuthentication.SetAuthCookie(model.Username, model.RememberMe);

                    return RedirectToLocal(returnUrl);
                }
            }

            model.AddMessage(ViewModelMessageType.Error, App_GlobalResources.Errors.Login);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            Response.Cookies.Remove("user");
            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Home");
        }

        public ActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangePassword(ChangePasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.RecruiterRepository.ChangePassword(SessionHelper.UserId, model.OldPassword, model.NewPassword);
                unitOfWork.Save();

                return this.RedirectToLocal("\\");
            }

            return View(model);
        }

        [AllowAnonymous]
        public ActionResult ForgotPassword()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ForgotPassword(string userName)
        {
            if (ModelState.IsValid)
            {

            }
            return View();
        }

        #region [Private Methods]
        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        private void SetUserCookie(Model.Recruiter recruiter)
        {
            HttpCookie cookie = Request.Cookies["user"];
            if (cookie != null)
                cookie.Expires = DateTime.Now.AddHours(-1);

            cookie = new HttpCookie("user");
            cookie.Values.Add("id", recruiter.RecruiterId.ToString());
            cookie.Values.Add("fullname", string.Format("{0} {1}", recruiter.FirstName, recruiter.LastName));
            cookie.Expires = DateTime.Now.AddMonths(12);
            Response.Cookies.Add(cookie);
        }
        #endregion [Private Methods]
    }
}
