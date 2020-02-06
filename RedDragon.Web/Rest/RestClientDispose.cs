using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RedDragon.Web.Rest
{
    public class RestClientDispose : RestClient, IDisposable
    {
        public RestClientDispose(string enderecoBaseApi)
            : base(enderecoBaseApi)
        {

        }

        public void Dispose()
        {

        }
    }
