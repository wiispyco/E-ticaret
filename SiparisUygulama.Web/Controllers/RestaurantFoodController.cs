using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SiparisUygulama.Business;
using SiparisUygulama.Contract.DataContract.Dto;
using SiparisUygulama.Data.Entity;
using SiparisUygulama.Web.Models.CartDetail;
using SiparisUygulama.Web.Models.Restaurant;
using SiparisUygulama.Web.Models.RestaurantFood;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;

namespace SiparisUygulama.Web.Controllers
{

    public class RestaurantFoodController : Controller
    {
        private readonly ILogger<RestaurantFoodController> _logger;
        private readonly IRestaurantFoodService _restaurantFoodService;
        private readonly IRestaurantService _restaurantService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        private int GetUserId()
        {
            var userId = User.Identity.IsAuthenticated && User.Claims.Any(m => m.Type == "UserId") ? int.Parse(User.Claims.FirstOrDefault(m => m.Type == "UserId").Value) : 0;
            return userId;
        }
        private int GetRestaurantId()
        {
            var restaurantId = User.Identity.IsAuthenticated && User.Claims.Any(m => m.Type == "RestaurantId") ? int.Parse(User.Claims.FirstOrDefault(m => m.Type == "RestaurantId").Value) : 0;
            return restaurantId;
        }


        public RestaurantFoodController(ILogger<RestaurantFoodController> logger, IRestaurantFoodService restaurantFoodService, IRestaurantService restaurantService, IWebHostEnvironment webHostEnvironment)
        {
            _logger = logger;
            _restaurantFoodService = restaurantFoodService;
            _restaurantService = restaurantService;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            var model = new MainRestaurantViewModel();

            var restaurants = _restaurantService.GetAll();

            model.Restaurants = restaurants.Select(m => new RestaurantViewModel()
            {
                Id = m.Id,
                RestaurantName = m.RestaurantName,
            }).ToList();

            model.RestaurantList = new SelectList(restaurants, "Id", "RestaurantName");

            return View(model);
        }

        public IActionResult RestaurantsFoods(int restaurantId)
        {

            var restaurantFoods = _restaurantFoodService.GetByRestaurantId(restaurantId);
            ViewBag.RestaurantId = restaurantId;
            return View(restaurantFoods);
        }

        public IActionResult GetRestaurantFood(int? restaurantId, string searchTerm)
        {
            List<RestaurantFoodDto> foodList;

            // Eğer restaurantId varsa, sadece o restoranın yemeklerini getir
            if (restaurantId.HasValue && restaurantId != 0)
            {
                foodList = _restaurantFoodService.GetByRestaurantId(restaurantId.Value);
            }
            else
            {
                // restaurantId yoksa tüm yemekleri getir
                foodList = _restaurantFoodService.GetAll();
            }

            // Eğer arama terimi varsa, yemek isimlerine göre filtrele
            if (!string.IsNullOrEmpty(searchTerm))
            {
                foodList = foodList.Where(x => x.FoodName.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            List<RestaurantFoodViewModel> model = foodList.Select(x => new RestaurantFoodViewModel()
            {
                Id = x.Id,
                FoodName = x.FoodName,
                RestaurantId = x.RestaurantId,
                Control = x.Control,
                Price = x.Price,
                RestaurantName = x.Restaurant.RestaurantName,
                OpeningTime = x.Restaurant.OpeningTime,
                ClosingTime = x.Restaurant.ClosingTime,
                FoodImgFileName = x.FoodImgFileName,
            }).ToList();

            return PartialView("_FoodList", model);
        }


        public IActionResult Restaurants()
        {
            List<RestaurantDto> rList = _restaurantService.GetAll();

            List<RestaurantViewModel> model = rList.Select(r => new RestaurantViewModel()
            {
                Id = r.Id,
                RestaurantName = r.RestaurantName,
                OpeningTime = r.OpeningTime,
                ClosingTime = r.ClosingTime,
                RestaurantImgFileName=r.RestaurantImgFileName,
            }).ToList();
            return PartialView("_RestaurantFood", model);
        }

        [HttpGet]
        public IActionResult GetFoodsByRestaurant(int id)
        { 
            var foods = _restaurantFoodService.GetByRestaurantId(id);

            
            var model = foods.Select(f => new RestaurantFoodViewModel()
            {
                Id = f.Id,
                FoodName = f.FoodName,
                Price = f.Price,
                RestaurantId = f.RestaurantId,
                OpeningTime = f.Restaurant.OpeningTime,
                ClosingTime = f.Restaurant.ClosingTime,
                FoodImgFileName=f.FoodImgFileName,
            }).ToList();

            return Json(model);
        }
    }
}

