using Microsoft.EntityFrameworkCore;
using SiparisUygulama.Contract.DataContract.Dto;
using SiparisUygulama.Contract.DataContract.Model;
using SiparisUygulama.Data.Db;
using SiparisUygulama.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SiparisUygulama.Business
{
    public interface IRestaurantFoodService
    {
        List<RestaurantFoodDto> GetAll();
        List<RestaurantFoodDto> GetByRestaurantId(int id);

        bool IsExistCartDetail(int id);
        RestaurantFoodDto GetById(int id);
        BaseResponse AddOrUpdate(RestaurantFoodDto dto);
        BaseResponse Lists(RestaurantFoodDto dto);
        BaseResponse Delete(int id);
    }
    public class RestaurantFoodService : IRestaurantFoodService
    {
        private readonly DataContext _dataContext;


        public RestaurantFoodService(DataContext dataContext) { _dataContext = dataContext; }
        public List<RestaurantFoodDto> GetAll()
        {
            var data = _dataContext.RestaurantFoods.Include(x => x.Restaurant).OrderBy(x => x.Id);

            var restaurantfoods = data.Select(x => new RestaurantFoodDto
            {
                Id = x.Id,
                FoodName = x.FoodName,
                Price = x.Price,
                Control = x.Control,
                RestaurantId = x.RestaurantId,
                FoodImgFileName = x.FoodImgFileName,
                Restaurant = new RestaurantDto()
                {
                    RestaurantName = x.Restaurant.RestaurantName,
                    OpeningTime = x.Restaurant.OpeningTime,
                    ClosingTime = x.Restaurant.ClosingTime,
                    RestaurantImgFileName = x.Restaurant.ImgFileName,

                }
            }).ToList();
            return restaurantfoods;
        }
        public RestaurantFoodDto GetById(int id)
        {
            var ent = _dataContext.RestaurantFoods.Include(x => x.Restaurant).FirstOrDefault(x => x.Id == id);
            var restaurantFood = new RestaurantFoodDto
            {
                Id = ent.Id,
                RestaurantId = ent.RestaurantId,
                Control = ent.Control,
                Price = ent.Price,
                FoodName = ent.FoodName,
                FoodImgFileName = ent.FoodImgFileName,
                Restaurant = new RestaurantDto()
                {
                    RestaurantName = ent.FoodName,
                    OpeningTime = ent.Restaurant.OpeningTime,
                    ClosingTime = ent.Restaurant.ClosingTime,
                    RestaurantImgFileName = ent.FoodImgFileName,

                }
            };
            return restaurantFood;
        }

        public BaseResponse AddOrUpdate(RestaurantFoodDto dto)
        {

            var response = new BaseResponse();
            try
            {
                var ent = _dataContext.RestaurantFoods.FirstOrDefault(x => x.Id == dto.Id);
                if (ent == null)
                {
                    ent = new RestaurantFood
                    {

                        RestaurantId = dto.RestaurantId,
                        FoodName = dto.FoodName,
                        Price = dto.Price,
                        Control = dto.Control,
                        FoodImgFileName = dto.FoodImgFileName,

                    };
                    _dataContext.RestaurantFoods.Add(ent);
                }
                else
                {
                    ent.Id = dto.Id;
                    ent.RestaurantId = dto.RestaurantId;
                    ent.FoodName = dto.FoodName;
                    ent.Price = dto.Price;
                    ent.Control = dto.Control;
                    ent.FoodImgFileName = dto.FoodImgFileName;

                    _dataContext.RestaurantFoods.Update(ent);
                }
                _dataContext.SaveChanges();

                response.hasError = false;
                response.message = "İşlem Başarılı";
            }
            catch (Exception ex)
            {
                response.hasError = true;
                response.message = "İşlem sırasında bir hata oluştu";
            }
            return response;


        }
        public BaseResponse Lists(RestaurantFoodDto dto)
        {
            var response = new BaseResponse();
            try
            {
                var ent = new RestaurantFood();

                ent.Id = dto.Id;
                ent.RestaurantId = dto.RestaurantId;
                ent.FoodName = dto.FoodName;
                ent.Control = dto.Control;
                ent.Price = dto.Price;
                ent.FoodImgFileName = dto.FoodImgFileName;

                _dataContext.RestaurantFoods.Add(ent);
                _dataContext.SaveChanges();

                response.hasError = false;
                response.message = "İşlem Başarılı";
            }
            catch (Exception ex)
            {
                response.hasError = true;
                response.message = "İşlem sırasında bir hata oluştu";
            }
            return response;
        }

        public BaseResponse Delete(int id)
        {
            var response = new BaseResponse();

            try
            {
                var ent = _dataContext.RestaurantFoods.Find(id);
                _dataContext.RestaurantFoods.Remove(ent);
                _dataContext.SaveChanges();

                response.hasError = false;
                response.message = "İşlem Başarılı";
            }
            catch (Exception ex)
            {
                response.hasError = true;
                response.message = "İşlem sırasında bir hata oluştu";
                return response;

            }
            return response;
        }
        public bool IsExistCartDetail(int id)
        {
            var result = _dataContext.CartsDetail
                .Any(x => x.RestaurantFoodId == id);


            return result;
        }


        public List<RestaurantFoodDto> GetByRestaurantId(int id)
        {
            var result = _dataContext.RestaurantFoods.Include(x => x.Restaurant)
                .Where(x => x.Restaurant.Id == id).Select(x => new RestaurantFoodDto()
                {
                    Id = x.Id,
                    RestaurantId = x.Restaurant.Id,
                    Control = x.Control,
                    FoodName = x.FoodName,
                    Price = x.Price,
                    FoodImgFileName = x.FoodImgFileName,
                    Restaurant = new RestaurantDto()
                    {
                        RestaurantName = x.Restaurant.RestaurantName,
                        OpeningTime = x.Restaurant.OpeningTime,
                        ClosingTime = x.Restaurant.ClosingTime,
                        RestaurantImgFileName = x.Restaurant.ImgFileName,
                    }
                }).ToList();
            return result;
        }


    }
}
