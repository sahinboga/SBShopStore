using Business.Abstract;
using Business.Concrete;
using Business.ValidationRules;
using DataAccess.EntityFramework;
using Entities.Concrete;
using Entities.Dtos;
using FluentValidation.Results;
using ShopStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopStore.Controllers
{
    //[AllowAnonymous]
    public class AdminProductController : Controller
    {
        IProductService _productService = new ProductManager(new EfProductDal());
        IProductImageService _productImageService = new ProductImageManager(new EfProductImageDal());
        ICategoryService _categoryService = new CategoryManager(new EfCategoryDal());
        ProductImageRelation productImageRelation = new ProductImageRelation();
        ProductImageDetailRelation ProductImageDetailRelation = new ProductImageDetailRelation();
        public ActionResult Index(int? id)
        {
            productImageRelation.Product = _productService.GetAllByCategoryId(id ?? 0);
            productImageRelation.ProductImages = _productImageService.GetAll();
            //var productvalues = _productService.GetAllByCategoryId(id??0);
            return View(productImageRelation);		
        }

        [HttpGet]
        public ActionResult AddProduct()
		{
            List<SelectListItem> categoryvalue = (from x in _categoryService.GetAll()
                                                  select new SelectListItem { 
                                                      Text=x.CategoryName,
                                                      Value=x.CategoryId.ToString()
                                                  }).ToList();
            ViewBag.cv = categoryvalue;
            return View();
		}

        [HttpPost]
        public ActionResult AddProduct(AddProductDto addProductDto)
        {
            ProductValidator productValidator = new ProductValidator();
            ValidationResult results = productValidator.Validate(addProductDto.Products);

            if (results.IsValid)
            {
                _productService.ProductAdd(addProductDto);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            List<SelectListItem> categoryvalue = (from x in _categoryService.GetAll()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryId.ToString()
                                                  }).ToList();
            ViewBag.cv = categoryvalue;
            return View();
        }

        [HttpGet]
        public ActionResult UpdateProduct(int id)
		{
            List<SelectListItem> categoryvalue = (from x in _categoryService.GetAll()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryId.ToString()
                                                  }).ToList();
            ViewBag.cv = categoryvalue;
            var productvalues = _productService.GetById(id);
            return View(productvalues);
		}
        [HttpPost]
        public ActionResult UpdateProduct(Product product)
        {
            _productService.UpdateProduct(product);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteProduct(int id)
		{
            var productvalues = _productService.GetById(id);
            _productService.DeleteProduct(productvalues);
            return RedirectToAction("Index");
		}

        public ActionResult ProductDetail(int id)
		{
            ProductImageDetailRelation.Product = _productService.GetById(id);
            ProductImageDetailRelation.ProductImage = _productImageService.GetAll();
            //var productvalue = _productService.GetById(id);
            return View(ProductImageDetailRelation);
		}
    }
}