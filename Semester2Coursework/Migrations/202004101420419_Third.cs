namespace Semester2Coursework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Third : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ArtistAlbums",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ArtistId = c.Int(nullable: false),
                        AlbumId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Albums", t => t.AlbumId, cascadeDelete: true)
                .ForeignKey("dbo.Artists", t => t.ArtistId, cascadeDelete: true)
                .Index(t => t.ArtistId)
                .Index(t => t.AlbumId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ArtistAlbums", "ArtistId", "dbo.Artists");
            DropForeignKey("dbo.ArtistAlbums", "AlbumId", "dbo.Albums");
            DropIndex("dbo.ArtistAlbums", new[] { "AlbumId" });
            DropIndex("dbo.ArtistAlbums", new[] { "ArtistId" });
            DropTable("dbo.ArtistAlbums");
        }
    }
}
