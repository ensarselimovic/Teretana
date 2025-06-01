using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISTeretana.Models
{
    public class Izvjestaj
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public DateTime Datum { get; set; }

        public string Opis { get; set; }

        
        [ForeignKey("Admin")]
        public int AdminID { get; set; }

        public Admin Admin { get; set; }

        public Izvjestaj() { }
    }
}
