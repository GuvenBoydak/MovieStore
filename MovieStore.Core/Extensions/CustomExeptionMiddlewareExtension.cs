using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Core.Extensions
{
    public static class CustomExeptionMiddlewareExtension
    {
        public static IApplicationBuilder UseCustomeExeption(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomeExeptionMiddleware>();
        }
    }
}
