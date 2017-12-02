namespace RedSocial.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate1 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.publicaciones", "idUsuario");
            AddForeignKey("dbo.publicaciones", "idUsuario", "dbo.Usuario", "idUsuario");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.publicaciones", "idUsuario", "dbo.Usuario");
            DropIndex("dbo.publicaciones", new[] { "idUsuario" });
        }
    }
}
