using Business.Abstract;
using Business.Concrete;
using Business.ValidationRules;
using DataAccess.EntityFramework;
using Entities.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace ShopStore.Controllers
{
    [AllowAnonymous]
    public class MemberController : Controller
    {
        IMemberService _memberService = new MemberManager(new EfMemberDal());

        [HttpGet]
        public ActionResult MemberRegister()
		{
            return View();
		}
        [HttpPost]
        public ActionResult MemberRegister(Member member)
        {
            MemberValidator memberValidator = new MemberValidator();
            ValidationResult results = memberValidator.Validate(member);

			if (results.IsValid)
			{
                SHA1 sha1 = new SHA1CryptoServiceProvider();
                string password = member.Password;
                string result = Convert.ToBase64String(sha1.ComputeHash(Encoding.UTF8.GetBytes(password)));
                member.Password = result;
                _memberService.MemberAdd(member);
                return RedirectToAction("MemberLogin", "Login");
			}
			else
			{
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }

            }
            return View();
        }
    }
}