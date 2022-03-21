using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Models
{
    [Table("Rezervacija")]
    public class Rezervacija
    {
        [Key]
        public int Id {get;set;}
        
        public int KoncertId {get;set;}

        public string Telefon  {get;set;}

        public int Sediste  {get;set;}

    }

}