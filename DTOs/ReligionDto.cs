using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace enlearn.DTOs
{
    public class ReligionDto
    {
    [Required]
    public int ReligionID {get; set;}
    
    [Required]
    public string ReligionName { get; set; } 
        
    }
}