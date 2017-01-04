using System.ComponentModel.DataAnnotations;

namespace MonsterMaker.Models
{
    public class TempMonster
    {
        [Key]
        public string MonsterId { get; set; }
        [Required]
        public string MonsterName { get; set; }
        //public virtual string BodyType { get; set; }
        public virtual string BodyId { get; set; }
        //public virtual string HeadType { get; set; }
        public virtual string HeadId { get; set; }
        //public virtual string ArmType { get; set; }
        public virtual string ArmId { get; set; }
        //public virtual string LegType { get; set; }
        public virtual string LegId { get; set; }
        //public virtual string AccessoryType { get; set; }
        public virtual string AccessoryId { get; set; }
        public virtual string canvasData { get; set; }
        //public int Stats {get;set;}
        //public virtual List Battles
        //[Required]
        public virtual string MakerId { get; set; }
    }
}