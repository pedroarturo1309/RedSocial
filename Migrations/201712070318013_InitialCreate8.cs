namespace RedSocial.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate8 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.megustas", "idPubli");
            AddForeignKey("dbo.megustas", "idPubli", "dbo.publicaciones", "idPubli", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.megustas", "idPubli", "dbo.publicaciones");
            DropIndex("dbo.megustas", new[] { "idPubli" });
        }
    }
}
