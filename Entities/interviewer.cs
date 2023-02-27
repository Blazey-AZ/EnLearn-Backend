using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace enlearn.Entities
{
    public class interviewer
    {
        [Key]
        public int interviewerid { get; set; }
         [MaxLength(30)] public string name { get; set; }
        [MaxLength(40)] public string department { get; set; }
        public int contact { get; set; }
        [MaxLength(50)] public string email { get; set; }
        [MaxLength(20)] public string username { get; set; }
        [MaxLength(50)] public string password { get; set; }
    }
}