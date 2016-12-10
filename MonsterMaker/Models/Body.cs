using System.ComponentModel.DataAnnotations;

namespace MonsterMaker.Models
{
    public class Body
    {
        [Key]
        public int BodyId { get; set; }
        public string BodyType { get; set; }
        public string ImageURL { get; set; }
        public int StatBonus { get; set; }

    }
}