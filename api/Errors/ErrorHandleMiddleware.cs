using System.Net;
using System.Text.Json;

namespace api.Errors
{
    public class ErrorHandleMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandleMiddleware(RequestDelegate next){
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try{
                await _next(context);
            }
            catch(Exception error){
                var response = context.Response;
                response.ContentType = "application/json";

                switch(error)
                {
                    case AppException e:
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        break;
                    case KeyNotFoundException e:
                        response.StatusCode = (int)HttpStatusCode.NotFound;
                        break;
                    default:
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        break;
                }


                var result = JsonSerializer.Serialize(new {message = error?.Message });

                await response.WriteAsync(result);
            }    
        }
    }
}