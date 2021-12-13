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
    public class AdminProductController : Controller
    {
        ProductManager pm = new ProductManager(new EfProductDal());
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        public ActionResult Index()
        {
            var productvalues = pm.GetAll();
            return View(productvalues);
        }

        [HttpGet]
        public ActionResult AddProduct()
		{
            List<SelectListItem> categoryvalue = (from x in cm.GetAll()
                                                  select new SelectListItem { 
                                                      Text=x.CategoryName,
                                                      Value=x.CategoryId.ToString()
                                                  }).ToList();
            ViewBag.cv = categoryvalue;
            return View();
		}

        [HttpPost]
        public ActionResult AddProduct(Product product)
        {
            ProductValidator productValidator = new ProductValidator();
            ValidationResult results = productValidator.Validate(product);

            if (results.IsValid)
            {
                pm.ProductAdd(product);
                return RedirectToAction("Index");
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

        [HttpGet]
        public ActionResult UpdateProduct(int id)
		{
            List<SelectListItem> categoryvalue = (from x in cm.GetAll()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryId.ToString()
                                                  }).ToList();
            ViewBag.cv = categoryvalue;
            var productvalues = pm.GetById(id);
            return View(productvalues);
		}
        [HttpPost]
        public ActionResult UpdateProduct(Product product)
        {
            pm.UpdateProduct(product);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteProduct(int id)
		{
            var productvalues = pm.GetById(id);
            pm.DeleteProduct(productvalues);
            return RedirectToAction("Index");
		}

        public ActionResult GetProductDetail(int id)
		{
            var productvalue = pm.GetById(id);
            return View(productvalue);
		}
    }
}