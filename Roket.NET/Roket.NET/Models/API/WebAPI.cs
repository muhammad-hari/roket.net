using RestSharp;
using System;

namespace Roket.NET.Models.API
{
    public class WebAPI
    {
        public IRestClient Client { get; set; }
        public IRestRequest Request { get; set; }
    }
}
