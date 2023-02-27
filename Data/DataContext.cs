using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using enlearn.Entities;
using Microsoft.EntityFrameworkCore;

namespace enlearn.Data
{
    public class DataContext : DbContext
    {
           public DataContext(DbContextOptions options) : base(options)
        {
        
        }
        public DbSet<principal> tblcap_principal { get; set; }

        public DbSet<basicdetails> tblcap_basicdetails { get; set; }
        public DbSet<course> tblcap_course { get; set; }
        public DbSet<caste> tblcap_caste { get; set; }
        public DbSet<religion> tblcap_religion { get; set; }
        public DbSet<state> tblcap_state { get; set; }
        public DbSet<district> tblcap_district { get; set; }
        public DbSet<application> tblcap_application { get; set; }
        public DbSet<interviewer> tblcap_interviewer{ get; set; }
        public DbSet<interview> tblcap_interview { get; set; }
        public DbSet<interviewmark> tblcap_interviewmark { get; set; }
        public DbSet<office> tblcap_office { get; set; }
        public DbSet<parent> tblcap_parent { get; set; }
        public DbSet<personaldetails> tblcap_personaldetails { get; set; }


    }
    
}