using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace enlearn.DTOs
{
    public class CourseDtos
    {
        [Required] 
        public int CourseID { get; set; }
        [Required] 
        public string CourseName { get; set; }

        [Required] 
        public string CourseShortName { get; set; }

        [Required] 
        public string CourseType { get; set; }

        [Required] 
        public string CourseDescription { get; set; }

    }
}