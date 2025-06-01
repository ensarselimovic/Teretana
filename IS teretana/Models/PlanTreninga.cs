using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISTeretana.Models
{
    public class PlanTreninga
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Naziv { get; set; }

        public string Opis { get; set; }

        [ForeignKey("Clan")]
        public int ClanID { get; set; }

       
        [ForeignKey("Trener")]
        public int TrenerID { get; set; }

        [ForeignKey("Teretana")]
        public int TeretanaID { get; set; }

        public Clan? Clan { get; set; }
        public Trener? Trener { get; set; }
        public Teretana? Teretana { get; set; }

        public PlanTreninga() { }
    }
}
