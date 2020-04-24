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


            artistAlbums = artistAlbums.Where(s => s.Artists.LastName.Contains(searchString));
            

            return View(artistAlbums.ToList());
        }

        // Function 2
        public ActionResult FilterAblumSelvedCountByArtist(string searchString)
        {
            
            var artistAlbums = db.ArtistAlbums.Include(a => a.Albums).Include(a => a.Artists);


            artistAlbums = artistAlbums.Where(s => s.Artists.LastName.Contains(searchString));
            artistAlbums = artistAlbums.Where((s => s.Albums.SongCount > 0));

            return View(artistAlbums.ToList());
        }

        
        // Function 3
        public ActionResult MemberLoan(int? memberNumber, string searchString)
        {
            var constraint = DateTime.Now.AddDays(-31);
            var loan = db.Loans.Include(a => a.Albums).Include(a => a.Members);

            if (memberNumber.HasValue)
            {
                loan = loan.Where(s => s.Members.Id.Equals(memberNumber));
            }
            else if(!String.IsNullOrEmpty(searchString))
            {
                loan = loan.Where(s => s.Members.Name.Contains(searchString));
            }
            loan = loan.Where(s => s.IssueDate >= constraint);

            return View(loan.ToList());
        }

        // Function 4
        public ActionResult DvdDetails()
        {
            var albumProducer = db.AlbumProducers.Include(a => a.Albums).Include(a => a.Producers);

            return View(albumProducer.ToList());
        }

    }
}
