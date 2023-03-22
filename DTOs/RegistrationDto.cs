using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace enlearn.DTOs
{
    public class RegistrationDto
    {
        [Required] 
        public string StudentName { get; set; }

        [Required] 
        public string ContactNumber { get; set; }

        [Required] 
        public string Gender { get; set; }

        [Required] 
        public string UserName { get; set; }

        [Required] 
        public string Password { get; set; }
        [Required] 
        public string Email { get; set; }
        
        [Required] 
        public string ParentContact { get; set; }
    }
}