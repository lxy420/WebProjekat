using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace Models
{
    [Table("Izvodjac")]
    public class Izvodjac
    {
        [Key]
        public int Id {get;set;}
        
        [Required]
        [MaxLength(30)]
        public string Ime {get;set;}
        
        [Required]
        [MaxLength(30)]
        public string Prezime {get;set;}
        
        [MaxLength(20)]
        public string Instrument {get;set;}
        public List<KoncertIzvodjac> KoncertIzvodjac {get;set;}

    }

}