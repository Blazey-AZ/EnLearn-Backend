using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using enlearn.Data;
using enlearn.Entities;
using Microsoft.AspNetCore.Authorization;

namespace enlearn.Controllers
{
    [Authorize]
    public class UsersController : BaseApiController
    {

        private readonly DataContext _context;

        public UsersController(DataContext context)
        {
            _context = context;

        }

        [HttpGet]
        public ActionResult<IEnumerable<principal>> GetUsers()
        {
            var users = _context.tblcap_principal.ToList();

            return users;   
        }
        
        [HttpGet("{id}")]
        public ActionResult<principal> GetUser(int id)
        {
            var user = _context.tblcap_principal.Find(id);

            return user;
        }
    }
}
