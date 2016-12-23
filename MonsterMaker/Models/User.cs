using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MonsterMaker.Models
{
    public class Maker
    {
        [Key]
        public int UserId { get; set; }
        public string UserName { get; set; }
        //public virtual List<Monster> {get;set;}

    }
}