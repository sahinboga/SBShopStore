using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.EntityFramework;
using Entities.Concrete;
using ShopStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopStore.Controllers
{
    [AllowAnonymous]
    public class CartController : Controller
    {
        ICartService _cartService = new CartManager(new EfCartDal());
        IProductImageService _productImageService = new ProductImageManager(new EfProductImageDal());
        CartImageRelation _cartImageRelation = new CartImageRelation();
        ShopContext _shopContext = new ShopContext(); 
        public void AddToCart(Cart cart)
        {
            _cartService.CartAdd(cart);
            //RedirectToAction("")
           //return Request.UrlReferrer.ToString();
        }

        public ActionResult MyCart(string p)
		{
            int id = (int)Session["Member"];
            _cartImageRelation.Cart = _cartService.GetMemberById(id);
            _cartImageRelation.ProductImages = _productImageService.GetAll();
           //var cartList = _cartService.GetMemberById(1);
            return View(_cartImageRelation);
		}

        public ActionResult DeleteProduct(int id)
		{
            var cartProduct = _cartService.GetProductById(id);
            _cartService.DeleteCart(cartProduct);
            return RedirectToAction("MyCart");
		}
    }
}