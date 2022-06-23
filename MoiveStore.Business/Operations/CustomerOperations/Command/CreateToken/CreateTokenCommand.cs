using AutoMapper;
using Microsoft.Extensions.Configuration;
using MovieStore.Core.Entities;
using MovieStore.Core.Utilities.Security.JWT.TokenOperations;
using MovieStore.DataAccess.Abstract;
using MovieStore.Entities.Entities;
using MovieStore.Entities.ViewModel.CustomerViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Business.Operations.CustomerOperations.Command.CreateToken
{
    public class CreateTokenCommand
    {
        public CreateTokenViewModel Model { get; set; }

        private readonly IMovieStoreDb _db;
        readonly IConfiguration _config;

        public CreateTokenCommand(IMovieStoreDb db, IConfiguration config)
        {
            _db = db;
            _config = config;
        }

        public Token Handler()
        {
            Customer customer = _db.Customers.SingleOrDefault(x => x.Email == Model.Email && x.Password == Model.Password);
            if (customer != null)
            {
                TokenHandler handler = new TokenHandler(_config);

                Token token = handler.CreateAccessToken(customer);
                customer.RefreshToken = token.RefleshToken;
                customer.RefreshTokenExpireDate = token.Expiration.AddMinutes(5);

                _db.SaveChanges();
                return token;
            }
            else
                throw new InvalidOperationException("Kulanıcı Adı veya Şifre Hatalı");
        }
    }
}
