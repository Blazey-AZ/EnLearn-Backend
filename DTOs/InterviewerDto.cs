using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace enlearn.DTOs
{
    public class InterviewerDto
    {
        [Required]
         public int InterviewerID { get; set; }
        [Required]
        public string InterviewerName { get; set; }
        [Required]
        public int Contact { get; set; }
        [Required]
        public string Department { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}