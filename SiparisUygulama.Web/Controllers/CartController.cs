using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SiparisUygulama.Business;
using SiparisUygulama.Contract.DataContract;
using SiparisUygulama.Contract.DataContract.Dto;
using SiparisUygulama.Contract.DataContract.Model;
using SiparisUygulama.Data.Db;
using SiparisUygulama.Data.Entity;
using SiparisUygulama.Web.Models.Cart;
using SiparisUygulama.Web.Models.CartDetail;
using SiparisUygulama.Web.Models.Order;
using System.Collections.Generic;
using System.Linq;

namespace SiparisUygulama.Web.Controllers
{
    [Authorize(Roles = "Customer")]
    public class CartController : Controller
    {
        private readonly ILogger<CartController> _logger;
        private readonly ICartService _cartService;
        private readonly ICartDetailService _cartDetailService;
       


        public CartController(ILogger<CartController> logger, ICartService cartService, ICartDetailService cartDetailService)
        {
            _logger = logger;
            _cartService = cartService;
            _cartDetailService = cartDetailService;
        }
        private int GetUserId()
        {
            var userId = User.Identity.IsAuthenticated && User.Claims.Any(m => m.Type == "UserId") ? int.Parse(User.Claims.FirstOrDefault(m => m.Type == "UserId").Value) : 0;
            return userId;
        }
        public IActionResult Index()
        {
            var userId = GetUserId();
            var cart = _cartService.GetCartByUserId(userId);

            return View(cart);
        }

        [HttpPost]
        public IActionResult AddProduct(AddProductViewModel model)
        {

            var userId = GetUserId();

            var result = _cartService.AddProduct(model.RestaurantFoodId, model.Quantity, userId);
            if (result)
            {
                return Json(new { success = result, message = "Ürün sepete eklenmiştir." });
            }
            else
            {
                return Json(new { success = result, message = "İşlem sırasında hata oluştu." });
            }
        }

        [HttpPost]
        public JsonResult UpdateQuantity(int id, int quantity, int cartid)
        {
            var response = new BaseResponse();
            if (quantity < 0)
            {
                return Json(new { success = false, message = "Miktar 0'dan küçük olamaz." });
            }
            if (quantity == 0)
            {
                response = _cartDetailService.Delete(id, cartid); // Sepetten sil
            }
            else
            {
                response = _cartDetailService.Update(id, quantity);
            }

            if (response.hasError)
            {
                return Json(new { success = false, message = response.message });
            }


            return Json(new { success = response, message = "Miktar başarıyla güncellendi." });
        }


        [HttpPost]
        public IActionResult UpdateCartCount()
        {
            var cart = _cartDetailService.GetDetailByUserId(GetUserId());
            var totalQuantity = cart.Sum(x => x.Quantity);
            return Json(totalQuantity);
        }

        [HttpPost]
        public IActionResult UpdateCartStatus()
        {
            var cart = _cartService.GetCart(GetUserId());

            return Json(new { success = true, cart });
        }

    }


}

