using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace enlearn.Entities
{
    public class caste
    {

        [Key]
        public int casteid { get; set; }
        [MaxLength(45)] public string castename { get; set; }

        [ForeignKey("religionid")]
        public int? religionid { get; set; }
        public virtual religion religion { get; set; }

    }
}