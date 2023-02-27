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
    public class LocationController : BaseApiController
    {
         public DataContext _context { get; }
        public LocationController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("getstate")]
        public async Task<ActionResult<StateDto>> GetState(){
            List<StateDto> stateDtos = new List<StateDto>();

            List<state> states = await _context.tblcap_state.ToListAsync();

            foreach (var item in states)
            {
                stateDtos.Add(new StateDto() {
                    StateID = item.stateid,
                    StateName = item.statename
                });
            }

            return Ok(stateDtos);

        }
        
         [HttpPost("statereg")] //api/location/statereg/
        public async Task<ActionResult<StateDto>> StateReg(StateDto stateDto)

        {
 if (await State(stateDto.StateName)) return BadRequest("Statename already exists!");
            var state = new state
            {
                
                statename = stateDto.StateName,


            };

            _context.tblcap_state.Add(state);
            await _context.SaveChangesAsync();

            return stateDto;
        }
         private async Task<bool> State(String StateName)
        {
            return await _context.tblcap_state.AnyAsync(x => x.statename == StateName.ToLower());
        }


         [HttpPost("districtreg")] //api/location/districtreg/
        public async Task<ActionResult<DistrictDto>> DistrictReg(DistrictDto districtDto)
        {

            state stateById = await _context.tblcap_state.FirstOrDefaultAsync(state => state.statename == districtDto.StateName);

            if(stateById == null)
                return BadRequest();



            if (await District(districtDto.DistrictName)) return BadRequest("District name already exists!");
            var district = new district
            {
                
                districtname = districtDto.DistrictName,
                stateid = stateById.stateid,

            };

            _context.tblcap_district.Add(district);
            await _context.SaveChangesAsync();

            return districtDto;
        }
         private async Task<bool> District(String DistrictName)
        {
            return await _context.tblcap_district.AnyAsync(x => x.districtname == DistrictName.ToLower());
        }


        [HttpDelete("statedelete/{id}")]
        public async Task<ActionResult<state>> StateDel(int id)
        {


            var st = await _context.tblcap_state.FirstOrDefaultAsync(r => r.stateid == id);

            if (st == null)
            {
                return NoContent();
            }

            _context.tblcap_state.Remove(st);
            await _context.SaveChangesAsync();
            return st;
        }

        [HttpDelete("districtdelete/{id}")]
        public async Task<ActionResult<district>> DistDel(int id)
        {


            var dt = await _context.tblcap_district.FirstOrDefaultAsync(r => r.districtid == id);

            if (dt == null)
            {
                return NoContent();
            }

            _context.tblcap_district.Remove(dt);
            await _context.SaveChangesAsync();
            return dt;
        }

         [HttpPost(template: "editstate")]
        public async Task<ActionResult<StateDto>> StateDel(StateDto stateDto)

        {
            var state = new state
            {
                stateid = stateDto.StateID,
                statename = stateDto.StateName,



            };

            _context.tblcap_state.Update(state);
            await _context.SaveChangesAsync();

            return stateDto;
        }


        [HttpGet("getdistrict")]
        public async Task<IEnumerable<DistrictDto>> GetDist()
        {
            var districtList = (from d in _context.tblcap_district
                                   join s in _context.tblcap_state on d.stateid equals s.stateid

                                   select new DistrictDto()
                                   {
                                       DistrictID = d.districtid,
                                       DistrictName = d.districtname,
                                       StateName = s.statename,
                                      

                                   }).ToListAsync();



            return await districtList;



        }

        
    }
}