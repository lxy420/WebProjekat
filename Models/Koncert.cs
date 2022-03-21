using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;
using System;

namespace Models
{
    [Table("Koncert")]
    public class Koncert
    {
        [Key]
        public int Id {get;set;}
        
        public int SalaId {get;set;}

        public int IzvodjacId {get;set;}


        [Required]
        [MaxLength(30)]
        public string Ime {get;set;}
     
        [JsonIgnore]        
        public Sala Sala {get;set;}
        [JsonIgnore]        
        public Izvodjac Izvodjac {get;set;}
        public DateTime Date { get;set; }
  
    }

}