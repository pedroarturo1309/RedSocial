namespace RedSocial.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.megustas", "Estado", c => c.Boolean(nullable: false));
            AddColumn("dbo.megustas", "FechaMegusta", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.megustas", "FechaMegusta");
            DropColumn("dbo.megustas", "Estado");
        }
    }
}
