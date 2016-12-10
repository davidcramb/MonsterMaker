using System.ComponentModel.DataAnnotations;

namespace MonsterMaker.Models
{
    public class Leg
    {
        [Key]
        public int LegId { get; set; }
        public string LegType { get; set; }
        public string ImageURL { get; set; }
        public int StatBonus { get; set; }
    }
}