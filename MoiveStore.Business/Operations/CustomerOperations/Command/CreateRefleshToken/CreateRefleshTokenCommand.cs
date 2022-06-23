using Microsoft.Extensions.Configuration;
using MovieStore.Core.Entities;
using MovieStore.Core.Utilities.Security.JWT.TokenOperations;
using MovieStore.DataAccess.Abstract;
using MovieStore.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Business.Operations.CustomerOperations.Command.CreateRefleshToken
{
    public  class CreateRefleshTokenCommand
    {
        public string RefleshToken { get; set; }
        private readonly IMovieStoreDb _db;
        private readonly IConfiguration _config;

        public CreateRefleshTokenCommand(IMovieStoreDb db, IConfiguration config)
        {
            _db = db;
            _config = config;
        }

        public Token Handler()
        {
            Customer customer = _db.Customers.FirstOrDefault(x => x.RefreshToken == RefleshToken && x.RefreshTokenExpireDate > DateTime.Now);
            if (customer != null)
            {
                TokenHandler handler = new TokenHandler(_config);
                Token token = handler.CreateAccessToken(customer);

                customer.RefreshToken = token.RefleshToken;
                customer.RefreshTokenExpireDate = token.Expiration.AddMinutes(5);

                return token;
            }
            else
                throw new InvalidOperationException("Valid Bir Reflesh Token Bulunamdı");
        }
    }
}
