using System.ComponentModel.DataAnnotations;

namespace MonsterMaker.Models
{
    public class BattleLog
    {
        [Key]
        public int BattleId { get; set; }
        public virtual Maker User1 { get; set; }
        public virtual Maker User2 { get; set; }
        public virtual Monster Monster1 { get; set; }
        public virtual Monster Monster2 { get; set; }
        public virtual Monster Winner { get; set; }
    }
}