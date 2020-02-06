using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RedDragon.DomainValidator;
using RedDragon.Extensions;

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

    }

}
