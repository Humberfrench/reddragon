using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RedDragon.Web.Model
{
    public class Location
    {
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Postcode { get; set; }
        public Coordinates Coordinates { get; set; }
        public Timezone Timezone { get; set; }
    }
}
}
