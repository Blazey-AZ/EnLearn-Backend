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
    public class FaithController : BaseApiController
    {

        public DataContext _context { get; }
        public FaithController(DataContext context)
        {
            _context = context;
        }

        [HttpPost("religionreg")] //api/faith/religionreg/
        public async Task<ActionResult<ReligionDto>> ReligionDto(ReligionDto religionDto)

        {
            if (await Religion(religionDto.ReligionName)) return BadRequest("Religion already exists!");
            var religion = new religion
            {

                religionname = religionDto.ReligionName,


            };

            _context.tblcap_religion.Add(religion);
            await _context.SaveChangesAsync();

            return religionDto;
        }
        private async Task<bool> Religion(String ReligionName)
        {
            return await _context.tblcap_religion.AnyAsync(x => x.religionname == ReligionName.ToLower());
        }


        [HttpPost("castereg")] //api/faith/castereg/
        public async Task<ActionResult<CasteDto>> CasteReg(CasteDto casteDto)
        {

            religion religionById = await _context.tblcap_religion.FirstOrDefaultAsync(religion => religion.religionname == casteDto.ReligionName);

            if (religionById == null)
                return BadRequest();



            if (await Caste(casteDto.CasteName)) return BadRequest("Caste name already exists!");
            var caste = new caste
            {

                castename = casteDto.CasteName,
                religionid = religionById.religionid,

            };

            _context.tblcap_caste.Add(caste);
            await _context.SaveChangesAsync();

            return casteDto;
        }
        private async Task<bool> Caste(String CasteName)
        {
            return await _context.tblcap_caste.AnyAsync(x => x.castename == CasteName.ToLower());
        }


        [HttpGet(template: "getreligion")]
        public async Task<ActionResult<ReligionDto>> GetRel()
        {
            List<ReligionDto> religionDto = new List<ReligionDto>();

            List<religion> rel = await _context.tblcap_religion.ToListAsync();

            foreach (var item in rel)
            {
                religionDto.Add(new ReligionDto()
                {
                    ReligionID = item.religionid,
                    ReligionName = item.religionname
                });
            }

            return Ok(religionDto);

        }
        [HttpGet("getcaste")]
         public async Task<IEnumerable<CasteDto>> GetCaste()
        {
            var casteList = (from c in _context.tblcap_caste
                                   join r in _context.tblcap_religion on c.religionid equals r.religionid

                                   select new CasteDto()
                                   {
                                       CasteID = c.casteid,
                                       CasteName = c.castename,
                                       ReligionName = r.religionname,
                                      

                                   }).ToListAsync();



            return await casteList;

        }

        [HttpDelete("getcastedelete/{id}")]
        public async Task<ActionResult<caste>> CasteDel(int id)
        {


            var caste = await _context.tblcap_caste.FirstOrDefaultAsync(c => c.casteid == id);

            if (caste == null)
            {
                return NoContent();
            }

            _context.tblcap_caste.Remove(caste);
            await _context.SaveChangesAsync();
            return caste;
        }

        [HttpDelete("getreligiondelete/{id}")]
        public async Task<ActionResult<religion>> RelDel(int id)
        {


            var rel = await _context.tblcap_religion.FirstOrDefaultAsync(r => r.religionid == id);

            if (rel == null)
            {
                return NoContent();
            }

            _context.tblcap_religion.Remove(rel);
            await _context.SaveChangesAsync();
            return rel;
        }

        [HttpPost("editreligion")]
        public async Task<ActionResult<ReligionDto>> RelEdit(ReligionDto religionDto)

        {
            var rel = new religion
            {
                religionid = religionDto.ReligionID,
                religionname = religionDto.ReligionName,



            };

            _context.tblcap_religion.Update(rel);
            await _context.SaveChangesAsync();

            return religionDto;
        }


    




    }

}
