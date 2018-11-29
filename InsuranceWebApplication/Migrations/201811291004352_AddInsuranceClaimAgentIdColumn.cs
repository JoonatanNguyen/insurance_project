namespace InsuranceWebApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddInsuranceClaimAgentIdColumn : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.InsuranceClaims", "UserId", "dbo.AspNetUsers");
            AddColumn("dbo.InsuranceClaims", "AgentId", c => c.String(maxLength: 128));
            AddColumn("dbo.InsuranceClaims", "ApplicationUser_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.InsuranceClaims", "AgentId");
            CreateIndex("dbo.InsuranceClaims", "ApplicationUser_Id");
            AddForeignKey("dbo.InsuranceClaims", "AgentId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.InsuranceClaims", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.InsuranceClaims", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.InsuranceClaims", "AgentId", "dbo.AspNetUsers");
            DropIndex("dbo.InsuranceClaims", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.InsuranceClaims", new[] { "AgentId" });
            DropColumn("dbo.InsuranceClaims", "ApplicationUser_Id");
            DropColumn("dbo.InsuranceClaims", "AgentId");
            AddForeignKey("dbo.InsuranceClaims", "UserId", "dbo.AspNetUsers", "Id");
        }
    }
}
