using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using System.Linq;
using System.Threading.Tasks;

namespace enlearn.DTOs
{
    public class DistrictDto
    {
        [Required]
        public int DistrictID { get; set; }
        
        [Required]
        public string DistrictName { get; set; }

        [Required]
        public string StateName { get; set; }

    }
}