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
    public class GradController : ControllerBase
    {
        public RezervacijaKarataContext Context { get; set; }
        public GradController(RezervacijaKarataContext context)
        {
             this.Context = context;
        }

        [Route("DodajGrad")]
        [HttpPost]
        public async Task<IActionResult>DodajGrad([FromBody] Grad grad)
        {
            if (Context.Gradovi.Any(o => o.Ime == grad.Ime)) 
                return StatusCode(400,"Grad vec postoji.");

            Context.Gradovi.Add(grad);
            await Context.SaveChangesAsync();
            return StatusCode(200,"Grad je dodat.");

        }

        [Route("VratiGradove")]
        [HttpGet]
        public async Task<IActionResult> VratiGradove()
        {
            List<Grad> gradovi = Context.Gradovi.ToList();
            return Ok(gradovi);
        }

        [Route("ObrisiGradove")]
        [HttpDelete]
        public async Task<IActionResult>ObrisiGradove()
        {
            foreach (var sala in Context.Sale){
                Context.Sale.Remove(sala);
            }
            foreach (var grad in Context.Gradovi){
                Context.Gradovi.Remove(grad);
            }
            await Context.SaveChangesAsync();
            return StatusCode(200,"Svi gradovi su obrisani.");
        }
    }
}
