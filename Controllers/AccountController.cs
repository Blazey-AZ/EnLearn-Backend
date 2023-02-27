using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using enlearn.Data;
using enlearn.DTOs;
using enlearn.Entities;
using enlearn.Interfaces;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;
using MimeKit;

namespace enlearn.Controllers
{
    public class AccountController : BaseApiController
    {
        public DataContext _context { get; }
        public AccountController(DataContext context)
        {
            _context = context;
        }

        [HttpPost("register")] //api/account/register/
        public async Task<ActionResult<RegistrationDto>> Register(RegistrationDto registrationDto)

        {
            if (await UserExists(registrationDto.UserName)) return BadRequest("Username is taken");

            var student = new basicdetails
            {
                studentname = registrationDto.StudentName,
                contactnumber = registrationDto.ContactNumber,
                gender = registrationDto.Gender,
                username = registrationDto.UserName,
                password = registrationDto.Password,
                parentcontact = registrationDto.ParentContact
            };

            _context.tblcap_basicdetails.Add(student);
            await _context.SaveChangesAsync();

            return registrationDto;
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            System.Console.WriteLine($"{loginDto.UserName} - {loginDto.Password}");
            var user = await _context.tblcap_basicdetails.FirstOrDefaultAsync(X => X.username == loginDto.UserName && X.password == loginDto.Password);

            if (user == null) return Unauthorized("No User found!");

            return new UserDto
            {
                StudentName = user.studentname,
                ContactNumber = user.contactnumber,
                Gender = user.gender,
                UserName = user.username,
                Password = user.password,
                ParentContact = user.parentcontact,
                StudentID = user.studentid,
            };
        }




        private async Task<bool> UserExists(String UserName)
        {
            return await _context.tblcap_basicdetails.AnyAsync(x => x.username == UserName.ToLower());
        }
        private async Task<bool> InterviewerExists(String UserName)
        {
            return await _context.tblcap_interviewer.AnyAsync(x => x.username == UserName.ToLower());
        }
        private async Task<bool> OfficeExists(String UserName)
        {
            return await _context.tblcap_office.AnyAsync(x => x.username == UserName.ToLower());
        }



        [HttpPost("principallogin")]
        public async Task<ActionResult<PrincipalDto>> AdminLogin(LoginDto loginDto)
        {
            var user = await _context.tblcap_principal.FirstOrDefaultAsync(X => X.username
            == loginDto.UserName);

            var pass = await _context.tblcap_principal.FirstOrDefaultAsync(X => X.password
            == loginDto.Password);

            if (user == null) return Unauthorized("invalid username");
            if (pass == null) return Unauthorized("invalid password");




            return new PrincipalDto
            {
                UserName = user.username,
                Password = user.password,


            };
        }

        [HttpPost("principalregister")] //api/account/principalregister/
        public async Task<ActionResult<PrincipalRegDto>> PrincipalReg(PrincipalRegDto principalregDto)

        {
            if (await UserExists(principalregDto.UserName)) return BadRequest("Username is taken");

            var principal = new principal
            {

                username = principalregDto.UserName,
                password = principalregDto.Password,



            };

            _context.tblcap_principal.Add(principal);
            await _context.SaveChangesAsync();

            return principalregDto;
        }


        [HttpPost("interviewerreg")] //api/account/interviewerreg/
        public async Task<ActionResult<InterviewerDto>> InterviewerReg(InterviewerDto interviewerDto)

        {
            if (await InterviewerExists(interviewerDto.Username)) return BadRequest("Username is taken");

            var interviewer = new interviewer
            {
                name = interviewerDto.InterviewerName,
                username = interviewerDto.Username,
                password = interviewerDto.Password,
                contact = interviewerDto.Contact,
                department = interviewerDto.Department,
                email = interviewerDto.Email



            };

            _context.tblcap_interviewer.Add(interviewer);
            await _context.SaveChangesAsync();

            return interviewerDto;

        }


        [HttpPost("officereg")] //api/account/officereg/
        public async Task<ActionResult<OfficeDto>> OfficeReg(OfficeDto officeDto)

        {
            if (await OfficeExists(officeDto.Username)) return BadRequest("Username is taken");

            var office = new office
            {
                staffincharge = officeDto.StaffInCharge,
                username = officeDto.Username,
                password = officeDto.Password,
                comment = officeDto.Comment



            };

            _context.tblcap_office.Add(office);
            await _context.SaveChangesAsync();

            return officeDto;

        }

        [HttpPost(template: "officelogin")]
        public async Task<ActionResult<OfficeDto>> OfficeLogin(OfficeDto officeDto)
        {
            var user = await _context.tblcap_office.FirstOrDefaultAsync(X => X.username
            == officeDto.Username);

            var pass = await _context.tblcap_office.FirstOrDefaultAsync(X => X.password
            == officeDto.Password);

            if (user == null) return Unauthorized("invalid username");
            if (pass == null) return Unauthorized("invalid password");




            return new OfficeDto
            {
                OfficeID = user.officeid,
                StaffInCharge = user.staffincharge,
                Username = user.username,
                Password = pass.password,


            };
        }



