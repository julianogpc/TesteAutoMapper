namespace TesteAutoMapper.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Funcionario",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 30, storeType: "nvarchar"),
                        DataNascimento = c.DateTime(nullable: false, precision: 0),
                        Usuario_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Usuario", t => t.Usuario_Id, cascadeDelete: true)
                .Index(t => t.Usuario_Id);
            
            CreateTable(
                "dbo.Usuario",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NomeUsuario = c.String(nullable: false, maxLength: 15, storeType: "nvarchar"),
                        Senha = c.String(nullable: false, maxLength: 50, storeType: "nvarchar"),
                        Ativo = c.Boolean(nullable: false),
                        DataCricao = c.DateTime(nullable: false, precision: 0),
                        UsuarioCriacao = c.String(nullable: false, maxLength: 15, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Funcionario", "Usuario_Id", "dbo.Usuario");
            DropIndex("dbo.Funcionario", new[] { "Usuario_Id" });
            DropTable("dbo.Usuario");
            DropTable("dbo.Funcionario");
        }
    }
}
