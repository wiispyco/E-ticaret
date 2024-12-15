using SiparisUygulama.Contract.DataContract.Dto;
using SiparisUygulama.Contract.DataContract.Model;
using SiparisUygulama.Data.Db;
using SiparisUygulama.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace SiparisUygulama.Business
{
    public interface IAuthenticationService
    {
        AuthenticationResponse AuthenticateUser(AuthenticationRequest request);
        BaseResponse CreateUser(UserDto userDto);
    }
    public class AuthenticationBusiness : IAuthenticationService
    {
        private readonly DataContext _dataContext;

        public AuthenticationBusiness(IServiceProvider serviceProvider ,DataContext context) 
        {
            _dataContext = context;
        }

        public bool Authenticate(string username, string password)
        {
            var user = GetUserByUsername(username);

            return user != null;
        }

        public AuthenticationResponse AuthenticateUser(AuthenticationRequest request)
        {

            User dbuser = _dataContext.Users
                .Include(x=>x.Restaurants)
                .FirstOrDefault(x => x.Email == request.Email && x.Password == request.Password);
            
            AuthenticationResponse response = new AuthenticationResponse();

            if (dbuser !=null)
            {
                var user = GetUserByUsername(request.Email);
                response.FullName = $"{user.Name}";
                response.UserId = user.Id;
                response.Username = user.Email.ToString();
                response.RoleName = user.Role.RoleName;
                response.RestaurantId = dbuser.Restaurants.FirstOrDefault()?.Id;
                response.IsAuthenticated = true;
                
            }
            else
            {
                response.hasError = true;
                response.message = "Hatalı kullanıcı adı şifre";
            }
            return response;
        }

        public BaseResponse CreateUser(UserDto userDto)
        {
            BaseResponse response = new BaseResponse();
            var existingUser = _dataContext.Users.FirstOrDefault(x => x.Email == userDto.Email);
            if (existingUser != null)
            {
                response.SetError("Bu mail adresine ait bir kullanıcı var.");// Kullanıcı zaten var
                return response;
            }

            var user = new User()
            {
                Name = userDto.Name,
                Email = userDto.Email,
                Password = userDto.Password,
                Adress = userDto.Adress,
                RoleId = userDto.RoleId
            };

            _dataContext.Users.Add(user);
            _dataContext.SaveChanges();

            response.SetSuccess();
            return response;
        }


        private UserDto GetUserByUsername(string email)
        {


            var user = _dataContext.Users.Include(x=>x.Role).FirstOrDefault(m => m.Email == email);
                

            if (user == null)
                return null;

            var dto = new UserDto()
            {
                Id = user.Id,
                Name = user.Name,
                Password = user.Password,
                Email= user.Email,
                Adress= user.Adress,
                RoleId= user.RoleId,
                Role=new RoleDto() 
                { 
                    Id=user.RoleId,
                    RoleName=user.Role.RoleName,
                }
                
            };

            return dto;

        }
    }
}
