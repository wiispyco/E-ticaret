using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SiparisUygulama.Business;
using SiparisUygulama.Contract.DataContract.Dto;
using SiparisUygulama.Web.Models.RestaurantFood;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SiparisUygulama.Web.Controllers
{
    [Authorize (Roles ="RestaurantOwner")]
    public class RoRestaurantFoodController : Controller
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

        public RoRestaurantFoodController(ILogger<RestaurantFoodController> logger, IRestaurantFoodService restaurantFoodService, IRestaurantService restaurantService, IWebHostEnvironment webHostEnvironment)
        {
            _logger = logger;
            _restaurantFoodService = restaurantFoodService;
            _restaurantService = restaurantService;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult AddOrUpdate(int? id)
        {
            var userId = GetUserId();
            RestaurantFoodViewModel model;

            if (id.HasValue && id > 0)
            {
                // Güncelleme işlemi için mevcut yemeği al
                var dto = _restaurantFoodService.GetById(id.Value);
                if (dto == null)
                {
                    return NotFound();
                }

                model = new RestaurantFoodViewModel
                {
                    Id = dto.Id,
                    FoodName = dto.FoodName,
                    Price = dto.Price,
                    Control = dto.Control,
                    RestaurantId = dto.RestaurantId,
                    FoodImgFileName = dto.FoodImgFileName,
                   
                };
            }
            else
            {
                // Yeni yemek ekleme işlemi için boş model oluştur
                model = new RestaurantFoodViewModel();
            }

            var errorMsg = TempData["ErrorMsg"]?.ToString();
            if (!string.IsNullOrEmpty(errorMsg))
            {
                ViewBag.ErrorMsg = errorMsg;
            }

            return View(model);
        }

        [HttpPost]
        public JsonResult AddOrUpdate(RestaurantFoodViewModel model)
        {
            if (ModelState.IsValid)
            {
                var userId = GetUserId();


                RestaurantFoodDto dto = null;

                string uniqueFileName = null;

                if (model.FoodImgFile != null)
                {       
                    var isImg=IsImage(model.FoodImgFile);
                    if (!isImg)
                    {
                        return Json(new { success = false, message = "Lütfen resim dosyası yükleyiniz." });
                    }

                    uniqueFileName = Guid.NewGuid().ToString() + "_" + model.FoodImgFile.FileName;
                }

                if (model.Id > 0)
                {
                    // Güncelleme işlemi
                     dto = _restaurantFoodService.GetById(model.Id);
                    if (dto == null)
                    {
                        return Json(new { success = false });
                    }

                    dto.FoodName = model.FoodName;
                    dto.Price = model.Price;
                    dto.Control = model.Control;
                    dto.FoodImgFileName = model.FoodImgFile != null ?  uniqueFileName : model.FoodImgFileName ;                                                    
                }
                else
                {
                    // Yeni yemek ekleme işlemi
                     dto = new RestaurantFoodDto
                    {
                        FoodName = model.FoodName,
                        Price = model.Price,
                        Control = model.Control,
                        RestaurantId = userId, // Kullanıcıya ait restoran ID'sini burada kullanabilirsiniz
                        FoodImgFileName = model.FoodImgFile != null ? uniqueFileName : model.FoodImgFileName,
                    };                  
                }

                var response= _restaurantFoodService.AddOrUpdate(dto);

                if (response.hasError)
                {
                    return Json(new { success = false, message = "İşlem sırasında bir hata oluştu." });
                }

                try
                {
                    // Dosya yükleme işlemi
                   
                    if (model.FoodImgFile != null)
                    {
                        string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "Files\\RestaurantFood\\");
                        string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            model.FoodImgFile.CopyTo(fileStream);
                        }
                    }
                }
                catch(Exception ex)
                {
                    return Json(new { success = true, warning= true , message = "Kayıt işlemi başarılı fakat dosya yüklenirken bir hata oluştu." });
                }
               

                return Json(new { success = true, message = "İşlem başarılı." });
            }

            return Json(new { success = false, message="Girdiğiniz bilgileri kontrol ediniz." });
        }

        [HttpGet]
        public IActionResult Lists()
        {
            int userId = GetUserId();
            List<RestaurantFoodViewModel> model = new List<RestaurantFoodViewModel>();
            List<RestaurantFoodDto> dtos = _restaurantFoodService.GetByRestaurantId(userId);
            model = dtos.Select(x => new RestaurantFoodViewModel()
            {
                Id = x.Id,
                FoodName = x.FoodName,
                RestaurantId = x.RestaurantId,
                Control = x.Control,
                Price = x.Price,
                Restaurant = new Models.Restaurant.RestaurantViewModel()
                {
                    RestaurantName = x.Restaurant.RestaurantName,
                    OpeningTime = x.Restaurant.OpeningTime,
                    ClosingTime = x.Restaurant.ClosingTime,
                }

            }).ToList();

            var errorMsg = TempData["ErrorMsg"]?.ToString();
            if (!string.IsNullOrEmpty(errorMsg))
            {
                ViewBag.ErrorMsg = errorMsg;
            }

            return View(model);
        }
        public IActionResult Delete(int id)
        {
            var isExistCartDetail = _restaurantFoodService.IsExistCartDetail(id);
            if (isExistCartDetail)
            {
                TempData["ErrorMsg"] = "Bu ürün bir sepette mevcut olduğu için silemezsiniz.";
                return RedirectToAction("Lists");
            }
            var response = _restaurantFoodService.Delete(id);
            return RedirectToAction("Lists", "RestaurantFood");
        }


        public static bool IsImage(IFormFile postedFile)
        {
            //-------------------------------------------
            //  Check the image mime types
            //-------------------------------------------
            if (!string.Equals(postedFile.ContentType, "image/jpg", StringComparison.OrdinalIgnoreCase) &&
                !string.Equals(postedFile.ContentType, "image/jpeg", StringComparison.OrdinalIgnoreCase) &&
                !string.Equals(postedFile.ContentType, "image/pjpeg", StringComparison.OrdinalIgnoreCase) &&
                !string.Equals(postedFile.ContentType, "image/gif", StringComparison.OrdinalIgnoreCase) &&
                !string.Equals(postedFile.ContentType, "image/x-png", StringComparison.OrdinalIgnoreCase) &&
                !string.Equals(postedFile.ContentType, "image/svg+xml", StringComparison.OrdinalIgnoreCase) &&
                !string.Equals(postedFile.ContentType, "image/png", StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }

            //-------------------------------------------
            //  Check the image extension
            //-------------------------------------------
            var postedFileExtension = Path.GetExtension(postedFile.FileName);
            if (!string.Equals(postedFileExtension, ".jpg", StringComparison.OrdinalIgnoreCase)
                && !string.Equals(postedFileExtension, ".png", StringComparison.OrdinalIgnoreCase)
                && !string.Equals(postedFileExtension, ".gif", StringComparison.OrdinalIgnoreCase)
                && !string.Equals(postedFileExtension, ".jpeg", StringComparison.OrdinalIgnoreCase)
                && !string.Equals(postedFileExtension, ".svg", StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }

            return true;
        }




        //private string GetFoodImgPath()
        //{
        //    //DateTime.Now.Ticks
        //    string webRootPath = _webHostEnvironment.WebRootPath;

        //    string path = Path.Combine(webRootPath, "Files\\RestaurantFood\\"); //ya " 'dan önce  @ ya da çift slash koyuyoruz

        //    return path;
        //}
    }
}
