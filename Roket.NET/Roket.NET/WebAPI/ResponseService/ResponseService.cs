using Roket.NET.Models.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace Roket.NET.WebAPI.ResponseService
{
    public class ResponseService : IResponseService
    {
        private readonly HttpStatusCode[] errorCodeBlacklist = new HttpStatusCode[]
        {
            HttpStatusCode.OK,
            HttpStatusCode.Created,
            HttpStatusCode.Accepted,
            HttpStatusCode.NonAuthoritativeInformation,
            HttpStatusCode.NoContent,
            HttpStatusCode.ResetContent,
            HttpStatusCode.PartialContent,
            HttpStatusCode.NotFound,
        };

        public ResultResponse<T> Create<T>(T data, DateTime requestAt, string requestToken = null)
        {
            return new ResultResponse<T>
            {
                ApiInfo = new ApiConfig()
                {
                   
                },

                Data = data,

            };
        }

        public ErrorResponse Error(HttpStatusCode statusCode, string message, Exception exception = null)
        {
            if (errorCodeBlacklist.Contains(statusCode))
                throw new ArgumentException("Cannot make 20x status code as error");

            if (message == default || message == string.Empty)
                throw new ArgumentException("Message is required");

            ErrorResponse error = new ErrorResponse
            {
                Code = (int)statusCode,
                Message = message,
            };

            if (exception != null)
            {
                StringBuilder stringBuilder = new StringBuilder();
                while (exception != null)
                {
                    stringBuilder.Append(exception.Message);
                    exception = exception.InnerException;
                }

                // Get the error
                error.Details = stringBuilder.ToString();
            }

            return error;
        }

        public ListResultResponse<IEnumerable<T>> Page<T>(IEnumerable<T> data, int dataPerPage, int page, DateTime requestAt, string requestToken = null)
        {
            throw new NotImplementedException();
        }
    }
}
