namespace InsuranceWebApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class approved : DbMigration
    {
        public override void Up()
        {        
            AddColumn("dbo.InsuranceClaims", "EvaluateClaim", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.InsuranceClaims", "EvaluateClaim");
          
        }
    }
}
