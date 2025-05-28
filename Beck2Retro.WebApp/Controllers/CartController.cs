using Back2Retro.Bll;
using Back2Retro.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using static Back2Retro.Bll.ProductBll;

namespace Back2Retro.WebApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductService _service = new ProductService();

        public ActionResult Details(int id)
        {
            Product product = _service.GetById(id);
            if (product == null)
            {
                return HttpNotFound();
            }

            return View(product);
        }

        public ActionResult AddToCart(int id)
        {
            Product product = _service.GetById(id);
            if (product == null)
            {
                return HttpNotFound();
            }

            CartService.AddToCart(Session, product);
            return RedirectToAction("Cart");
        }

        [HttpPost]
        public ActionResult ApplyDiscount(string discountCode)
        {
            var cart = CartService.GetCart(Session); // используем CartService для согласованности

            decimal discountPercent = 0;

            if (discountCode == "SALE10")
                discountPercent = 0.10m;
            else if (discountCode == "SALE20")
                discountPercent = 0.20m;
            else if (discountCode == "SALE30")
                discountPercent = 0.30m;
            else if (discountCode == "SALE40")
                discountPercent = 0.40m;
            else if (discountCode == "SALE50")
                discountPercent = 0.50m;
            else if (discountCode == "SALE60")
                discountPercent = 0.60m;
            else if (discountCode == "SALE70")
                discountPercent = 0.70m;
            else if (discountCode == "SALE80")
                discountPercent = 0.80m;
            else if (discountCode == "SALE90")
                discountPercent = 0.90m;
            else
            {
                TempData["DiscountMessage"] = "Invalid discount code.";
                TempData["Total"] = CartService.GetTotalPrice(Session).ToString("0.00");
                return RedirectToAction("Cart");
            }

            decimal total = cart.Sum(item => item.Product.Price * item.Quantity);
            total -= total * discountPercent;

            TempData["DiscountMessage"] = $"Discount applied: {discountPercent * 100}% off!";
            TempData["Total"] = total.ToString("0.00");

            return RedirectToAction("Cart");
        }




        public ActionResult Cart()
        {
            var cart = CartService.GetCart(Session);
            ViewBag.DiscountMessage = TempData["DiscountMessage"];
            ViewBag.Total = TempData["Total"] ?? CartService.GetTotalPrice(Session);
            return View(cart);
        }

        public ActionResult RemoveFromCart(int id)
        {
            CartService.RemoveFromCart(Session, id);
            return RedirectToAction("Cart");
        }
    }
}
