using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace enlearn.Entities
{
    public class office
    {
        [Key]
        public int officeid { get; set; }

        [ForeignKey("studentid")]
        public int? studentid { get; set; }
        public basicdetails student { get; set; }
        [MaxLength(30)] public string status { get; set; }
        public DateTime date { get; set; }
        [MaxLength(20)] public string staffincharge { get; set; }
        [MaxLength(200)] public string comment { get; set; }
        [MaxLength(30)] public string username { get; set; }
        [MaxLength(30)] public string password { get; set; }

    }
}