using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SiparisUygulama.Business;
using SiparisUygulama.Contract.DataContract;
using System.Collections.Generic;
using System.Linq;

namespace SiparisUygulama.Web.Controllers
{
    [Authorize(Roles = "RestaurantOwner")]
    public class RoCartController : Controller
    {
        private readonly ILogger<CartController> _logger;
        private readonly ICartService _cartService;
        private readonly ICartDetailService _cartDetailService;
        private readonly IEmailService _emailService;

        public RoCartController(ILogger<CartController> logger, ICartService cartService, ICartDetailService cartDetailService, IEmailService emailService)
        {
            _logger = logger;
            _cartService = cartService;
            _cartDetailService = cartDetailService;
            _emailService = emailService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Order() 
        {
            var carts = _cartService.GetOrders();
            var visibleCarts = carts.Where(cart => cart.Status != (int)Enums.CartStatusEnum.Draft).ToList();//filtreyi önce yap.
            ViewBag.CanEditStatus = true;

            return View(visibleCarts);
        }

        [HttpPost]
        public IActionResult UpdateOrderStatus(int cartId,int status)
        {
            var result = _cartService.UpdateOrderStatus(cartId,status);
            if (result.User != null && !string.IsNullOrEmpty(result.User.Email))
            {
                var subject = "Sipariş Durumu Güncellemesi";
                var changedStatus = (Enums.CartStatusEnum)result.Status;
                var body = $"Siparişinizin durumu '{changedStatus}' olarak güncellenmiştir.";
                _emailService.SendEmail(result.User.Email, subject, body);
            }
            else
            {
                // User veya Email bilgisi eksikse bir hata mesajı döner
                return Json(new { success = false, message = "Kullanıcı e-posta adresi bulunamadı." });
            }

            return RedirectToAction("OrderDetails", new { id = result.OrderNumber });
        }

        public IActionResult OrderDetails(int cartId) //restoran sahibi
        {
            var result = _cartDetailService.GetDetailByCartId(cartId);
            return View(result);
        }
    }
}
