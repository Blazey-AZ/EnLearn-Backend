using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace enlearn.Entities
{
    public class state
    {

        [Key]
        public int stateid { get; set; }
        [MaxLength(20)] public string statename { get; set; }

        
    }
}