using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrndPaMozay.Models
{
    public class Rabbit
    {

        public long Id { get; set; }

        public float fatnessKG { get; set; }
        public string color { get; set; }

        public Rabbit()
        {

        }
        public Rabbit(float fnKG, string clr)
        {
            fatnessKG = fnKG;

            color = clr;

        }
    }
    
}
