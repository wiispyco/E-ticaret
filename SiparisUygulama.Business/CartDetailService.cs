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
    public interface ICartDetailService
    {
        List<CartDetailDto> GetDetailByUserId(int userId);
        List<CartSummaryDetailModel> GetDetailByCartId(int cartId);
        BaseResponse Update(int id,int quantity);
        BaseResponse Delete(int id, int cartId);
    }
    public class CartDetailService : ICartDetailService
    {
        private readonly DataContext _dataContext;

        public CartDetailService(DataContext dataContext) { _dataContext = dataContext; }


        public List<CartDetailDto> GetDetailByUserId(int userId)

        {
            var result = _dataContext.CartsDetail
                .Include(x => x.Cart)
                .Include(x => x.RestaurantFood).ThenInclude(x => x.Restaurant)
                .Where(x => x.Cart.UserId == userId).Select(x => new CartDetailDto()
                {
                    Id = x.Id,
                    Quantity = x.Quantity,
                    CartId = x.CartId,
                    Total = x.Total,
                    Cart = new CartDto() { OrderNumber = x.Cart.OrderNumber, },
                    RestaurantFood = new RestaurantFoodDto()
                    {
                        FoodName = x.RestaurantFood.FoodName,
                        Restaurant = new RestaurantDto() { RestaurantName = x.RestaurantFood.Restaurant.RestaurantName }
                    }
                }).ToList();
            return result;

            //var result2 = _dataContext.Carts.Include(x => x.Details).ThenInclude(x => x.RestaurantFood).ThenInclude(x => x.Restaurant)
            //    .Where(x => x.UserId == userId).SelectMany(x => x.Details).Select(x => new CartDetailDto()
            //    {
            //        Id = x.Id,
            //        Quantity = x.Quantity,
            //        Total = x.Total,
            //        Cart = new CartDto() { OrderNumber = x.Cart.OrderNumber, },
            //        RestaurantFood = new RestaurantFoodDto()
            //        {
            //            FoodName = x.RestaurantFood.FoodName,
            //            Restaurant = new RestaurantDto() { RestaurantName = x.RestaurantFood.Restaurant.RestaurantName }
            //        }
            //    }).ToList();

        }
        public BaseResponse Delete(int id, int cartId)
        {
            var response = new BaseResponse();
            try
            {

                var ent = _dataContext.CartsDetail.Find(id);
                var cart=_dataContext.Carts.FirstOrDefault(x => x.Id == cartId);

                cart.Total=cart.Total-ent.Total;
                _dataContext.CartsDetail.Remove(ent);
                _dataContext.Carts.Update(cart);


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

        public List<CartSummaryDetailModel> GetDetailByCartId(int cartId)
        {
            var result = _dataContext.CartsDetail.Where(x => x.CartId == cartId).Select(x => new CartSummaryDetailModel()
            {
                Id = x.Id,
                FoodName=x.RestaurantFood.FoodName,
                FoodPrice=x.RestaurantFood.Price,
                Quantity=x.Quantity,
                Total=x.Total,
                RestaurantName=x.RestaurantFood.Restaurant.RestaurantName,
            }).ToList();

            return result;
        }

        public BaseResponse Update(int id,int quantity)
        {
            var response = new BaseResponse();
            try
            {
                
                var cartDetail = _dataContext.CartsDetail.Find(id);
                var food = _dataContext.RestaurantFoods.FirstOrDefault(x => x.Id == cartDetail.RestaurantFoodId);
                if (cartDetail == null)
                {
                    response.hasError = true;
                    response.message = "Ürün bulunamadı.";
                    return response;
                }

                // Miktarı güncelle
                cartDetail.Quantity = quantity;
                // Toplam fiyatı yeniden hesapla
                cartDetail.Total = cartDetail.Quantity * food.Price;

                _dataContext.CartsDetail.Update(cartDetail);
                _dataContext.SaveChanges();

                response.hasError = false;
                response.message = "İşlem başarılı.";
            }
            catch (Exception ex)
            {
                response.hasError = true;
                response.message = "İşlem sırasında bir hata oluştu.";
                return response;
            }
            return response;
        }
    }

}
