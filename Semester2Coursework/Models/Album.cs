using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Semester2Coursework.Models
{
    public class Album
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        public int SongCount { get; set; }
        [NotMapped]
        public HttpPostedFileBase CoverImage {get; set;}
        [MaxLength(100)]
        public string CoverImagePath { get; set; }
        public DateTime ReleaseDate { get; set; }
        [MaxLength(50)]
        public string TotalTime { get; set; }
        public virtual IEnumerable<Artist> Artists { get; set; }
    }
}