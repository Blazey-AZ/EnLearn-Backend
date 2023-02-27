using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace enlearn.Entities
{
    public class principal
    {
         [Key]
        public int principalid { get; set; }
        [MaxLength(40)] public string username { get; set; }
        [MaxLength(40)] public string password { get; set; }


        // [ForeignKey("studentid")]
        // public int? studentid { get; set; }
        // public virtual basicdetails student { get; set; }

        // [MaxLength(40)] public string status { get; set; }

        // public DateTime date { get; set; }

        // [ForeignKey("courseid")]
        // public int? courseid { get; set; }
        // public virtual course course { get; set; }


        // [MaxLength(100)] public string comment { get; set; }


    }
}