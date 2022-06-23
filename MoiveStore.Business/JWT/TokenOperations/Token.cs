using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Core.Utilities.Security.JWT.TokenOperations
{
    public class Token
    {
        public string AccessToken { get; set; }

        public string RefleshToken { get; set; }

        public DateTime Expiration { get; set; }
    }
}
