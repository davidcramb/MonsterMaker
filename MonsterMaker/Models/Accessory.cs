using System.ComponentModel.DataAnnotations;

namespace MonsterMaker.Models
{
    public class Accessory
    {
        [Key]
        public int AccessoryId { get; set; }
        public string AccessoryType { get; set; }
        public string ImageURL { get; set; }
        public int StatBonus { get; set; }
    }
}