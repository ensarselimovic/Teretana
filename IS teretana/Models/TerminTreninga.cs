using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISTeretana.Models
{
    public class TerminTreninga
    {
        [Key]
        public int ID { get; set; }

        public DateTime Datum { get; set; }

        public TimeSpan Vrijeme { get; set; }


        [ForeignKey("Teretana")]
        public int TeretanaID { get; set; }


        [ForeignKey("Trener")]
        public int TrenerID { get; set; }


        [ForeignKey("Clan")]
        public int ClanID { get; set; }

        public Teretana Teretana { get; set; }
        public Trener Trener { get; set; }
        public Clan Clan { get; set; }

        public TerminTreninga() { }
    }
}