using Business.Concrete;
using Business.ValidationRules;
using DataAccess.EntityFramework;
using Entities.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopStore.Controllers
{
    public class AdminCategoryController : Controller
    {
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        public ActionResult Index()
        {
            var categoryvalues = cm.GetAll();
            return View(categoryvalues);
        }

        [HttpGet]
        public ActionResult AddCategory()
		{
            return View();
		}
        [HttpPost]
        public ActionResult AddCategory(Category category)
        {
            CategoryValidator categoryValidator = new CategoryValidator();
            ValidationResult results = categoryValidator.Validate(category);
			if (results.IsValid)
			{
                cm.CategoryAdd(category);
                return RedirectToAction("Index");
			}
			else
			{
                foreach(var item in results.Errors)
				{
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
				}
			}
            return View();
        }

        [HttpGet]
        public ActionResult UpdateCategory(int id)
		{
            var categoryvalues = cm.GetById(id);
            return View(categoryvalues);
		}
        [HttpPost]
        public ActionResult UpdateCategory(Category category)
		{
            cm.UpdateCategory(category);
            return RedirectToAction("Index");
		}

    }
}