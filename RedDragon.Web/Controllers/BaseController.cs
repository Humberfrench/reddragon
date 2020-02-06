using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RedDragon.DomainValidator;
using RedDragon.Extensions;
using RedDragon.Web.Rest;
using RestSharp;

namespace RedDragon.Web.Controllers
{
    public abstract class BaseController : ControllerBase
    {
        /// <summary>
        /// Retorno do método
        /// </summary>
        /// <param name="retorno">HttpResponseMessage</param>
        /// <returns></returns>
        protected ActionResult<ValidationResult> ReturnHttpResponseMessage(ValidationResult retorno)
        {
            if (!retorno.IsValid)
            {
                var status = retorno.StatusCode;
                if ((status != HttpStatusCode.Forbidden) || (status != HttpStatusCode.NotAcceptable))
                {
                    return this.BadRequest(retorno);
                }
                else if (status != HttpStatusCode.Forbidden) 
                {
                    return this.Forbid();
                }
                else if (status != HttpStatusCode.NotAcceptable)
                {
                    return this.Conflict();
                }

                this.StatusCode(status.Int(), retorno);
            }

            return Ok(retorno);

        }


        /// <summary>
        /// Retorno do método
        /// </summary>
        /// <typeparam name="T">Classe Genéroca</typeparam>
        /// <param name="retorno"></param>
        /// <returns>HttpResponseMessage</returns>
        protected ActionResult<T> ReturnHttpResponseMessage<T>(T retorno)
        {
            if (retorno == null)
            {
                return this.NoContent();
            }

            return this.Ok(retorno);
        }


        #region rest
        protected JsonSerializerSettings MicrosoftDateFormatSettings = new JsonSerializerSettings
        {
            DateFormatHandling = DateFormatHandling.MicrosoftDateFormat,
            DateTimeZoneHandling = DateTimeZoneHandling.Local
        };
        public string Endereco { get; set; }


        public RestClientDispose CriaRestClient()
        {
            var client = new RestClientDispose(Endereco);
            
            return client;
        }


        protected async Task<T> PostApiMethodAsync<T>(string uri, object model)
        {
            using (var restClient = CriaRestClient())
            {
                
                var request = new RestRequest(uri, Method.POST) { RequestFormat = DataFormat.Json };

                TaskCompletionSource<IRestResponse> taskCompletion = new TaskCompletionSource<IRestResponse>();
                                
                var handle = restClient.ExecuteAsync(request, r=> taskCompletion.SetResult(r));
                
                var response = (RestResponse)(await taskCompletion.Task); 

                var retorno = (T)Activator.CreateInstance(typeof(T));

                try
                {
                    retorno = JsonConvert.DeserializeObject<T>(response.Content);
                }
                catch (Exception)
                {

                }

                return retorno;
            }
        }

        protected async Task<T> GetApiMethodAsync<T>(string uri, Dictionary<string, object> parameters)
        {
            using (var restClient = CriaRestClient())
            {
                if (parameters != null && parameters.Count > 0)
                {
                    uri = parameters.Aggregate(uri, (current, item) => current + ("/" + item.Value));
                }

                uri += "/";

                var request = new RestRequest(uri, Method.GET);

                TaskCompletionSource<IRestResponse> taskCompletion = new TaskCompletionSource<IRestResponse>();

                var handle = restClient.ExecuteAsync(request, r => taskCompletion.SetResult(r));

                var response = (RestResponse)(await taskCompletion.Task);


                var retorno = (T)Activator.CreateInstance(typeof(T));
                try
                {
                    retorno = JsonConvert.DeserializeObject<T>(response.Content);
                }
                catch (Exception)
                {

                }

                return retorno;
            }
        }

        #endregion
    }

}
