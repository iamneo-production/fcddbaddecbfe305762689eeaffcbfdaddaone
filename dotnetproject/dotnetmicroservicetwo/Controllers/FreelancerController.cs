using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace dotnetmicroservicetwo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FreelancerController : ControllerBase
    {
        private readonly FreelancerDbContext _context;
        public FreelancerController(FreelancerDbContext context)
        {
            _context=context;
        }

        [HttpGet]
        public async Task<IEnumerable<Freelancer>> GetAllFreelancers
    }
}