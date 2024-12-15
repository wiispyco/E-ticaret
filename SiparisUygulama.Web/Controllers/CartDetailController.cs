using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SiparisUygulama.Business;
using SiparisUygulama.Contract.DataContract.Dto;
using SiparisUygulama.Contract.DataContract.Model;
using SiparisUygulama.Data.Entity;
using SiparisUygulama.Web.Models.CartDetail;
using SiparisUygulama.Web.Models.Order;
using SiparisUygulama.Web.Models.RestaurantFood;
using System.Collections.Generic;
using System.Linq;

namespace SiparisUygulama.Web.Controllers
{
    [Authorize]

    public class CartDetailController : Controller
    {
        private readonly ILogger<CartDetailController> _logger;
        private readonly ICartDetailService _cartDetailService;
        


        public CartDetailController(ILogger<CartDetailController> logger, ICartDetailService cartDetailService)
        {
            _logger = logger;
            _cartDetailService = cartDetailService;
           
        }

        private int GetUserId()
        {
            var userId = User.Identity.IsAuthenticated && User.Claims.Any(m => m.Type == "UserId") ? int.Parse(User.Claims.FirstOrDefault(m => m.Type == "UserId").Value) : 0;
            return userId;
        }
        public IActionResult Index()
        {
            //var userId = GetUserId();
            //List<CartDetailViewModel> model = new List<CartDetailViewModel>();
            //List < CartDetailDto > dtos = _cartDetailService.GetDetailByUserId(userId);
            //model=dtos.Select(x=>new CartDetailViewModel()
            //{
            //    Id = x.Id,
            //    CartId = x.CartId,
            //    Quantity = x.Quantity,
            //    Total = x.Total,
            //    RestaurantFood =new RestaurantFoodViewModel()
            //    {
            //        RestaurantName=x.RestaurantFood.Restaurant.RestaurantName,
            //        FoodName=x.RestaurantFood.FoodName,
            //    },
            //    Cart=new CartViewModel()
            //    {
            //        OrderNumber=x.Cart.OrderNumber,
            //    }

            //}).ToList();

           
            return View();
        }

        public IActionResult GetCartDetails()
        {
            var userId = GetUserId();
            List<CartDetailViewModel> model = new List<CartDetailViewModel>();
            List<CartDetailDto> dtos = _cartDetailService.GetDetailByUserId(userId);
            model = dtos.Select(x => new CartDetailViewModel()
            {
                Id = x.Id,
                CartId = x.CartId,
                Quantity = x.Quantity,
                Total = x.Total,
                RestaurantFood = new RestaurantFoodViewModel()
                {
                    RestaurantName = x.RestaurantFood.Restaurant.RestaurantName,
                    FoodName = x.RestaurantFood.FoodName,
                },
                Cart = new CartViewModel()
                {
                    OrderNumber = x.Cart.OrderNumber,
                }

            }).ToList();


            return PartialView("_CartDetails",model);
        }

        public JsonResult GetCartDetails2()
        {
            var userId = GetUserId();
            List<CartDetailViewModel> model = new List<CartDetailViewModel>();
            List<CartDetailDto> dtos = _cartDetailService.GetDetailByUserId(userId);
            model = dtos.Select(x => new CartDetailViewModel()
            {
                Id = x.Id,
                CartId = x.CartId,
                Quantity = x.Quantity,
                Total = x.Total,
                RestaurantFood = new RestaurantFoodViewModel()
                {
                    RestaurantName = x.RestaurantFood.Restaurant.RestaurantName,
                    FoodName = x.RestaurantFood.FoodName,
                },
                Cart = new CartViewModel()
                {
                    OrderNumber = x.Cart.OrderNumber,
                }

            }).ToList();


            return Json(model);
        }


        public JsonResult Delete(int id,int cartId)// return json
        {
            var response = _cartDetailService.Delete(id,cartId);
            return Json(response);
            
        }

       
    }

}
