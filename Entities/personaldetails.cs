using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace enlearn.Entities
{
    public class personaldetails
    {
        [Key]
        public int personalid { get; set; }

        [ForeignKey("studentid")]
        public int? studentid { get; set; }
        public basicdetails student { get; set; }
        [MaxLength(500)] public string image { get; set; }
        [MaxLength(20)] public string nameoffather { get; set; }
        public DateTime dateofbirth { get; set; }
        [MaxLength(20)] public string nationality { get; set; }
        [MaxLength(20)] public string annualincome { get; set; }

        [ForeignKey("religionid")]
        public int? religionid { get; set; }
        public religion religion { get; set; }

        [ForeignKey("casteid")]
        public int? casteid { get; set; }
        public caste caste { get; set; }

        [MaxLength(40)] public string housename { get; set; }
        [MaxLength(30)] public string place { get; set; }

        [ForeignKey("stateid")]
        public int? stateid { get; set; }
        public state state { get; set; }

        [ForeignKey("districtid")]
        public int? districtid { get; set; }
        public district district { get; set; }

        public int pincode { get; set; }
        [MaxLength(50)] public string email { get; set; }
        [MaxLength(30)] public string tempstatus { get; set; } 
        [MaxLength(20)] public string approvedcourse { get; set; } 
    }
}