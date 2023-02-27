using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace enlearn.DTOs
{
    public class CasteDto
    {
        [Required]
        public int CasteID {get; set;}
        
        [Required] 
        public string CasteName { get; set; }

        [Required]
        public string ReligionName { get; set; }

    }
}