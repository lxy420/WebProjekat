using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models;

namespace web_projekat.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class KoncertController : ControllerBase
    {
        public RezervacijaKarataContext Context { get; set; }
        public KoncertController(RezervacijaKarataContext context)
        {
             this.Context = context;
        }

        [Route("DodajKoncert/{id}")]
        [HttpPost]
        public async Task<IActionResult>DodajKoncert(int id,[FromBody] Koncert koncert)
        {
            if (Context.Koncerti.Any(o => o.Ime == koncert.Ime)) 
                return StatusCode(400,"Koncert vec postoji.");

            Sala sala = Context.Sale.Find(id);
            Context.Entry(sala).Collection(s=>s.Koncert).Load();
            if(sala.Koncert==null)
                sala.Koncert=new List<Koncert>();
            sala.Koncert.Add(koncert);
            koncert.Sala = sala;
            Context.Koncerti.Add(koncert);
            await Context.SaveChangesAsync();
            return StatusCode(200,"Koncert je dodat.");
        }
        [Route("VratiKoncerte")]
        [HttpGet]
        public async Task<IActionResult> VratiKoncerte()
        {
            List<Koncert> koncert = Context.Koncerti.ToList();
            return Ok(koncert);
        }
         [Route("ucitajIzabraniKoncert/{id}")]
        [HttpGet]
        public async Task<IActionResult> ucitajIzabraniKoncert(int id)
        {
            Koncert koncert = Context.Koncerti.Find(id);
            Sala sala=Context.Sale.Find(koncert.SalaId);
            //izvodjaci
            return Ok(sala);
        }
        
        [Route("ObrisiKoncerte")]
        [HttpDelete]
        public async Task<IActionResult>ObrisiKoncerte()
        {
            foreach (var item in Context.Koncerti){
                Context.Koncerti.Remove(item);
            }
            await Context.SaveChangesAsync();
            return StatusCode(200,"Svi koncerti su obrisani.");
        }
    }
}
