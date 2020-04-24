using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using Semester2Coursework.Data;
using Semester2Coursework.Models;

namespace Semester2Coursework.Controllers
{
    public class ReportController : Controller
    {
        private DataContext db = new DataContext();
        // GET: Report
        
        public ActionResult FilterAblumCountByArtist(string searchString)
        {
            var artistAlbums = db.ArtistAlbums.Include(a => a.Albums).Include(a => a.Artists);


            artistAlbums = artistAlbums.Where(s => s.Artists.LastName.Contains(searchString));
            

            return View(artistAlbums.ToList());
        }
        public ActionResult FilterAblumSelvedCountByArtist(string searchString)
        {
            
            var artistAlbums = db.ArtistAlbums.Include(a => a.Albums).Include(a => a.Artists);


            artistAlbums = artistAlbums.Where(s => s.Artists.LastName.Contains(searchString));
            artistAlbums = artistAlbums.Where((s => s.Albums.SongCount > 0));

            return View(artistAlbums.ToList());
        }

    }
}
