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
        public async Task<ActionResult<IEnumerable<Freelancer>>> GetAllFreelancers()
        {
            try
            {
                var freelancers=await _context.freelancer.ToListAsync();
                return Ok(freelancers);
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Freelancer>> GetFreelancerById(int id)
        {
            try
            {
                var freelancer=await _context.freelancer.FirstOrDefaultAsync(u=>u.FreelancerID==id);
                return Ok(freelancer);
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }
        [HttpPost]
        public async Task<ActionResult> AddProject(Freelancer _freelancer)
        {
            try
            {
                _context.freelancer.Add(_freelancer);
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProject(int id)
        {
            try
            {
                var pro=await _context.freelancer.Where(u=>u.FreelancerID==id).FirstOrDefaultAsync();
                _context.freelancer.Remove(pro);
                if(await _context.SaveChangesAsync()>0)
                {
                    return Ok();
                }
                else
                {
                    return NotFound();
                }
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }
    }
}