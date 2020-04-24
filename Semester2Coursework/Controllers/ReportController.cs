using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using Semester2Coursework.Data;
using Semester2Coursework.Models;
using Microsoft.Ajax.Utilities;
using System.Web.UI.WebControls;

namespace Semester2Coursework.Controllers
{
    public class ReportController : Controller
    {
        private DataContext db = new DataContext();
        // GET: Report


        // Function 1
        public ActionResult FilterAblumCountByArtist(string searchString)
        {
            var artistAlbums = db.ArtistAlbums.Include(a => a.Albums).Include(a => a.Artists);


            artistAlbums = artistAlbums.Where(s => s.Artists.LastName.Equals(searchString));


            return View(artistAlbums.ToList());
        }

        // Function 2
        public ActionResult FilterAblumSelvedCountByArtist(string searchString)
        {

            var artistAlbums = db.ArtistAlbums.Include(a => a.Albums).Include(a => a.Artists);


            artistAlbums = artistAlbums.Where(s => s.Artists.LastName.Equals(searchString));
            artistAlbums = artistAlbums.Where((s => s.Albums.SongCount > 0));

            return View(artistAlbums.ToList());
        }


        // Function 3
        public ActionResult MemberLoan(int? memberNumber, string searchString)
        {
            var constraint = DateTime.Now.AddDays(-100);
            var loan = db.Loans.Include(a => a.Albums).Include(a => a.Members);

            if (memberNumber.HasValue)
            {
                loan = loan.Where(s => s.Members.Id.Equals(memberNumber));
            }
            else if (!String.IsNullOrEmpty(searchString))
            {
                loan = loan.Where(s => s.Members.Name.Equals(searchString));
            }
            loan = loan.Where(s => s.IssueDate >= constraint);

            return View(loan.ToList());
        }

        public IEnumerable<Artist> Artists { get; set; }

        // Function 4
        public ActionResult DvdDetails()
        {
            List<AlbumProducer> albumProducer = db.AlbumProducers.ToList();
            List<ArtistAlbum> artistAlbum = db.ArtistAlbums.ToList();

            var dvdDetails = (from alb in albumProducer
                             join art in artistAlbum on alb.AlbumId equals art.AlbumId
                             orderby alb.Albums.ReleaseDate ascending
                             select alb).ToList();

            foreach (var items in dvdDetails)
            {
                Console.WriteLine(items);
            }
            //var albumProducer = db.AlbumProducers;

            return View(dvdDetails);
        }

    }
}
