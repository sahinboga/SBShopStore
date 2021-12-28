using Business.Abstract;
using Business.Concrete;
using DataAccess.EntityFramework;
using ShopStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopStore.Controllers
{
    [AllowAnonymous]
    public class ProductController : Controller
    {
        IProductService _productService = new ProductManager(new EfProductDal());
        IProductImageService _productImageService = new ProductImageManager(new EfProductImageDal());
        ICategoryService _categoryService = new CategoryManager(new EfCategoryDal());
        ProductImageRelation productImageRelation = new ProductImageRelation();
        ProductImageDetailRelation productImageDetailRelation = new ProductImageDetailRelation();
        public ActionResult ProductList(int? id)
        {
            //var productvalues = _productService.GetAllByCategoryId(id ?? 0);
            productImageRelation.Product = _productService.GetAllByCategoryId(id ?? 0);
            productImageRelation.ProductImages = _productImageService.GetAll();
            return View(productImageRelation);
        }
        public ActionResult ProductDetail(int id)
		{
            //var productvalue = _productService.GetById(id);
            productImageDetailRelation.Product = _productService.GetById(id);
            productImageDetailRelation.ProductImage = _productImageService.GetAll();
            return View(productImageDetailRelation);
        }


    }
}