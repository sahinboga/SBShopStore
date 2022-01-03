using Business.Abstract;
using Business.Concrete;
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
    public class PaymentController : Controller
    {
        ICartService _cartService;
        IShippingDetailService shippingDetailService; 
        public PaymentController()
		{
            _cartService = new CartManager(new EfCartDal());
            shippingDetailService = new ShippingDetailManager(new EfShippingDetailDal(), _cartService);
        }    
        // GET: Payment
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Pay()
        {
            int id = (int)Session["Member"];
            var carts = _cartService.GetMemberById(id);
            ViewBag.CardAmount = carts.Select(x => x.Product.ProductPrice * x.Quantity).Sum();
            return View();
		}

        [HttpPost]
        public ActionResult Pay(CreditCard creditCard)
        {
            int id = (int)Session["Member"];
            var carts = _cartService.GetMemberById(id);
            //banka servisi kullanarak para çekildi
            shippingDetailService.Pay(new ShippingDetail
            {
                CardName = creditCard.CardName,
                CardNumber = creditCard.CardNumber,
                CVV = creditCard.CVV,
                MemberId = id,
                Amount = carts.Select(x => x.Product.ProductPrice * x.Quantity).Sum(),
            });
            return RedirectToAction("ProductList", "Product");
        }
    }
}