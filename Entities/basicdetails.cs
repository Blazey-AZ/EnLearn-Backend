using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace enlearn.Entities
{
    public class basicdetails
    {
        [Key]
        public int studentid { get; set; }
        [MaxLength(20)] public string studentname { get; set; } 
        [MaxLength(10)] public string contactnumber { get; set; } 
        [MaxLength(10)] public string gender { get; set; } 
        [MaxLength(40)] public string username { get; set; } 
        [MaxLength(40)] public string password { get; set; } 
        [MaxLength(40)] public string email { get; set; } 

        [MaxLength(10)] public string parentcontact { get; set; } 

        [MaxLength(10)] public string status { get; set;}
        
        

    }
}