namespace RedSocial.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate4 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.megustas",
                c => new
                    {
                        megustaID = c.Int(nullable: false, identity: true),
                        idUsuario = c.Int(nullable: false),
                        idPubli = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.megustaID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.megustas");
        }
    }
}
