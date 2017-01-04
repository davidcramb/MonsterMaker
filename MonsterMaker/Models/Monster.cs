using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MonsterMaker.Models
{
    public class Monster
    {
        [Key]
        public int MonsterId { get; set; }
        [Required]
        public string MonsterName { get; set; }
        public int BodyId { get; set; }
        [ForeignKey("BodyId")]
        public virtual Body BodyType { get; set; }
        public int HeadId { get; set; }
        [ForeignKey("HeadId")]
        public virtual Head HeadType { get; set; }
        public int ArmId { get; set; }
        [ForeignKey("ArmId")]
        public virtual Arm ArmType { get; set; }
        public int LegId { get; set; }
        [ForeignKey("LegId")]
        public virtual Leg LegType { get; set; }
        public int AccessoryId { get; set; }
        [ForeignKey("AccessoryId")]
        public virtual Accessory AccessoryType { get; set; }

        public string canvasData { get; set; }
        //public int Stats {get;set;}
        //public virtual List Battles
        //[Required]
        public int MakerId { get; set; }
        [ForeignKey("MakerId")]
        public virtual Maker MakerName { get; set; }
    }
}