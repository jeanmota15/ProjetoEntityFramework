namespace ProjetoDDDMota2.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdicionaLogin : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Login",
                c => new
                    {
                        LoginId = c.Int(nullable: false, identity: true),
                        Usuario = c.String(nullable: false, maxLength: 150, unicode: false),
                        Senha = c.String(nullable: false, maxLength: 150, unicode: false),
                    })
                .PrimaryKey(t => t.LoginId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Login");
        }
    }
}
