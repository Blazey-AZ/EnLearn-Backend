using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using enlearn.Entities;

namespace enlearn.DTOs
{
    public class PrincipalDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
       
        // public string Comment { get; set; }
    }
}