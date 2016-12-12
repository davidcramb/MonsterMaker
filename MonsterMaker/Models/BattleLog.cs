using System.ComponentModel.DataAnnotations;

namespace MonsterMaker.Models
{
    public class BattleLog
    {
        [Key]
        public int BattleId { get; set; }
    }
}