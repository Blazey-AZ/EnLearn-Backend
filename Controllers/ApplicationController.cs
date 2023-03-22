using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using enlearn.Data;
using enlearn.DTOs;
using enlearn.Entities;
using enlearn.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace enlearn.Controllers
{
    public class ApplicationController : BaseApiController
    {
        public DataContext _context { get; }
        public ApplicationController(DataContext context)
        {
            _context = context;
        }



        [HttpPost("register")] //api/application/register/
        public async Task<ActionResult<ApplicationDto>> DetailsRegister(ApplicationDto applicationDto)

        {

        

            if (await ApplicationExists(applicationDto.ApplicationNo)) return BadRequest("Application details already exists");

            var application = new application
            {
                applicationno = applicationDto.ApplicationNo,
                studentid = applicationDto.StudentID,
                firstoption = applicationDto.FirstOption,
                secondoption = applicationDto.SecondOption,
                thirdoption = applicationDto.ThirdOption,
                tenthboard = applicationDto.TenthBoard,
                tenthinstitution = applicationDto.TenthInstitution,
                tenthplace = applicationDto.TenthPlace,
                tenthstate = applicationDto.TenthState,

                tenthyear = applicationDto.TenthYear,
                tenthmark = applicationDto.TenthMark,

                tenthnoofattempts = applicationDto.TenthNoOfAttempts,
                twelfthboard = applicationDto.TwelfthBoard,
                twelfthinstitution = applicationDto.TwelfthInstitution,
                twelfthplace = applicationDto.TwelfthPlace,
                twelfthstate = applicationDto.TwelfthState,
                twelfthyear = applicationDto.TwelfthYear,
                twelfthmark = applicationDto.TwelfthMark,
                twelfthnoofattempts = applicationDto.TwelfthNoOfAttempts,
                applicationstatus = applicationDto.ApplicationStatus


            };

            _context.tblcap_application.Add(application);
            await _context.SaveChangesAsync();

            return applicationDto;
        }
        private async Task<bool> ApplicationExists(int ApplicationNo)
        {
            return await _context.tblcap_application.AnyAsync(x => x.applicationno <= ApplicationNo);
        }


        [HttpGet("getcourse")]
        public async Task<ActionResult<CourseDtos>> GetCourse()
        {
            List<CourseDtos> courseDtos = new List<CourseDtos>();

            List<course> course = await _context.tblcap_course.ToListAsync();

            foreach (var item in course)
            {
                courseDtos.Add(new CourseDtos()
                {
                    CourseShortName = item.courseshortname,

                });
            }

            return Ok(courseDtos);

        }

        [HttpGet("getapp/{id}")]
        public async Task<ActionResult<application>> GetApp(int id)
        {


            var app = await _context.tblcap_application.FirstOrDefaultAsync(c => c.applicationno == id);

            if (app == null)
                return NoContent();

            return app;

        }


        [HttpGet("viewapplicationinfos")]
        public async Task<IEnumerable<ApplicationDto>> GetApplications()
        {
            var applicationList = (from a in _context.tblcap_application
                                   join stud in _context.tblcap_basicdetails on a.studentid equals stud.studentid

                                   select new ApplicationDto()
                                   {
                                       ApplicationNo = a.applicationno,
                                       StudentID = stud.studentid,
                                       StudentName = stud.studentname,
                                       FirstOption = a.firstoption,
                                       SecondOption = a.secondoption,
                                       ThirdOption = a.thirdoption,

                                       TenthInstitution = a.tenthinstitution,

                                       TenthMark = a.tenthmark,
                                       TenthNoOfAttempts = a.tenthnoofattempts,

                                       TwelfthInstitution = a.twelfthinstitution,

                                       TwelfthMark = a.twelfthmark,
                                       TwelfthNoOfAttempts = a.twelfthnoofattempts,
                                       Date = a.date,
                                       ApplicationStatus = a.applicationstatus

                                   }).ToListAsync();



            return await applicationList;



        }
        [HttpGet("viewapplicationinfo/{id}")]
        public async Task<IEnumerable<ApplicationDto>> GetApplication(int id)
        {
            var applicationList = (from a in _context.tblcap_application
                                   join stud in _context.tblcap_basicdetails on a.studentid equals stud.studentid

                                   where a.applicationno == id

                                   select new ApplicationDto()
                                   {
                                       ApplicationNo = a.applicationno,
                                       StudentID = stud.studentid,
                                       StudentName = stud.studentname,
                                       FirstOption = a.firstoption,
                                       SecondOption = a.secondoption,
                                       ThirdOption = a.thirdoption,
                                       TenthBoard = a.tenthboard,
                                       TenthInstitution = a.tenthinstitution,
                                       TenthPlace = a.tenthplace,
                                       TenthState = a.tenthstate,
                                       TenthYear = a.tenthyear,
                                       TenthMark = a.tenthmark,
                                       TenthNoOfAttempts = a.tenthnoofattempts,
                                       TwelfthBoard = a.twelfthboard,
                                       TwelfthInstitution = a.twelfthinstitution,
                                       TwelfthPlace = a.twelfthplace,
                                       TwelfthState = a.twelfthstate,
                                       TwelfthYear = a.twelfthyear,
                                       TwelfthMark = a.twelfthmark,
                                       TwelfthNoOfAttempts = a.twelfthnoofattempts,
                                       Date = a.date,
                                       ApplicationStatus = a.applicationstatus

                                   }).ToListAsync();



            return await applicationList;



        }

        [HttpPost("verify/{id}")]
        public async Task<ActionResult> Enroll(int id)
        {
            var application = await _context.tblcap_application
            .FirstOrDefaultAsync(a => a.applicationno == id);
            if (application == null)
                return NoContent();

            application.applicationstatus = "Verified";
            await _context.SaveChangesAsync();
            return Ok(true);
        }


        [HttpPost("unverified/{id}")]
        public async Task<ActionResult> Reject(int id)
        {
            var application = await _context.tblcap_application
            .FirstOrDefaultAsync(a => a.applicationno == id);
            if (application == null)
                return NoContent();



            application.applicationstatus = "Unverified";
            await _context.SaveChangesAsync();
            return Ok(false);
        }


        [HttpGet("viewappinfo")]
        public async Task<IEnumerable<ApplicationDto>> GetAppDetails()
        {
            var applistdetails = (from a in _context.tblcap_application
                                  join stud in _context.tblcap_basicdetails on a.studentid equals stud.studentid

                                  
                                  select new ApplicationDto()
                                  {
                                      ApplicationNo = a.applicationno,
                                      StudentID = stud.studentid,
                                      StudentName = stud.studentname,
                                      FirstOption = a.firstoption,
                                      SecondOption = a.secondoption,
                                      ThirdOption = a.thirdoption,
                                      TenthBoard = a.tenthboard,
                                      TenthInstitution = a.tenthinstitution,
                                      TenthPlace = a.tenthplace,
                                      TenthState = a.tenthstate,
                                      TenthYear = a.tenthyear,
                                      TenthMark = a.tenthmark,
                                      TenthNoOfAttempts = a.tenthnoofattempts,
                                      TwelfthBoard = a.twelfthboard,
                                      TwelfthInstitution = a.twelfthinstitution,
                                      TwelfthPlace = a.twelfthplace,
                                      TwelfthState = a.twelfthstate,
                                      TwelfthYear = a.twelfthyear,
                                      TwelfthMark = a.twelfthmark,
                                      TwelfthNoOfAttempts = a.twelfthnoofattempts,
                                      Date = a.date,
                                      ApplicationStatus = a.applicationstatus

                                  }).ToListAsync();



            return await applistdetails;



        }
         [HttpGet("enrollreport")]
        public async Task<ActionResult> EnrollReport()
        {
            int count = await _context.tblcap_application
            .Where(s => s.applicationstatus == "Enroll")
            .CountAsync();

            var applistdetails = await (from a in _context.tblcap_application
                                  join stud in _context.tblcap_basicdetails on a.studentid equals stud.studentid
                                
                                 
                                  select new ApplicationDto()
                                  {
                                      ApplicationNo = a.applicationno,
                                      StudentID = stud.studentid,
                                      StudentName = stud.studentname,
                                      FirstOption = a.firstoption,
                                      SecondOption = a.secondoption,
                                      ThirdOption = a.thirdoption,
                                      TenthBoard = a.tenthboard,
                                      TenthInstitution = a.tenthinstitution,
                                      TenthPlace = a.tenthplace,
                                      TenthState = a.tenthstate,
                                      TenthYear = a.tenthyear,
                                      TenthMark = a.tenthmark,
                                      TenthNoOfAttempts = a.tenthnoofattempts,
                                      TwelfthBoard = a.twelfthboard,
                                      TwelfthInstitution = a.twelfthinstitution,
                                      TwelfthPlace = a.twelfthplace,
                                      TwelfthState = a.twelfthstate,
                                      TwelfthYear = a.twelfthyear,
                                      TwelfthMark = a.twelfthmark,
                                      TwelfthNoOfAttempts = a.twelfthnoofattempts,
                                      Date = a.date,
                                      ApplicationStatus = a.applicationstatus

                                  }).Where(x => x.ApplicationStatus == "Enroll").ToListAsync();

            return Ok(applistdetails);  
        }

        [HttpGet("rejectreport")]
        public async Task<ActionResult> RejectReport()
        {
            int count = await _context.tblcap_application
            .Where(s => s.applicationstatus == "Reject")
            .CountAsync();

            var applistdetails = await (from a in _context.tblcap_application
                                  join stud in _context.tblcap_basicdetails on a.studentid equals stud.studentid
                                
                                 
                                  select new ApplicationDto()
                                  {
                                      ApplicationNo = a.applicationno,
                                      StudentID = stud.studentid,
                                      StudentName = stud.studentname,
                                      FirstOption = a.firstoption,
                                      SecondOption = a.secondoption,
                                      ThirdOption = a.thirdoption,
                                      TenthBoard = a.tenthboard,
                                      TenthInstitution = a.tenthinstitution,
                                      TenthPlace = a.tenthplace,
                                      TenthState = a.tenthstate,
                                      TenthYear = a.tenthyear,
                                      TenthMark = a.tenthmark,
                                      TenthNoOfAttempts = a.tenthnoofattempts,
                                      TwelfthBoard = a.twelfthboard,
                                      TwelfthInstitution = a.twelfthinstitution,
                                      TwelfthPlace = a.twelfthplace,
                                      TwelfthState = a.twelfthstate,
                                      TwelfthYear = a.twelfthyear,
                                      TwelfthMark = a.twelfthmark,
                                      TwelfthNoOfAttempts = a.twelfthnoofattempts,
                                      Date = a.date,
                                      ApplicationStatus = a.applicationstatus

                                  }).Where(x => x.ApplicationStatus == "Reject").ToListAsync();

            return Ok(applistdetails);  
        }

        [HttpGet("passreport")]
        public async Task<ActionResult> PassReport()
        {
            int count = await _context.tblcap_application
            .Where(s => s.applicationstatus == "Pass")
            .CountAsync();

            var applistdetails = await (from a in _context.tblcap_application
                                  join stud in _context.tblcap_basicdetails on a.studentid equals stud.studentid
                                
                                 
                                  select new ApplicationDto()
                                  {
                                      ApplicationNo = a.applicationno,
                                      StudentID = stud.studentid,
                                      StudentName = stud.studentname,
                                      FirstOption = a.firstoption,
                                      SecondOption = a.secondoption,
                                      ThirdOption = a.thirdoption,
                                      TenthBoard = a.tenthboard,
                                      TenthInstitution = a.tenthinstitution,
                                      TenthPlace = a.tenthplace,
                                      TenthState = a.tenthstate,
                                      TenthYear = a.tenthyear,
                                      TenthMark = a.tenthmark,
                                      TenthNoOfAttempts = a.tenthnoofattempts,
                                      TwelfthBoard = a.twelfthboard,
                                      TwelfthInstitution = a.twelfthinstitution,
                                      TwelfthPlace = a.twelfthplace,
                                      TwelfthState = a.twelfthstate,
                                      TwelfthYear = a.twelfthyear,
                                      TwelfthMark = a.twelfthmark,
                                      TwelfthNoOfAttempts = a.twelfthnoofattempts,
                                      Date = a.date,
                                      ApplicationStatus = a.applicationstatus

                                  }).Where(x => x.ApplicationStatus == "Pass").ToListAsync();

            return Ok(applistdetails);  
        }

[HttpGet("failreport")]
        public async Task<ActionResult> FailReport()
        {
            int count = await _context.tblcap_application
            .Where(s => s.applicationstatus == "Fail")
            .CountAsync();

            var applistdetails = await (from a in _context.tblcap_application
                                  join stud in _context.tblcap_basicdetails on a.studentid equals stud.studentid
                                
                                 
                                  select new ApplicationDto()
                                  {
                                      ApplicationNo = a.applicationno,
                                      StudentID = stud.studentid,
                                      StudentName = stud.studentname,
                                      FirstOption = a.firstoption,
                                      SecondOption = a.secondoption,
                                      ThirdOption = a.thirdoption,
                                      TenthBoard = a.tenthboard,
                                      TenthInstitution = a.tenthinstitution,
                                      TenthPlace = a.tenthplace,
                                      TenthState = a.tenthstate,
                                      TenthYear = a.tenthyear,
                                      TenthMark = a.tenthmark,
                                      TenthNoOfAttempts = a.tenthnoofattempts,
                                      TwelfthBoard = a.twelfthboard,
                                      TwelfthInstitution = a.twelfthinstitution,
                                      TwelfthPlace = a.twelfthplace,
                                      TwelfthState = a.twelfthstate,
                                      TwelfthYear = a.twelfthyear,
                                      TwelfthMark = a.twelfthmark,
                                      TwelfthNoOfAttempts = a.twelfthnoofattempts,
                                      Date = a.date,
                                      ApplicationStatus = a.applicationstatus

                                  }).Where(x => x.ApplicationStatus == "Fail").ToListAsync();

            return Ok(applistdetails);  
        }

        [HttpGet("verifyreport")]
        public async Task<ActionResult> VerifyReport()
        {
            int count = await _context.tblcap_application
            .Where(s => s.applicationstatus == "Verified")
            .CountAsync();

            var applistdetails = await (from a in _context.tblcap_application
                                  join stud in _context.tblcap_basicdetails on a.studentid equals stud.studentid
                                
                                 
                                  select new ApplicationDto()
                                  {
                                      ApplicationNo = a.applicationno,
                                      StudentID = stud.studentid,
                                      StudentName = stud.studentname,
                                      FirstOption = a.firstoption,
                                      SecondOption = a.secondoption,
                                      ThirdOption = a.thirdoption,
                                      TenthBoard = a.tenthboard,
                                      TenthInstitution = a.tenthinstitution,
                                      TenthPlace = a.tenthplace,
                                      TenthState = a.tenthstate,
                                      TenthYear = a.tenthyear,
                                      TenthMark = a.tenthmark,
                                      TenthNoOfAttempts = a.tenthnoofattempts,
                                      TwelfthBoard = a.twelfthboard,
                                      TwelfthInstitution = a.twelfthinstitution,
                                      TwelfthPlace = a.twelfthplace,
                                      TwelfthState = a.twelfthstate,
                                      TwelfthYear = a.twelfthyear,
                                      TwelfthMark = a.twelfthmark,
                                      TwelfthNoOfAttempts = a.twelfthnoofattempts,
                                      Date = a.date,
                                      ApplicationStatus = a.applicationstatus

                                  }).Where(x => x.ApplicationStatus == "Verified").ToListAsync();

            return Ok(applistdetails);  
        }

[HttpGet("unverifyreport")]
        public async Task<ActionResult> UnverifyReport()
        {
            int count = await _context.tblcap_application
            .Where(s => s.applicationstatus == "Unverified")
            .CountAsync();

            var applistdetails = await (from a in _context.tblcap_application
                                  join stud in _context.tblcap_basicdetails on a.studentid equals stud.studentid
                                
                                 
                                  select new ApplicationDto()
                                  {
                                      ApplicationNo = a.applicationno,
                                      StudentID = stud.studentid,
                                      StudentName = stud.studentname,
                                      FirstOption = a.firstoption,
                                      SecondOption = a.secondoption,
                                      ThirdOption = a.thirdoption,
                                      TenthBoard = a.tenthboard,
                                      TenthInstitution = a.tenthinstitution,
                                      TenthPlace = a.tenthplace,
                                      TenthState = a.tenthstate,
                                      TenthYear = a.tenthyear,
                                      TenthMark = a.tenthmark,
                                      TenthNoOfAttempts = a.tenthnoofattempts,
                                      TwelfthBoard = a.twelfthboard,
                                      TwelfthInstitution = a.twelfthinstitution,
                                      TwelfthPlace = a.twelfthplace,
                                      TwelfthState = a.twelfthstate,
                                      TwelfthYear = a.twelfthyear,
                                      TwelfthMark = a.twelfthmark,
                                      TwelfthNoOfAttempts = a.twelfthnoofattempts,
                                      Date = a.date,
                                      ApplicationStatus = a.applicationstatus

                                  }).Where(x => x.ApplicationStatus == "Unverified").ToListAsync();

            return Ok(applistdetails);  
        }

    }

}

