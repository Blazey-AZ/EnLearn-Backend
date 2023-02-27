using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using enlearn.Data;
using enlearn.DTOs;
using enlearn.Entities;
using enlearn.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;

namespace enlearn.Controllers
{
    public class PersonalDetailController : BaseApiController
    {

        public DataContext _context { get; }
        private readonly IWebHostEnvironment _environment;
        public PersonalDetailController(DataContext context, IWebHostEnvironment environment)
        {
            this._context = context;
            this._environment = environment;
        }







        [HttpPost("register")] //api/personaldetail/register/
        public async Task<ActionResult<PersonalDetailsDto>> DetailsRegister(PersonalDetailsDto personaldetailDto)

        {
            religion religionById = await _context.tblcap_religion.FirstOrDefaultAsync(religion => religion.religionname == personaldetailDto.ReligionName);

            if (religionById == null)
                return BadRequest();


            caste casteById = await _context.tblcap_caste.FirstOrDefaultAsync(caste => caste.castename == personaldetailDto.CasteName);

            if (casteById == null)
                return BadRequest();

            state stateById = await _context.tblcap_state.FirstOrDefaultAsync(state => state.statename == personaldetailDto.StateName);

            if (stateById == null)
                return BadRequest();

            district districtById = await _context.tblcap_district.FirstOrDefaultAsync(district => district.districtname == personaldetailDto.DistrictName);

            if (districtById == null)
                return BadRequest();

            if (await PersonalDetailsExists(personaldetailDto.StudentID)) return BadRequest("personal details already exists");

            var student = new personaldetails
            {
                personalid = personaldetailDto.PersonalID,
                studentid = personaldetailDto.StudentID,
                image = personaldetailDto.Image,
                nameoffather = personaldetailDto.NameOfFather,
                dateofbirth = personaldetailDto.DateOfBirth,
                nationality = personaldetailDto.Nationality,
                annualincome = personaldetailDto.AnnualIncome,

                religionid = religionById.religionid,
                casteid = casteById.casteid,
                stateid = stateById.stateid,
                districtid = districtById.districtid,

                housename = personaldetailDto.HouseName,
                place = personaldetailDto.Place,
                pincode = personaldetailDto.Pincode,
                email = personaldetailDto.Email

            };

            _context.tblcap_personaldetails.Add(student);
            await _context.SaveChangesAsync();

            return personaldetailDto;
        }
        private async Task<bool> PersonalDetailsExists(int StudentID)
        {
            return await _context.tblcap_personaldetails.AnyAsync(x => x.studentid == StudentID);
        }


        [HttpGet("getcaste")]
        public async Task<ActionResult<CasteDto>> GetCaste()
        {
            List<CasteDto> casteDto = new List<CasteDto>();

            List<caste> caste = await _context.tblcap_caste.ToListAsync();

            foreach (var item in caste)
            {
                casteDto.Add(new CasteDto()
                {
                    CasteName = item.castename,

                });
            }

            return Ok(casteDto);

        }

        [HttpGet("getreligion")]
        public async Task<ActionResult<ReligionDto>> GetReligion()
        {
            List<ReligionDto> religionDto = new List<ReligionDto>();

            List<religion> religion = await _context.tblcap_religion.ToListAsync();

            foreach (var item in religion)
            {
                religionDto.Add(new ReligionDto()
                {

                    ReligionName = item.religionname
                });
            }

            return Ok(religionDto);

        }

        [HttpGet("getstate")]
        public async Task<ActionResult<StateDto>> GetState()
        {
            List<StateDto> stateDtos = new List<StateDto>();

            List<state> states = await _context.tblcap_state.ToListAsync();

            foreach (var item in states)
            {
                stateDtos.Add(new StateDto()
                {
                    StateName = item.statename
                });
            }

            return Ok(stateDtos);

        }
        [HttpGet("getdistrict")]
        public async Task<ActionResult<DistrictDto>> GetDistrict()
        {
            List<DistrictDto> districtDto = new List<DistrictDto>();

            List<district> district = await _context.tblcap_district.ToListAsync();

            foreach (var item in district)
            {
                districtDto.Add(new DistrictDto()
                {
                    DistrictName = item.districtname
                });
            }

            return Ok(districtDto);

        }

        [HttpGet("getreligionbyname/{name}")]
        public async Task<List<string>> ReligionByName(string name)
        {
            return await _context.tblcap_caste.Include(x => x.religion).Where(x => x.religion.religionname == name).Select(x => x.castename).ToListAsync();
        }

        [HttpGet("getstatebyname/{name}")]
        public async Task<List<string>> StateByName(string name)
        {
            return await _context.tblcap_district.Include(x => x.state).Where(x => x.state.statename == name).Select(x => x.districtname).ToListAsync();
        }






        [HttpPost("uploadimage"), DisableRequestSizeLimit]
        public async Task<ActionResult> UploadImage()
        {
            try
            {
                var file = Request.Form.Files[0];
                var folderName = Path.Combine("Resources", "Images");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

                if (file.Length > 0)
                {
                    var fileName = System.Net.Http.Headers.ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var fullPath = Path.Combine(pathToSave, fileName);
                    var dbPath = Path.Combine(folderName, fileName);

                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                    return Ok(new { dbPath });
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex}");
            }




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


        [HttpGet("viewpersonalinfo")]
        public async Task<IEnumerable<PersonalDetailsDto>> GetPersonalDetail()
        {
            var personaldetaillist = (from p in _context.tblcap_personaldetails
                                      join stud in _context.tblcap_basicdetails on p.studentid equals stud.studentid
                                      
                                      join rel in _context.tblcap_religion on p.religionid equals rel.religionid
                                      join st in _context.tblcap_state on p.stateid equals st.stateid
                                      join cas in _context.tblcap_caste on p.casteid equals cas.casteid
                                      join dist in _context.tblcap_district on p.districtid equals dist.districtid
                                      select new PersonalDetailsDto()
                                      {
                                          PersonalID = p.personalid,
                                          StudentID = stud.studentid,
                                          StudentName = stud.studentname,
                                          Image = p.image,
                                          NameOfFather = p.nameoffather,
                                          DateOfBirth = p.dateofbirth,
                                          Nationality = p.nationality,
                                          AnnualIncome = p.annualincome,
                                          HouseName = p.housename,
                                          Place = p.place,
                                          ReligionName = rel.religionname,
                                          CasteName = cas.castename,
                                          StateName = st.statename,
                                          DistrictName = dist.districtname,
                                          Pincode = p.pincode,
                                          Email = p.email

                                      }).ToListAsync();



            return await personaldetaillist;



        }




    }
}