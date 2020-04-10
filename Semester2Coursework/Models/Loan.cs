using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Semester2Coursework.Models
{
    public class Loan
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int MemberId { get; set; }
        [Required]
        public int AlbumId { get; set; }
        [Required]
        public DateTime IssueDate { get; set; }

        public DateTime ReturnDate { get; set; }

        public int FineAmount { get; set; }

        //Artists Reference
        [ForeignKey("MemberId")]
        public virtual Member Members { get; set; }


        //Album Reference
        [ForeignKey("AlbumId")]
        public virtual Album Albums { get; set; }
    }
}
