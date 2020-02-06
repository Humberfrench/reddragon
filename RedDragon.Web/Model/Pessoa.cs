using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RedDragon.Web.Model
{
    public class Pessoa
    {
        public string Gender { get; set; }
        public Name Name { get; set; }
        public Location Location { get; set; }
        public string Email { get; set; }
        public Dob Dob { get; set; }
        public Registered Registered { get; set; }
        public string Phone { get; set; }
        public string Cell { get; set; }
        public Picture Picture { get; set; }
    }
}
