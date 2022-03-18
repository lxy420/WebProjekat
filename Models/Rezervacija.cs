using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    [Table("Rezervacija")]
    public class Rezervacija
    {
        [Key]
        public int Id {get;set;}
        
        [Required]
        public Koncert Koncert {get;set;}
    
        public string Telefon  {get;set;}

        public int Sediste  {get;set;}

    }

}