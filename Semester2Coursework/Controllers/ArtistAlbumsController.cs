using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Semester2Coursework.Data;
using Semester2Coursework.Models;

namespace Semester2Coursework.Controllers
{
    public class ArtistAlbumsController : Controller
    {
        private DataContext db = new DataContext();

        // GET: ArtistAlbums
        public ActionResult Index(string searchString)
        {
            var artistAlbums = db.ArtistAlbums.Include(a => a.Albums).Include(a => a.Artists);

            if (!String.IsNullOrEmpty(searchString))
            {
                artistAlbums = artistAlbums.Where(s => s.Artists.LastName.Contains(searchString));

            }
            return View(artistAlbums.ToList());
        }

        // GET: ArtistAlbums/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArtistAlbum artistAlbum = db.ArtistAlbums.Find(id);
            if (artistAlbum == null)
            {
                return HttpNotFound();
            }
            return View(artistAlbum);
        }

        // GET: ArtistAlbums/Create
        public ActionResult Create()
        {
            ViewBag.AlbumId = new SelectList(db.Albums, "Id", "Name");
            ViewBag.ArtistId = new SelectList(db.Artists, "Id", "LastName");
            return View();
        }

        // POST: ArtistAlbums/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ArtistId,AlbumId")] ArtistAlbum artistAlbum)
        {
            if (ModelState.IsValid)
            {
                db.ArtistAlbums.Add(artistAlbum);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AlbumId = new SelectList(db.Albums, "Id", "Name", artistAlbum.AlbumId);
            ViewBag.ArtistId = new SelectList(db.Artists, "Id", "LastName", artistAlbum.ArtistId);
            return View(artistAlbum);
        }

        // GET: ArtistAlbums/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArtistAlbum artistAlbum = db.ArtistAlbums.Find(id);
            if (artistAlbum == null)
            {
                return HttpNotFound();
            }
            ViewBag.AlbumId = new SelectList(db.Albums, "Id", "Name", artistAlbum.AlbumId);
            ViewBag.ArtistId = new SelectList(db.Artists, "Id", "LastName", artistAlbum.ArtistId);
            return View(artistAlbum);
        }

        // POST: ArtistAlbums/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ArtistId,AlbumId")] ArtistAlbum artistAlbum)
        {
            if (ModelState.IsValid)
            {
                db.Entry(artistAlbum).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AlbumId = new SelectList(db.Albums, "Id", "Name", artistAlbum.AlbumId);
            ViewBag.ArtistId = new SelectList(db.Artists, "Id", "LastName", artistAlbum.ArtistId);
            return View(artistAlbum);
        }

        // GET: ArtistAlbums/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArtistAlbum artistAlbum = db.ArtistAlbums.Find(id);
            if (artistAlbum == null)
            {
                return HttpNotFound();
            }
            return View(artistAlbum);
        }

        // POST: ArtistAlbums/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ArtistAlbum artistAlbum = db.ArtistAlbums.Find(id);
            db.ArtistAlbums.Remove(artistAlbum);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
