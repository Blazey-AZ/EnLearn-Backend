using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace enlearn.Entities
{
    public class application
    {
        [Key]
        public int applicationno { get; set; }


        [ForeignKey("studentid")]
        public int? studentid { get; set; }
        public basicdetails student { get; set; }



        [MaxLength(40)] public string firstoption { get; set; }
        [MaxLength(40)] public string secondoption { get; set; }
        [MaxLength(40)] public string thirdoption { get; set; }
        [MaxLength(20)] public string tenthboard { get; set; }
        [MaxLength(50)] public string tenthinstitution { get; set; }
        [MaxLength(30)] public string tenthplace { get; set; }
        [MaxLength(100)] public string tenthstate { get; set; }
        public DateTime tenthyear { get; set; }
        public int tenthmark { get; set; }
        public int tenthnoofattempts { get; set; }
        [MaxLength(20)] public string twelfthboard { get; set; }
        [MaxLength(50)] public string twelfthinstitution { get; set; }
        [MaxLength(30)] public string twelfthplace { get; set; }
        [MaxLength(100)] public string twelfthstate { get; set; }
        public DateTime twelfthyear { get; set; }
        public int twelfthmark { get; set; }
        public int twelfthnoofattempts { get; set; }

        public DateTime date { get; set; } = DateTime.Now;
        [MaxLength(30)] public string applicationstatus { get; set; }


    }
}