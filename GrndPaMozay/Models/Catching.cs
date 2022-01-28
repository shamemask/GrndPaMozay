using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace GrndPaMozay.Models
{
    public class Catching: DbContext
    {
        public Catching(DbContextOptions<Catching> options): base(options)
        {


        }

        public DbSet<Rabbits> Rabbits { get; set; }
        public DbSet<Rabbit> Rabbit { get; set; }
    }
}

