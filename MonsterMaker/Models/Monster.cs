using System.ComponentModel.DataAnnotations;

namespace MonsterMaker.Models
{
    public class Monster
    {
        [Key]
        public int MonsterId { get; set; }
        [Required]
        public string MonsterName { get; set; }
        public virtual Body BodyType { get; set; }
        public virtual Body BodyId { get; set; }
        public virtual Head HeadType { get; set; }
        public virtual Head HeadId { get; set; }
        public virtual Arm ArmType { get; set; }
        public virtual Arm ArmId { get; set; }
        public virtual Leg LegType { get; set; }
        public virtual Leg LegId { get; set; }
        public virtual Accessory AccessoryType { get; set; }
        public virtual Accessory AccessoryId { get; set; }

        //public int Stats {get;set;}
        //public virtual List Battles
        //[Required]
        public virtual User UserId { get; set; }
    }
}