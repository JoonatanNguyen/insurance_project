namespace InsuranceWebApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateInsuranceClaimsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.InsuranceClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Gender = c.String(),
                        PhoneNumber = c.String(),
                        Email = c.String(),
                        Address = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.InsuranceClaims");
        }
    }
}
