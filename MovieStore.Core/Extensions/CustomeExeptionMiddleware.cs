using MovieStore.Core.CrossCuttingConcerns.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace MovieStore.Core.Extensions
{
    public class CustomeExeptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILoggerService _logger;

        public CustomeExeptionMiddleware(RequestDelegate next, ILoggerService logger)
        {
            _next = next;
            _logger = logger;
        }


        public async Task Invoke(HttpContext context)
        {
            Stopwatch watch=Stopwatch.StartNew();

            try
            {
                string message = "[Request] " + " HTTP " + context.Request.Method + " - " + context.Request.Path;
                _logger.Write(message);

                await _next(context);
                watch.Stop();

                message = "[Responce] " + " HTTP " + context.Request.Method + " - " + context.Request.Path + " Responced " + context.Response.StatusCode + " in " + watch.Elapsed.Milliseconds;
                _logger.Write(message);
            }
            catch (Exception ex)
            {

                watch.Stop();
                await HandleExeption(context, ex, watch);
            }
        }

        public Task HandleExeption(HttpContext context,Exception ex,Stopwatch watch)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            string message = "[Error]   HTTP " + context.Request.Method + " - " + context.Response.StatusCode + " Error Message " + ex.Message + " in " + watch.Elapsed.Milliseconds;
            _logger.Write(message);

            var result = JsonConvert.SerializeObject(new { error = ex.Message }, Formatting.None);

            return context.Response.WriteAsync(result);
        }

        
    }
}
