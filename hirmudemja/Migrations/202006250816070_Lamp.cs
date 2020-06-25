namespace hirmudemja.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Lamp : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.hirmudemajas", "Sisenes", c => c.Int(nullable: false));
            AlterColumn("dbo.hirmudemajas", "Lahkus", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.hirmudemajas", "Lahkus", c => c.Boolean(nullable: false));
            AlterColumn("dbo.hirmudemajas", "Sisenes", c => c.Boolean(nullable: false));
        }
    }
}
