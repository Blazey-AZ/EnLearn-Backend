using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using enlearn.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace enlearn.Controllers
{
    public class InterviewerController : BaseApiController
    {
        public DataContext _context { get; }
        public InterviewerController(DataContext context)
        {
            _context = context;
        }

         [HttpPost("passed/{id}")]
        public async Task<ActionResult> Pass(int id)
        {
            var application = await _context.tblcap_application
            .FirstOrDefaultAsync(a => a.applicationno == id);
            if (application == null)
                return NoContent();

                application.applicationstatus = "Passed";
            await _context.SaveChangesAsync();
            return Ok(true);
        }


        [HttpPost("failed/{id}")]
        public async Task<ActionResult> Fail(int id)
        {
            var application = await _context.tblcap_application
            .FirstOrDefaultAsync(a => a.applicationno == id);
            if (application == null)
                return NoContent();



            application.applicationstatus = "Failed";
            await _context.SaveChangesAsync();
            return Ok(false);
        }

    }
}