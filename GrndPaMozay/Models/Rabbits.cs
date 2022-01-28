using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GrndPaMozay.Models;

namespace GrndPaMozay.Models
{
    
    public class Rabbits
    {

        public long Id { get; set; }
        public Rabbit[] rabbits { get; set; }
        

        public Rabbits()
        { }
        

    }
}