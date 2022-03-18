using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Models
{
    [Table("Sala")]
    public class Sala
    {
        [Key]
        public int Id {get;set;}
        
        [Required]
        [MaxLength(30)]
        public string Ime {get;set;}

        [Required]
        [Range(1,2000)]
        public int Kapacitet {get;set;}
     
        //[Required]
        [JsonIgnore]
        public Grad Grad {get;set;}

       // [Required]
        [JsonIgnore]
        public List<Koncert> Koncert {get;set;}
    }

}