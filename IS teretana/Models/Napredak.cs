using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISTeretana.Models
{
    public class Napredak
    {
        [Key]
        public int ID { get; set; }

        
        [ForeignKey("PlanTreninga")]
        public int PlanTreningaID { get; set; }

        public DateTime Datum { get; set; }

        public string Opis { get; set; }

        public PlanTreninga PlanTreninga { get; set; }

        public Napredak() { }
    }
}
