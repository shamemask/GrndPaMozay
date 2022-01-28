using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GrndPaMozay.Models;
using System.Text.Json;

namespace GrndPaMozay
{
    [Route("api/[controller]")]
    [ApiController]
    public class RabbitsController : ControllerBase
    {
        private readonly Catching _context;

        public RabbitsController(Catching context)
        {
            _context = context;
        }

        // GET: api/Rabbits
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Rabbit>>> GetRabbits()
        {


            return await _context.Rabbit.ToListAsync();

        }

       

        // GET: api/Rabbits/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Rabbit>> GetRabbit(long id)
        {
            var rabbit = await _context.Rabbit.FindAsync(id);

            if (rabbit == null)
            {
                return NotFound();
            }

            return rabbit;
        }

        
        class  sortByColor: IComparer<Rabbit>
        {
            public int Compare(Rabbit? r1, Rabbit? r2)
            {
                if (r1 is null || r2 is null)
                    throw new ArgumentException("Некорректное значение параметра");

                if (r1.color.ToLower() == "white" && r2.color.ToLower() != "white")
                {
                    return -1;
                }
                else if (r1.color.ToLower() != "white" && r2.color.ToLower() == "white")
                {
                    return 1;
                }
                
                return 0;

            }
            
        }

        class sortByFatness : IComparer<Rabbit>
        {
            public int Compare(Rabbit? r1, Rabbit? r2)
            {
                if (r1 is null || r2 is null)
                    throw new ArgumentException("Некорректное значение параметра");
                return (int)(r2.fatnessKG - r1.fatnessKG);

            }

        }

        

    // POST: api/Rabbits
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
        public async Task<JsonDocument> PostRabbits(Rabbits rabbits)
        {


            
            Array.Sort(rabbits.rabbits, new sortByFatness());
            Array.Sort(rabbits.rabbits, new sortByColor());

            
            foreach (var rabbit in rabbits.rabbits)
            { 
                _context.Rabbit.Add(rabbit);
            }
                
            var rabbitJson = JsonSerializer.SerializeToDocument<Rabbits>(rabbits);

            await _context.SaveChangesAsync();
            return rabbitJson;
        }

        // DELETE: api/Rabbits/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRabbits(long id)
        {
            var rabbits = await _context.Rabbits.FindAsync(id);
            if (rabbits == null)
            {
                return NotFound();
            }

            _context.Rabbits.Remove(rabbits);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RabbitsExists(long id)
        {
            return _context.Rabbit.Any(e => e.Id == id);
        }
    }
}
