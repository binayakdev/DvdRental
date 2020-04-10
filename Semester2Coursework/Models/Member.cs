using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Semester2Coursework.Models
{
    public class Member
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        [Required]
        public int MemberCategoryId { get; set; }

        [ForeignKey("MemberCategoryId")]
        public virtual MemberCategory MemberCategorys { get; set; }





    }
}