        [HttpPost(template: "interviewerlogin")]
        public async Task<ActionResult<InterviewerDto>> InterviewerLogin(LoginDto loginDto)
        {
            var user = await _context.tblcap_interviewer.FirstOrDefaultAsync(X => X.username
            == loginDto.UserName);

            var pass = await _context.tblcap_interviewer.FirstOrDefaultAsync(X => X.password
            == loginDto.Password);

            if (user == null) return Unauthorized("invalid username");
            if (pass == null) return Unauthorized("invalid password");




            return new InterviewerDto
            {
                InterviewerID = user.interviewerid,
                Username = user.username,
                Password = user.password,


            };
        }


        [HttpGet("getinterviewers")]
        public async Task<ActionResult<InterviewerDto>> GetInterviewers()
        {
            List<InterviewerDto> interviewerDto = new List<InterviewerDto>();

            List<interviewer> users = await _context.tblcap_interviewer.ToListAsync();

            foreach (var item in users)
            {
                interviewerDto.Add(new InterviewerDto()
                {
                    InterviewerID = item.interviewerid,
                    InterviewerName = item.name,
                    Contact = item.contact,
                    Department = item.department,
                    Email = item.email,
                });
            }

            return Ok(interviewerDto);
        }

        [HttpGet("getoffice")]
        public async Task<ActionResult<OfficeDto>> GetOffice()
        {
            List<OfficeDto> OfficeDto = new List<OfficeDto>();

            List<office> users = await _context.tblcap_office.ToListAsync();

            foreach (var item in users)
            {
                OfficeDto.Add(new OfficeDto()
                {
                    OfficeID = item.officeid,
                    StaffInCharge = item.staffincharge,

                });
            }

            return Ok(OfficeDto);
        }


        [HttpGet("getusers")]
        public async Task<ActionResult<UserDto>> GetStudents()
        {
            List<UserDto> userDto = new List<UserDto>();

            List<basicdetails> users = await _context.tblcap_basicdetails.ToListAsync();

            foreach (var item in users)
            {
                userDto.Add(new UserDto()
                {
                    StudentID = item.studentid,
                    StudentName = item.studentname,
                    ContactNumber = item.contactnumber,
                    Gender = item.gender,
                    ParentContact = item.parentcontact,
                });
            }

            return Ok(userDto);
        }



        [HttpGet("getuser/{id}")]
        public async Task<ActionResult<personaldetails>> GetUser(int id)
        {


            var course = await _context.tblcap_personaldetails.FirstOrDefaultAsync(c => c.studentid == id);

            if (course == null)
                return NoContent();

            return course;

        }

        [HttpGet("getpersonalinfoall/{id}")]
        public async Task<IEnumerable<PersonalDetailsDto>> GetPersonalInfoAll(int id)
        {
            var detailsList = (from d in _context.tblcap_personaldetails
                               join rel in _context.tblcap_religion on d.religionid equals rel.religionid
                               join st in _context.tblcap_state on d.stateid equals st.stateid
                               join cas in _context.tblcap_caste on d.casteid equals cas.casteid
                               join dist in _context.tblcap_district on d.districtid equals dist.districtid
                               join stu in _context.tblcap_basicdetails on d.studentid equals stu.studentid
                               where stu.studentid == id

                               select new PersonalDetailsDto()
                               {
                                   PersonalID = d.personalid,
                                   StudentID = stu.studentid,
                                   StudentName = stu.studentname,
                                   Image = d.image,
                                   NameOfFather = d.nameoffather,
                                   DateOfBirth = d.dateofbirth,
                                   Nationality = d.nationality,
                                   AnnualIncome = d.annualincome,
                                   HouseName = d.housename,
                                   Place = d.place,
                                   ReligionName = rel.religionname,
                                   CasteName = cas.castename,
                                   StateName = st.statename,
                                   DistrictName = dist.districtname,
                                   Pincode = d.pincode,
                                   Email = d.email

                               }).ToListAsync();



            return await detailsList;
        }

        [HttpDelete("interviewerdelete/{id}")]
        public async Task<ActionResult<interviewer>> InDel(int id)
        {


            var rel = await _context.tblcap_interviewer.FirstOrDefaultAsync(r => r.interviewerid == id);

            if (rel == null)
            {
                return NoContent();
            }

            _context.tblcap_interviewer.Remove(rel);
            await _context.SaveChangesAsync();
            return rel;
        }

        [HttpDelete("officedel/{id}")]
        public async Task<ActionResult<office>> OfficeDel(int id)
        {


            var rel = await _context.tblcap_office.FirstOrDefaultAsync(r => r.officeid == id);

            if (rel == null)
            {
                return NoContent();
            }

            _context.tblcap_office.Remove(rel);
            await _context.SaveChangesAsync();
            return rel;
        }


        [HttpGet("email")]
        public IActionResult Sendmail()
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse("jaren.okeefe10@ethereal.email"));
            email.To.Add(MailboxAddress.Parse("jaren.okeefe10@ethereal.email"));

            email.Subject = "You have mail!";
            email.Body = new TextPart("plain") { Text = "You have been enrolled into xxxxx gakuen!" };

            using var smtp = new SmtpClient();
            smtp.Connect("smtp.ethereal.email", 587, MailKit.Security.SecureSocketOptions.StartTls);
            smtp.Authenticate("jaren.okeefe10@ethereal.email", "5yFEDMH1fqAkU1kFuk");
            smtp.Send(email);
            smtp.Disconnect(true);


            return Ok();
        }



        




    }
}
