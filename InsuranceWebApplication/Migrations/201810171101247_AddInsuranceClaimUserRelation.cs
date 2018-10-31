namespace InsuranceWebApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddInsuranceClaimUserRelation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.InsuranceClaims", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.InsuranceClaims", "UserId");
            AddForeignKey("dbo.InsuranceClaims", "UserId", "dbo.AspNetUsers", "Id");
            DropColumn("dbo.InsuranceClaims", "Name");
            DropColumn("dbo.InsuranceClaims", "Gender");
            DropColumn("dbo.InsuranceClaims", "PhoneNumber");
            DropColumn("dbo.InsuranceClaims", "Email");
            DropColumn("dbo.InsuranceClaims", "Address");
        }
        
        public override void Down()
        {
            AddColumn("dbo.InsuranceClaims", "Address", c => c.String());
            AddColumn("dbo.InsuranceClaims", "Email", c => c.String());
            AddColumn("dbo.InsuranceClaims", "PhoneNumber", c => c.String());
            AddColumn("dbo.InsuranceClaims", "Gender", c => c.String());
            AddColumn("dbo.InsuranceClaims", "Name", c => c.String());
            DropForeignKey("dbo.InsuranceClaims", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.InsuranceClaims", new[] { "UserId" });
            DropColumn("dbo.InsuranceClaims", "UserId");
        }
    }
}
