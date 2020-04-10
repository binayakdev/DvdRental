namespace Semester2Coursework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Second : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AlbumProducers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProducerId = c.Int(nullable: false),
                        AlbumId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Albums", t => t.AlbumId, cascadeDelete: true)
                .ForeignKey("dbo.Producers", t => t.ProducerId, cascadeDelete: true)
                .Index(t => t.ProducerId)
                .Index(t => t.AlbumId);
            
            CreateTable(
                "dbo.Producers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Studio = c.String(),
                        DateOfBirth = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MemberCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Description = c.String(),
                        TotalLoan = c.String(),
                        ReturningDays = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Members", "Email", c => c.String());
            AddColumn("dbo.Members", "DateOfBirth", c => c.DateTime(nullable: false));
            AddColumn("dbo.Members", "MemberCategoryId", c => c.Int(nullable: false));
            AlterColumn("dbo.Members", "Phone", c => c.String(nullable: false));
            CreateIndex("dbo.Members", "MemberCategoryId");
            AddForeignKey("dbo.Members", "MemberCategoryId", "dbo.MemberCategories", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Members", "MemberCategoryId", "dbo.MemberCategories");
            DropForeignKey("dbo.AlbumProducers", "ProducerId", "dbo.Producers");
            DropForeignKey("dbo.AlbumProducers", "AlbumId", "dbo.Albums");
            DropIndex("dbo.Members", new[] { "MemberCategoryId" });
            DropIndex("dbo.AlbumProducers", new[] { "AlbumId" });
            DropIndex("dbo.AlbumProducers", new[] { "ProducerId" });
            AlterColumn("dbo.Members", "Phone", c => c.String());
            DropColumn("dbo.Members", "MemberCategoryId");
            DropColumn("dbo.Members", "DateOfBirth");
            DropColumn("dbo.Members", "Email");
            DropTable("dbo.MemberCategories");
            DropTable("dbo.Producers");
            DropTable("dbo.AlbumProducers");
        }
    }
}
