namespace Semester2Coursework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Loans",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MemberId = c.Int(nullable: false),
                        AlbumId = c.Int(nullable: false),
                        issueDate = c.DateTime(nullable: false),
                        returnDate = c.DateTime(nullable: false),
                        fineamount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Albums", t => t.AlbumId, cascadeDelete: true)
                .ForeignKey("dbo.Members", t => t.MemberId, cascadeDelete: true)
                .Index(t => t.MemberId)
                .Index(t => t.AlbumId);
            
            AddColumn("dbo.Members", "Phone", c => c.String());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Loans", "MemberId", "dbo.Members");
            DropForeignKey("dbo.Loans", "AlbumId", "dbo.Albums");
            DropIndex("dbo.Loans", new[] { "AlbumId" });
            DropIndex("dbo.Loans", new[] { "MemberId" });
            DropColumn("dbo.Members", "Phone");
            DropTable("dbo.Loans");
        }
    }
}
