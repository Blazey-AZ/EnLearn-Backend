using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace enlearn.DTOs
{
    public class ReportDto
    {
        public int count {get; set;}
        public List<ApplicationDto> applications {get; set;} = new List<ApplicationDto>();
    }
}