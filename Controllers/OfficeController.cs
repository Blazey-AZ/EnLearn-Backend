using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using enlearn.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace enlearn.Controllers
{
    public class OfficeController : BaseApiController
    {
        public DataContext _context { get; }
        public OfficeController(DataContext context)
        {
            _context = context;
        }

        [HttpPost("enroll/{id}")]
        public async Task<ActionResult> Pass(int id)
        {
            var application = await _context.tblcap_application
            .FirstOrDefaultAsync(a => a.applicationno == id);
            if (application == null)
                return NoContent();

            application.applicationstatus = "Enroll";
            await _context.SaveChangesAsync();
            return Ok(true);
        }


        [HttpPost("reject/{id}")]
        public async Task<ActionResult> Fail(int id)
        {
            var application = await _context.tblcap_application
            .FirstOrDefaultAsync(a => a.applicationno == id);
            if (application == null)
                return NoContent();



            application.applicationstatus = "Reject";
            await _context.SaveChangesAsync();
            return Ok(false);
        }

    }
}
