using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using enlearn.Data;
using enlearn.DTOs;
using enlearn.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace enlearn.Controllers
{
    public class ParentController : BaseApiController
    {
        public DataContext _context { get; }
        private readonly IWebHostEnvironment _environment;
        public ParentController(DataContext context, IWebHostEnvironment environment)
        {
            this._context = context;
            this._environment = environment;
        }







        [HttpPost("parentreg")] //api/parent/parentreg/
        public async Task<ActionResult<ParentDto>> ParentReg(ParentDto parentDto)

        {



            if (await ParentExists(parentDto.studentID)) return BadRequest("parent details already exists");

            var parent = new parent
            {
                parentid = parentDto.parentID,
                studentid = parentDto.studentID,
                father = parentDto.Father,
                mother = parentDto.Mother,
                fcontact = parentDto.FContact,
                mcontact = parentDto.MContact,
                foccuption = parentDto.FOccupation,
                moccuption = parentDto.MOccupation,



            };

            _context.tblcap_parent.Add(parent);
            await _context.SaveChangesAsync();

            return parentDto;
        }
        private async Task<bool> ParentExists(int studentID)
        {
            return await _context.tblcap_parent.AnyAsync(x => x.studentid == studentID);
        }


        [HttpGet("viewparentinfo")]
        public async Task<IEnumerable<ParentDto>> GetParentInfo()
        {
            var parentdetail = (from p in _context.tblcap_parent
                                join stud in _context.tblcap_basicdetails on p.studentid equals stud.studentid


                                select new ParentDto()
                                {
                                    parentID = p.parentid,
                                    studentID = stud.studentid,
                                    studentName = stud.studentname,
                                    Father = p.father,
                                    Mother = p.mother,
                                    FOccupation = p.foccuption,
                                    MOccupation = p.moccuption,
                                    FContact = p.fcontact,
                                    MContact = p.mcontact,

                                }).ToListAsync();



            return await parentdetail;



        }


    }
}