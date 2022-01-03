using Business.Abstract;
using Business.Concrete;
using DataAccess.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ShopStore.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        ILoginService _loginService = new LoginManager(new EfMemberDal(), new EfAdminDal());


        [HttpGet]
        public ActionResult MemberLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult MemberLogin(Member member)
        {
            SHA1 sha1 = new SHA1CryptoServiceProvider();
            string password = member.Password;
            string result = Convert.ToBase64String(sha1.ComputeHash(Encoding.UTF8.GetBytes(password)));
            member.Password = result;
            var memberUSerInfo = _loginService.GetMember(member.Email, member.Password);
			if (memberUSerInfo != null)
			{
                FormsAuthentication.SetAuthCookie(memberUSerInfo.ToString(), false);
                Session["Member"] = memberUSerInfo.MemberId ;
                return RedirectToAction("ProductList", "Product");
			}
			else
			{
                return RedirectToAction("MemberLogin");
			}
        }

        [HttpGet]
        public ActionResult AdminLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdminLogin(Admin admin)
        {
            var memberUSerInfo = _loginService.GetAdmin(admin.Email, admin.Password);
            if (memberUSerInfo != null)
            {
                FormsAuthentication.SetAuthCookie(memberUSerInfo.ToString(), false);
                Session["Member"] = memberUSerInfo.AdminId;
                return RedirectToAction("Index", "AdminProduct");
            }
            else
            {
                return RedirectToAction("AdminLogin");
            }
        }

        public ActionResult MemberLogOut()
		{
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("MemberLogin", "Login");
        }

        public ActionResult AdminLogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("AdminLogin", "Login");
        }
    }
}