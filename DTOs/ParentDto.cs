using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace enlearn.DTOs
{
    public class ParentDto
    {
        public int parentID { get; set; }
        [Required]
        public int studentID { get; set; }
        public string studentName { get; set; }
       
        [Required]
        public string Father { get; set; }
        [Required]
        public string Mother { get; set; }
        [Required]
        public string FOccupation { get; set; }
        [Required]
        public string MOccupation { get; set; }
        [Required]
        public int FContact { get; set; }
        [Required]
        public int MContact { get; set; }
    }
}