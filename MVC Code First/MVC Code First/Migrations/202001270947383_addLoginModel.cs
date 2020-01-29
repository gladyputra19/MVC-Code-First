namespace MVC_Code_First.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addLoginModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TB_M_Login",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TB_M_Login");
        }
    }
}
