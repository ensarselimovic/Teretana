using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISTeretana.Models
{
    public class Admin
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Ime { get; set; }

        [Required]
        [MaxLength(50)]
        public string Prezime { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]

        public DateTime DatumZaposlenja { get; set; }

        public Admin() { }
    }
}
