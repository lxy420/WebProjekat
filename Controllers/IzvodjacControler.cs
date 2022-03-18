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
    public class IzvodjacController : ControllerBase
    {
        public RezervacijaKarataContext Context { get; set; }
        public IzvodjacController(RezervacijaKarataContext context)
        {
             this.Context = context;
        }

        [Route("DodajIzvodjaca")]
        [HttpPost]
        public async Task<IActionResult>DodajIzvodjaca([FromBody] Izvodjac izvodjac)
        {
            if (Context.Izvodjaci.Any(o => o.Ime == izvodjac.Ime && o.Prezime == izvodjac.Prezime)) 
                return StatusCode(400,"Izvodjac vec postoji.");

            Context.Izvodjaci.Add(izvodjac);
            await Context.SaveChangesAsync();
            return StatusCode(200,"Izvodjac je dodat.");
        }

        [Route("VratiIzvodjace")]
        [HttpGet]
        public async Task<IActionResult> VratiIzvodjace()
        {
            List<Izvodjac> izvodjac = Context.Izvodjaci.ToList();
            return Ok(izvodjac);
        }


        [Route("ObrisiIzvodjace")]
        [HttpDelete]
        public async Task<IActionResult>ObrisiIzvodjace()
        {
            foreach (var item in Context.Izvodjaci){
                Context.Izvodjaci.Remove(item);
            }
            await Context.SaveChangesAsync();
            return StatusCode(200,"Svi izvodjaci su obrisani.");
        }
    }
}
