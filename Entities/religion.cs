using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace enlearn.Entities
{
    public class religion
    {

    [Key]
    public int religionid { get; set; }
    [MaxLength(20)] public string religionname { get; set; } 


    }
}