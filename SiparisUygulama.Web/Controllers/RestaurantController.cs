using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Extensions.Logging;
using SiparisUygulama.Business;
using SiparisUygulama.Contract.DataContract.Dto;
using SiparisUygulama.Web.Models.Restaurant;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using static System.Net.Mime.MediaTypeNames;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

namespace SiparisUygulama.Web.Controllers
{
    [Authorize(Roles = "RestaurantOwner")]
    public class RestaurantController : Controller
    {
        private readonly ILogger<RestaurantController> _logger;
        private readonly IRestaurantService _restaurantService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public RestaurantController(ILogger<RestaurantController> logger, IRestaurantService restaurantService, IWebHostEnvironment webHostEnvironment) 
        {
            _logger = logger;
            _restaurantService = restaurantService;
            _webHostEnvironment = webHostEnvironment;
        }
        private int GetUserId()
        {
            var userId=User.Identity.IsAuthenticated && User.Claims.Any(m => m.Type == "UserId") ? int.Parse(User.Claims.FirstOrDefault(m => m.Type == "UserId").Value) : 0;
            return userId;
        }
        public IActionResult Index()
        {
            var userId = GetUserId();
            RestaurantViewModel model = new RestaurantViewModel();
            model.UserId = userId;
            

            RestaurantDto dto = _restaurantService.GetByUserId(userId);

            if (dto!= null)
            {
                model.Id = dto.Id;
                model.OpeningTime = dto.OpeningTime;
                model.ClosingTime = dto.ClosingTime;
                model.RestaurantName = dto.RestaurantName;
                model.RestaurantImgFileName = dto.RestaurantImgFileName;
            }
            return View(model);
        }
           
        [HttpPost]
        public IActionResult Index(RestaurantViewModel model) 
        { 
            if (ModelState.IsValid) 
            {
                RestaurantDto dto = null;

                string uniqueFileName = null;

                if (model.RestaurantImgFile != null)
                {
                    var isImg = IsImage(model.RestaurantImgFile);
                    if (!isImg)
                    {
                        return Json(new { success = false, message = "Lütfen resim dosyası yükleyiniz." });
                    }

                    uniqueFileName = Guid.NewGuid().ToString() + "_" + model.RestaurantImgFile.FileName;
                }

                dto = new RestaurantDto();
                dto.Id = model.Id;
                dto.UserId = GetUserId() ;
                dto.OpeningTime = model.OpeningTime;
                dto.ClosingTime = model.ClosingTime;
                dto.RestaurantName=model.RestaurantName;
                dto.RestaurantImgFileName = model.RestaurantImgFile != null ? uniqueFileName : model.RestaurantImgFileName;

                var response = _restaurantService.AddOrUpdate(dto);

                try
                {
                    // Dosya yükleme işlemi

                    if (model.RestaurantImgFile != null)
                    {
                        string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "Files\\Restaurant\\");
                        string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            model.RestaurantImgFile.CopyTo(fileStream);
                        }
                    }
                }
                catch (Exception ex)
                {
                    return Json(new { success = true, warning = true, message = "Kayıt işlemi başarılı fakat dosya yüklenirken bir hata oluştu." });
                }

                return RedirectToAction("Index","Restaurant");
            }
            model.ErrorMessages  = new List<string>() { "Girdiğiniz bilgileri kontrol ediniz" };

            return View(model);
        }

        public IActionResult Delete(int id)
        {
            var response =  _restaurantService.Delete(id);
            

            return RedirectToAction("Index","Restaurant");
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

    }
}
