using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISTeretana.Models
{
    public class Poruka
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Sadrzaj { get; set; }

        public DateTime DatumSlanja { get; set; }

       
        [ForeignKey("Trener")]
        public int PosiljalacID { get; set; }

        [ForeignKey("Clan")]
        public int PrimalacID { get; set; }

        public Trener Posiljalac { get; set; }

        public Clan Primalac { get; set; }


        public Poruka() { }
    }
}
