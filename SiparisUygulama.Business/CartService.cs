using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using SiparisUygulama.Contract.DataContract;
using SiparisUygulama.Contract.DataContract.Dto;
using SiparisUygulama.Contract.DataContract.Model;
using SiparisUygulama.Data.Db;
using SiparisUygulama.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;
using System.Xml.Schema;

namespace SiparisUygulama.Business
{
    public interface ICartService
    {
        CartSummaryModel GetCartByUserId(int userId);
        List<CartSummaryModel> GetAll();
        List<CartSummaryModel> GetOrders();
        Cart UpdateOrderStatus(int cartId,int status);
        Cart GetCart(int cartId);
        bool AddProduct(int restaurantFoodId, int quantity, int userId);




        //void AddProduct(RestaurantFoodDto restaurantFood,int quantity);
        //void Delete(int id);
        //double Total();
    }
    public class CartService : ICartService
    {
        private readonly DataContext _dataContext;

        public CartService(DataContext dataContext) { _dataContext = dataContext; }

        public CartSummaryModel GetCartByUserId(int userId)
        {
            var result = _dataContext.Carts
                .Where(x => x.UserId == userId).Select(x => new CartSummaryModel()
                {
                    CartId = x.Id,
                    Status = x.Status,
                    UserId = x.UserId,
                    OrderNumber = x.OrderNumber,
                    Total = x.Total,
                    Details = x.Details.Select(y => new CartSummaryDetailModel()
                    {
                        Id = y.Id,
                        FoodName = y.RestaurantFood.FoodName,
                        FoodPrice = y.RestaurantFood.Price,
                        Quantity = y.Quantity,
                        RestaurantName = y.RestaurantFood.Restaurant.RestaurantName,
                        Total = y.Total
                    }).ToList()

                }).FirstOrDefault();
            return result;
        }

        public Cart GetCart(int userId)
        {
            var cart = _dataContext.Carts.FirstOrDefault(x => x.UserId == userId);
            if (cart != null)
            {
                cart.Status = (int)Enums.CartStatusEnum.Created;
                _dataContext.SaveChanges();
            }
            return cart;
        }

        public Cart UpdateOrderStatus(int cartId,int status)
        { 
            var cart = _dataContext.Carts
                .Include(x=>x.User)
                .FirstOrDefault(x => x.Id == cartId);
            if (cart != null)
            {

                cart.Status = status;
                _dataContext.SaveChanges();

            }
            return cart;
        }

        public List<CartSummaryModel> GetOrders()
        {
            var data = _dataContext.Carts;


            var carts = data.Select(x => new CartSummaryModel()
            {
                OrderNumber = x.OrderNumber,
                Total = x.Total,
                Status = x.Status,
                UserId = x.UserId,
                CartId = x.Id,
            }).ToList();

            return carts;
        }

        public List<CartSummaryModel> GetAll()
        {
            var data = _dataContext.Carts;

            var carts = data.Select(x => new CartSummaryModel()
            {
                OrderNumber = x.OrderNumber,
                Total = x.Total,
                Status = x.Status,
                Details = x.Details.Select(y => new CartSummaryDetailModel()
                {
                    Id = y.Id,
                    FoodName = y.RestaurantFood.FoodName,
                    FoodPrice = y.RestaurantFood.Price,
                    Quantity = y.Quantity,
                    RestaurantName = y.RestaurantFood.Restaurant.RestaurantName,
                    Total = y.Total
                }).ToList()
            }).ToList();

            return carts;
        }


        public bool AddProduct(int restaurantFoodId, int quantity, int userId)
        {
            try
            {
                Random rnd = new Random();
                using (TransactionScope trScope = new TransactionScope())
                {
                    //Yemeğin bilgileri çekilir.
                    var food = _dataContext.RestaurantFoods.FirstOrDefault(x => x.Id == restaurantFoodId);
                    //Kullanıcının sepet bilgisi çekilir.
                    var cart = _dataContext.Carts.FirstOrDefault(x => x.UserId == userId);

                    //Kullanıcının sepet bilgisi yoksa sepet oluşturulur.
                    if (cart == null)
                    {
                        var a = (int)Enums.CartStatusEnum.Draft;
                        cart = new Cart()
                        {
                            UserId = userId,
                            OrderNumber = rnd.Next(),
                            Total = 0,
                            Status = a
                        };
                        _dataContext.Carts.Add(cart);
                        _dataContext.SaveChanges();
                    }
                    else
                    {
                        // Sepetteki mevcut ürünlerin restoran ID'sini al
                        var existingCartDetails = _dataContext.CartsDetail.Where(cd => cd.CartId == cart.Id).ToList();
                        if (existingCartDetails.Any())
                        {
                            var existingRestaurantFood = existingCartDetails.First().RestaurantFoodId;
                            var existingRestaurantId = _dataContext.RestaurantFoods.FirstOrDefault(rf => rf.Id == existingRestaurantFood)?.RestaurantId;

                            // Eğer mevcut sepetin restoranı, eklenmek istenen yemeğin restoranından farklıysa
                            if (existingRestaurantId != null && existingRestaurantId != food.RestaurantId)
                            {
                                // Yeni ürün eklenmesini engelle ve işlemden çık
                                return false; // Bu durumda kullanıcıya uygun bir mesaj gösterilmeli
                            }
                        }
                    }
                    //Sepette bu ürün zaten var mı kontrol et
                    var cartDetail = _dataContext.CartsDetail.FirstOrDefault(cd => cd.CartId == cart.Id && cd.RestaurantFoodId == restaurantFoodId);

                    if (cartDetail != null)
                    {
                        // Ürün zaten varsa miktarını güncelle
                        cartDetail.Quantity += quantity;
                        cartDetail.Total = cartDetail.Quantity * food.Price;
                        _dataContext.CartsDetail.Update(cartDetail);
                    }
                    else
                    {
                        // Ürün yoksa yeni ürün ekle
                        cartDetail = new CartDetail()
                        {
                            CartId = cart.Id,
                            Quantity = quantity,
                            RestaurantFoodId = restaurantFoodId,
                            Total = quantity * food.Price
                        };
                        _dataContext.CartsDetail.Add(cartDetail);
                    }

                    //Sepet fiyat güncelleme
                    //cart.Total = _dataContext.CartsDetail.Where(cd => cd.CartId == cart.Id).Sum(cd => cd.Total);
                    cart.Total = cartDetail.Total;

                    _dataContext.Carts.Update(cart);
                    _dataContext.SaveChanges();

                    trScope.Complete();
                }

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}






