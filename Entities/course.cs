using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace enlearn.Entities
{
    public class course
    {
        [Key]
        public int courseid { get; set; }
        [MaxLength(20)] public string coursename { get; set; } 
        [MaxLength(8)] public string courseshortname { get; set; } 
        [MaxLength(30)] public string coursetype { get; set; } 
        [MaxLength(200)] public string coursedescription { get; set; } 
    }
}