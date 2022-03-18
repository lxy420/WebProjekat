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
    public class SalaController : ControllerBase
    {
        public RezervacijaKarataContext Context { get; set; }
        public SalaController(RezervacijaKarataContext context)
        {
             this.Context = context;
        }

        [Route("DodajSalu/{id}")]
        [HttpPost]
        public async Task<IActionResult>DodajSalu(int id,[FromBody] Sala sala)
        {
            Grad grad = Context.Gradovi.Find(id);
            Context.Entry(grad).Collection(s=>s.Sala).Load();
            if(grad.Sala==null)
                grad.Sala=new List<Sala>();
            grad.Sala.Add(sala);
            sala.Grad = grad;
            Context.Sale.Add(sala);
            await Context.SaveChangesAsync();
            return StatusCode(200,"Sala je dodata.");
        }

        [Route("VratiSale/{id}")]
        [HttpGet]
        public async Task<IActionResult> VratiSale(int id)
        {
            Grad grad = Context.Gradovi.Find(id);
            List<Sala> sale = Context.Sale.Where(s=>s.Grad.Id==id).ToList();
            return Ok(sale);
        }

        [Route("ObrisiSale")]
        [HttpDelete]
        public async Task<IActionResult>ObrisiSale()
        {
            foreach (var item in Context.Sale){
                Context.Sale.Remove(item);
            }
            await Context.SaveChangesAsync();
            return StatusCode(200,"Sve sale su obrisane.");
        }
    }
}
