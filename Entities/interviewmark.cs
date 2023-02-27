using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace enlearn.Entities
{
    public class interviewmark
    {
        [Key]
        public int interviewmarkid { get; set; }

        [ForeignKey("studentid")]
        public int? studentid { get; set; }
        [MaxLength(20)] public string flanguage { get; set; }
        public int fm { get; set; }
        public int fmax { get; set; }
        [MaxLength(20)] public string slanguage { get; set; }

        public int sm { get; set; }
        public int smax { get; set; }
        [MaxLength(20)] public string optional1 { get; set; }

        public int m1 { get; set; }
        public int max1 { get; set; }
        [MaxLength(20)] public string optional2 { get; set; }

        public int m2 { get; set; }
        public int max2 { get; set; }
        [MaxLength(20)] public string optional3 { get; set; }


        public int m3 { get; set; }
        public int max3 { get; set; }
        [MaxLength(20)] public string optional4 { get; set; }


        public int m4 { get; set; }
        public int max4 { get; set; }

    }
}