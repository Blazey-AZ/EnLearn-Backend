using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace enlearn.DTOs
{
    public class ApplicationDto
    {
        [Required]
        public int ApplicationNo { get; set; }
        public int StudentID { get; set; }

        public string StudentName { get; set; }

        [Required]
        public string FirstOption { get; set; }

        [Required]
        public string SecondOption { get; set; }

        [Required]
        public string ThirdOption { get; set; }

        [Required]
        public string TenthBoard { get; set; }
        [Required]
        public string TenthInstitution { get; set; }

        public string TenthPlace { get; set; }
        public string TenthState { get; set; }
        [Required]
        public DateTime TenthYear { get; set; }
        [Range(30, 100)]
        public int TenthMark { get; set; }
        public int TenthNoOfAttempts { get; set; }
        public string TwelfthBoard { get; set; }
        [Required]
        public string TwelfthInstitution { get; set; }
        [Required]
        public string TwelfthPlace { get; set; }
        public string TwelfthState { get; set; }
        [Required]
        public DateTime TwelfthYear { get; set; }
        [Range(30, 100)]
        public int TwelfthMark { get; set; }
        [Required]
        public int TwelfthNoOfAttempts { get; set; }
        [Required]
        public DateTime Date { get; set; }

        public string ApplicationStatus { get; set; }
    }
}
