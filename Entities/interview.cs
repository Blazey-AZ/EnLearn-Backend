using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace enlearn.Entities
{
    public class interview
    {
        [Key]
        public int interviewid { get; set; }

        [ForeignKey("studentid")]
        public int? studentid { get; set; }
        public basicdetails student { get; set; }

        [ForeignKey("interviewerid")]
        public int interviewerid { get; set; }
        public interviewer interviewer { get; set; }
        public int attitude { get; set; }
         public int personality { get; set; }
         public int logicalskill { get; set; }
         public int behaviour { get; set; }
         public int subjectknowledge { get; set; }
         public int language { get; set; }
         public DateTime interviewdate { get; set; }
        [MaxLength(35)] public string remark { get; set; }


    }
}