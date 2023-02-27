using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace enlearn.DTOs
{
    public class PersonalDetailsDto
    {
        [Required] 
        public int PersonalID { get; set; }
        public int StudentID { get; set; }

        public string StudentName { get; set; }

        [Required] 
        public string Image { get; set; }

        [Required] 
        public string NameOfFather { get; set; }

        [Required] 
        public DateTime DateOfBirth { get; set; }

        [Required] 
        public string Nationality { get; set; }
        [Required] 
        public string AnnualIncome { get; set; }
        
        public string ReligionName { get; set; }
        public string CasteName { get; set; }
        [Required] 
        public string HouseName { get; set; }
        [Required] 
        public string Place { get; set; }
        public string StateName { get; set; }
        public string DistrictName { get; set; }
        [Required] 
        public int Pincode { get; set; }
        [Required] 
        public string Email { get; set; }
    }
}