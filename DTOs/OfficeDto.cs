using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace enlearn.DTOs
{
    public class OfficeDto
    {
        [Required]
         public int OfficeID { get; set; }
        public string StaffInCharge { get; set; }
       
        // [Required]
        // public string Email { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; } 
        public string Comment {get; set;}
    }
}