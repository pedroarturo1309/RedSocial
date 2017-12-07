namespace RedSocial.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate6 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.megustas", "idUsuario");
            AddForeignKey("dbo.megustas", "idUsuario", "dbo.Usuario", "idUsuario", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.megustas", "idUsuario", "dbo.Usuario");
            DropIndex("dbo.megustas", new[] { "idUsuario" });
        }
    }
}
