using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace enlearn.Entities
{
    public class district
    {
         [Key]
        public int districtid { get; set; }
        [MaxLength(20)] public string districtname { get; set; }

        public int? stateid { get; set; }
        [ForeignKey(name: "stateid")]

        public state state { get; set; }
    }
}