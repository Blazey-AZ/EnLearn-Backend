using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace enlearn.Entities
{
    public class parent
    {

        [Key]
        public int parentid { get; set; }

        [ForeignKey("studentid")]
        public int? studentid { get; set; }
        public basicdetails student { get; set; }
        [MaxLength(35)] public string father { get; set; }
        [MaxLength(35)] public string mother { get; set; }
        [MaxLength(40)] public string foccuption { get; set; }
        [MaxLength(40)] public string moccuption { get; set; }
        public int fcontact { get; set; }
        public int mcontact { get; set; }
    }
}