namespace Oficina_codeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CriacaoInicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Atendimentos",
                c => new
                    {
                        Oid = c.Int(nullable: false, identity: true),
                        Codigo = c.String(nullable: false),
                        DataInicio = c.DateTime(nullable: false),
                        DataFim = c.DateTime(nullable: false),
                        CarroOid = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Oid)
                .ForeignKey("dbo.Carros", t => t.CarroOid, cascadeDelete: true)
                .Index(t => t.CarroOid);
            
            CreateTable(
                "dbo.Carros",
                c => new
                    {
                        Oid = c.Int(nullable: false, identity: true),
                        Placa = c.String(nullable: false),
                        Cor = c.String(),
                        Modelo = c.String(),
                        Marca = c.String(),
                        Ano = c.Int(nullable: false),
                        Quilometragem = c.Int(nullable: false),
                        ClienteOid = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Oid)
                .ForeignKey("dbo.Clientes", t => t.ClienteOid, cascadeDelete: true)
                .Index(t => t.ClienteOid);
            
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        Oid = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                        CPF = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Aniversario = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Oid);
            
            CreateTable(
                "dbo.Faturas",
                c => new
                    {
                        Oid = c.Int(nullable: false),
                        ValorRecebido = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TipoPagamento = c.String(),
                        parcelas = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Oid)
                .ForeignKey("dbo.Atendimentos", t => t.Oid)
                .Index(t => t.Oid);
            
            CreateTable(
                "dbo.Pecas",
                c => new
                    {
                        Oid = c.Int(nullable: false, identity: true),
                        Codigo = c.String(),
                        AtendimentoOid = c.Int(nullable: false),
                        TipoPecaOid = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Oid)
                .ForeignKey("dbo.Atendimentos", t => t.AtendimentoOid, cascadeDelete: true)
                .ForeignKey("dbo.TiposPeca", t => t.TipoPecaOid, cascadeDelete: true)
                .Index(t => t.AtendimentoOid)
                .Index(t => t.TipoPecaOid);
            
            CreateTable(
                "dbo.TiposPeca",
                c => new
                    {
                        Oid = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Quantidade = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Oid);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pecas", "TipoPecaOid", "dbo.TiposPeca");
            DropForeignKey("dbo.Pecas", "AtendimentoOid", "dbo.Atendimentos");
            DropForeignKey("dbo.Faturas", "Oid", "dbo.Atendimentos");
            DropForeignKey("dbo.Carros", "ClienteOid", "dbo.Clientes");
            DropForeignKey("dbo.Atendimentos", "CarroOid", "dbo.Carros");
            DropIndex("dbo.Pecas", new[] { "TipoPecaOid" });
            DropIndex("dbo.Pecas", new[] { "AtendimentoOid" });
            DropIndex("dbo.Faturas", new[] { "Oid" });
            DropIndex("dbo.Carros", new[] { "ClienteOid" });
            DropIndex("dbo.Atendimentos", new[] { "CarroOid" });
            DropTable("dbo.TiposPeca");
            DropTable("dbo.Pecas");
            DropTable("dbo.Faturas");
            DropTable("dbo.Clientes");
            DropTable("dbo.Carros");
            DropTable("dbo.Atendimentos");
        }
    }
}
