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
    public interface IRestaurantService
    {
        List<RestaurantDto> GetAll();

        RestaurantDto GetById(int id);

        RestaurantDto GetByUserId(int userId);
        BaseResponse AddOrUpdate(RestaurantDto model);
        BaseResponse Delete(int id);
    }
    public class RestaurantService : IRestaurantService
    {
        private readonly DataContext _dataContext;

        public RestaurantService(DataContext dataContext) { _dataContext = dataContext; }

        public List<RestaurantDto> GetAll()
        {
            var data = _dataContext.Restaurants.OrderBy(x => x.Id);

            var restaurants = data.Select(x => new RestaurantDto
            {
                Id = x.Id,
                RestaurantName = x.RestaurantName,
                UserId = x.UserId,
                OpeningTime = x.OpeningTime,
                ClosingTime = x.ClosingTime,
                RestaurantImgFileName=x.ImgFileName,

            }).ToList();
            return restaurants;

        }
        public RestaurantDto GetById(int id)
        {
            var ent = _dataContext.Restaurants.Include(a=>a.User).FirstOrDefault(a => a.Id == id);

            var dto = new RestaurantDto()
            {
                Id = id,
                RestaurantName = ent.RestaurantName,
                UserId = ent.UserId,
                OpeningTime = ent.OpeningTime,
                ClosingTime = ent.ClosingTime,
                RestaurantImgFileName=ent.ImgFileName,
                User=new UserDto()
                {
                    Name = ent.User.Name,
                }
            };
            return dto;
        }

        public BaseResponse AddOrUpdate(RestaurantDto model)
        {
            var response = new BaseResponse();
            try
            {
                var ent = _dataContext.Restaurants.FirstOrDefault(x => x.Id == model.Id);

                if (ent == null)
                {
                    ent = new Restaurant();
                }

                ent.Id = model.Id;
                ent.RestaurantName = model.RestaurantName;
                ent.UserId = model.UserId;
                ent.OpeningTime = model.OpeningTime;
                ent.ClosingTime = model.ClosingTime;
                ent.ImgFileName = model.RestaurantImgFileName;
                if (ent.Id > 0)
                {
                    _dataContext.Restaurants.Update(ent);
                    _dataContext.SaveChanges();

                }
                else
                {
                    _dataContext.Restaurants.Add(ent);
                    _dataContext.SaveChanges();
                }
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

        public BaseResponse Delete(int id)
        {
            var response = new BaseResponse();
            try
            {
                var ent = _dataContext.Restaurants.Find(id);
                _dataContext.Restaurants.Remove(ent);
                _dataContext.SaveChanges();
                response.hasError = false;
                response.message = "İşlem Başarılı";
            }
            catch (Exception ex)
            {
                response.hasError = true;
                response.message = "İşlem Sırasında Bir Hata Oluştu";
                return response;
            }
            return response;
        }

        public RestaurantDto GetByUserId(int userId)
        {
            var ent= _dataContext.Restaurants.FirstOrDefault(x => x.UserId == userId);
            var dto = new RestaurantDto()
            {
                Id = ent.Id,
                RestaurantName = ent.RestaurantName,
                UserId = ent.UserId,
                OpeningTime = ent.OpeningTime,
                ClosingTime = ent.ClosingTime,
                RestaurantImgFileName=ent.ImgFileName,
            };
            return dto;

        }
    }
}
