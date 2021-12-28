using Business.Abstract;
using Business.Concrete;
using DataAccess.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopStore.Controllers
{
    [AllowAnonymous]
    public class CategoryController : Controller
    {
        ICategoryService _categoryService = new CategoryManager(new EfCategoryDal());
        public PartialViewResult GetCategories()
        {
            return PartialView(_categoryService.GetAll());
        }
    }
}