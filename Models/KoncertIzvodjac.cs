using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class KoncertIzvodjac
    {
        [Key]
        public int Id {get;set;}
        
        public int KoncertId {get;set;}
        public Koncert Koncert {get;set;}
        public int IzvodjacId {get;set;}
        public Izvodjac Izvodjac {get;set;}
       
    }

}