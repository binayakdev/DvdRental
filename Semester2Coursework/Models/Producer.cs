using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Semester2Coursework.Models
{
    public class Producer
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        public string Studio { get; set; }
        public DateTime DateOfBirth { get; set; }

    }
}