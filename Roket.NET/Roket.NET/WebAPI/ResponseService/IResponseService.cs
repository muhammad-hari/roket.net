using System;
using System.Collections.Generic;
using System.Net;

namespace Roket.NET.WebAPI.ResponseService
{
    public interface IResponseService
    {
        ResultResponse<T> Create<T>(T data, DateTime requestAt, string requestToken = null);
        ListResultResponse<IEnumerable<T>> Page<T>(IEnumerable<T> data, int dataPerPage, int page, DateTime requestAt, string requestToken = null);
        ErrorResponse Error(HttpStatusCode statusCode, string message, Exception exception = null);
    }
}
