using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISTeretana.Models
{
    public class PovratnaInformacija
    {
        [Key]
        public int ID { get; set; }

        public Ocjena Ocjena { get; set; }

        public string Komentar { get; set; }

        public DateTime DatumVrijeme { get; set; }

        
        [ForeignKey("PlanTreninga")]
        public int PlanTreningaID{ get; set; }

        public PovratnaInformacija() { }
    }
}
