using System.Collections.Generic;
using System.IO;
using System.Net;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RedDragon.Web.Model;

namespace RedDragon.Web.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ExternalDataController : BaseController
    {
        private IWebHostEnvironment env;
        public ExternalDataController(IWebHostEnvironment env)
        {
            this.env = env;
        }


        [HttpGet("ObterPessoas")]
        public IList<Pessoa> ObterPessoas()
        {
            var fileJsonString = System.IO.File.ReadAllText( $"{env.WebRootPath}/App_Data/input-frontend-apps.json", System.Text.Encoding.Default);

            var pessoaRoot = JsonConvert.DeserializeObject<PessoaRoot>(fileJsonString);

            return pessoaRoot.Pessoas;

        }
    }
}