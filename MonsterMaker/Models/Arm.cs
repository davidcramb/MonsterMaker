using System.ComponentModel.DataAnnotations;

namespace MonsterMaker.Models
{
    public class Arm
    {
        [Key]
        [Required]
        public int ArmId { get; set; }
        public string ArmType { get; set; }
        public string ImageURL { get; set; }
        public int StatBonus { get; set; }
    }
}