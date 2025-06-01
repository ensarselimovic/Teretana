using System;
using System.ComponentModel.DataAnnotations;
namespace ISTeretana.Models
{
    public class Teretana
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Naziv { get; set; }

        [Required]
        public string Adresa { get; set; }

        public string Kontakt { get; set; }

        public DateTime RadnoVrijeme { get; set; }


        public Teretana() { }
    }
}