using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace enlearn.DTOs
{
    public class UserDto
    {
        public int StudentID { get; set; }

        public string StudentName { get; set; }
        public string ContactNumber { get; set; }
        public string Gender { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ParentContact { get; set; }
    }
}