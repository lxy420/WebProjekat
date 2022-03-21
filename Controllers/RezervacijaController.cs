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
    public class RezervacijaController : ControllerBase
    {
        public RezervacijaKarataContext Context { get; set; }
        public RezervacijaController(RezervacijaKarataContext context)
        {
             this.Context = context;
        }

        [Route("DodajRezervaciju")]
        [HttpPost]
        public async Task<IActionResult>DodajRezervaciju([FromBody] Rezervacija rezervacija)
        {
            Context.Rezervacije.Add(rezervacija);
            await Context.SaveChangesAsync();
            return StatusCode(200,"Rezervacija uspesna.");
        }

        [Route("VratiZauzeta/{id}")]
        [HttpGet]
        public async Task<IActionResult>VratiZauzeta(int id)
        {
            return Ok(Context.Rezervacije.Where(x=>x.KoncertId==id).ToList());
        }
    }
}
