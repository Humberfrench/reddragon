using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RedDragon.Web.Model
{
    public class PessoaRoot
    {
        public List<Pessoa> Pessoas { get; set; } = new List<Pessoa>();
    }
}
