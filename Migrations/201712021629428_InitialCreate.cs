namespace RedSocial.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Amigos",
                c => new
                    {
                        idAmigos = c.Int(nullable: false, identity: true),
                        idUsuarioYO = c.Int(),
                        idUsuario = c.Int(),
                    })
                .PrimaryKey(t => t.idAmigos);
            
            CreateTable(
                "dbo.publicaciones",
                c => new
                    {
                        idPubli = c.Int(nullable: false, identity: true),
                        idUsuario = c.Int(),
                        Descripcion = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.idPubli);
            
            CreateTable(
                "dbo.RedSocial_Roles",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 20),
                        Descripcion = c.String(nullable: false),
                        Titulo = c.String(nullable: false, maxLength: 100),
                        Estado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.RedSocial_RolesUsuarios",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        RolID = c.Int(nullable: false),
                        UsuarioID = c.Int(nullable: false),
                        Estado = c.Boolean(nullable: false),
                        RedSocial_Roles_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.RedSocial_Roles", t => t.RedSocial_Roles_ID)
                .Index(t => t.RedSocial_Roles_ID);
            
            CreateTable(
                "dbo.Usuario",
                c => new
                    {
                        idUsuario = c.Int(nullable: false, identity: true),
                        Correo = c.String(maxLength: 25, unicode: false),
                        Nombre = c.String(maxLength: 25, unicode: false),
                        Contraseña = c.String(maxLength: 50, unicode: false),
                        Apellido = c.String(maxLength: 25, unicode: false),
                        email = c.String(maxLength: 20, unicode: false),
                        fechaDeNacimiento = c.DateTime(storeType: "date"),
                        URLfoto = c.String(maxLength: 20, unicode: false),
                    })
                .PrimaryKey(t => t.idUsuario);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RedSocial_RolesUsuarios", "RedSocial_Roles_ID", "dbo.RedSocial_Roles");
            DropIndex("dbo.RedSocial_RolesUsuarios", new[] { "RedSocial_Roles_ID" });
            DropTable("dbo.Usuario");
            DropTable("dbo.RedSocial_RolesUsuarios");
            DropTable("dbo.RedSocial_Roles");
            DropTable("dbo.publicaciones");
            DropTable("dbo.Amigos");
        }
    }
}
