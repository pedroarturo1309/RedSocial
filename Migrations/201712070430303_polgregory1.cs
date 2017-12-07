namespace RedSocial.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class polgregory1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Usuario", "Correo", c => c.String(maxLength: 50, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Usuario", "Correo", c => c.String(maxLength: 25, unicode: false));
        }
    }
}
