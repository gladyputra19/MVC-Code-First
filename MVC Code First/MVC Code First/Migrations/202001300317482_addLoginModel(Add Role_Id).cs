namespace MVC_Code_First.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addLoginModel1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TB_M_Login", "Role_Id", c => c.Int());
            AlterColumn("dbo.TB_M_Login", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.TB_M_Login", "Password", c => c.String(nullable: false));
            CreateIndex("dbo.TB_M_Login", "Role_Id");
            AddForeignKey("dbo.TB_M_Login", "Role_Id", "dbo.TB_M_Role", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TB_M_Login", "Role_Id", "dbo.TB_M_Role");
            DropIndex("dbo.TB_M_Login", new[] { "Role_Id" });
            AlterColumn("dbo.TB_M_Login", "Password", c => c.String());
            AlterColumn("dbo.TB_M_Login", "Email", c => c.String());
            DropColumn("dbo.TB_M_Login", "Role_Id");
        }
    }
}
