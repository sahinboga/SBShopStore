using Business.Abstract;
using Business.Concrete;
using DataAccess.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopStore.Controllers
{
    [AllowAnonymous]
    public class ImageController : Controller
    {
        IImageService _imageService = new ImageManager(new EfImageDal());
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult AddImage()
		{
            return View();
		}
        [HttpPost]
        public ActionResult AddImage(Image image)
        {
            _imageService.ImageAdd(image);
            return View();
        }
    }
}