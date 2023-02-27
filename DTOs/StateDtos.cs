using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace enlearn.DTOs
{
    public class StateDto
    {
        [Required]
        public  int StateID {get; set;}
        [Required]
        public string StateName { get; set; }
    }
}