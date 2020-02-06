using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RedDragon.Application.Interface;
using RedDragon.Application.ViewModel;
using RedDragon.DomainValidator;

namespace RedDragon.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AviaoController : BaseController
    {
        private readonly IAviaoServiceApp aviaoServiceApp;
        public AviaoController(IAviaoServiceApp aviaoServiceApp)
        {
            this.aviaoServiceApp = aviaoServiceApp;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status406NotAcceptable)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet()]
        public ActionResult<IEnumerable<AviaoViewModel>> ObterTodos()
        {
            var retorno = aviaoServiceApp.ObterTodos();
            return ReturnHttpResponseMessage(retorno);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status406NotAcceptable)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("Filtrar/{query}")]
        public ActionResult<IEnumerable<AviaoViewModel>> Filtrar(string query)
        {
            var retorno = aviaoServiceApp.Filtrar(query);
            return ReturnHttpResponseMessage(retorno);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status406NotAcceptable)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost()]
        public ActionResult<ValidationResult> Gravar(AviaoViewModel aviao)
        {
            var retorno = aviaoServiceApp.Gravar(aviao);
            return ReturnHttpResponseMessage(retorno);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status406NotAcceptable)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost("{id}")]
        public ActionResult<ValidationResult> Excluir(int id)
        {
            var retorno = aviaoServiceApp.Excluir(id);
            return ReturnHttpResponseMessage(retorno);

        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status406NotAcceptable)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("{id}")]
        public ActionResult<AviaoViewModel> ObterPorId(int id)
        {
            var retorno = aviaoServiceApp.ObterPorId(id);
            return ReturnHttpResponseMessage(retorno);

        }

    }
}