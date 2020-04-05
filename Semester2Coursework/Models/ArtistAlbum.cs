using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Semester2Coursework.Models
{
    public class ArtistAlbum
    {
        [Key]
        public int Id { get; set; }
         public int ArtistId { get; set; }
        public int AlbumId { get; set; }

        //Artists Reference
        [ForeignKey("ArtistId")]
        public virtual Artist Artists { get; set; }


        //Album Reference
        [ForeignKey("AlbumId")]
        public virtual Album Albums { get; set; }
    }
}
