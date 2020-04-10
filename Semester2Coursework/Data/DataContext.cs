namespace Semester2Coursework.Data
{
    public class DataContext : System.Data.Entity.DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx

        public DataContext() : base("name=DbContext")
        {
        }

        public System.Data.Entity.DbSet<Semester2Coursework.Models.Artist> Artists { get; set; }
        public System.Data.Entity.DbSet<Semester2Coursework.Models.Album> Albums { get; set; }

        public System.Data.Entity.DbSet<Semester2Coursework.Models.Member> Members { get; set; }

        public System.Data.Entity.DbSet<Semester2Coursework.Models.Loan> Loans { get; set; }

        public System.Data.Entity.DbSet<Semester2Coursework.Models.Producer> Producers { get; set; }

        public System.Data.Entity.DbSet<Semester2Coursework.Models.MemberCategory> MemberCategories { get; set; }

        public System.Data.Entity.DbSet<Semester2Coursework.Models.AlbumProducer> AlbumProducers { get; set; }

        public System.Data.Entity.DbSet<Semester2Coursework.Models.ArtistAlbum> ArtistAlbums { get; set; }
    }
}
