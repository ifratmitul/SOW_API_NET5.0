using System;

namespace API.Error
{
    public class ApiResponse
    {
        public ApiResponse(int statusCode, string message = null)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessage(statusCode);
        }



        public int StatusCode { get; set; }
        public string Message { get; set; }


        private string GetDefaultMessage(int statusCode)
        {
            return statusCode switch
            {
                400 => "Bad Request you have made",
                401 => "You are not Authorized",
                404 => "Item not Found",
                500 => "Seeing this error, our players might shitt themselves",
                _ => null

            };

        }
    }
}