namespace MonsterMaker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MonsterJSON : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Monsters", "monsterJSONData", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Monsters", "monsterJSONData");
        }
    }
}
