namespace InsuranceWebApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddInsuranceClaimUserRelation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.InsuranceClaims", "User_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.InsuranceClaims", "User_Id");
            AddForeignKey("dbo.InsuranceClaims", "User_Id", "dbo.AspNetUsers", "Id");
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
            DropForeignKey("dbo.InsuranceClaims", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.InsuranceClaims", new[] { "User_Id" });
            DropColumn("dbo.InsuranceClaims", "User_Id");
        }
    }
}
