namespace Oficina_codeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class alteracaoAtendimento : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Atendimentos", "Codigo", c => c.String());
            AlterColumn("dbo.Atendimentos", "DataFim", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Atendimentos", "DataFim", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Atendimentos", "Codigo", c => c.String(nullable: false));
        }
    }
}
