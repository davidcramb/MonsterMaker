using System.ComponentModel.DataAnnotations;

namespace MonsterMaker.Models
{
    public class Head
    {
        [Key]
        [Required]
        public int HeadId { get; set; }
        public string HeadType { get; set; }
        public string ImageURL { get; set; }
        public int StatBonus { get; set; }
    }
}