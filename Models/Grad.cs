using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Models
{
    [Table("Grad")]
    public class Grad
    {
        public Grad(){}

        [Key]
        public int Id {get;set;}
        
        [Required]
        [MaxLength(30)]
        public string Ime {get;set;}

        //[Required]
        [JsonIgnore]
        public List<Sala> Sala {get;set;}
    }

}