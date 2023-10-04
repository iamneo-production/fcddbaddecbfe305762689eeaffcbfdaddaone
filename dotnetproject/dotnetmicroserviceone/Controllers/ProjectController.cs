using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace dotnetmicroserviceone.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectController : ControllerBase
    {
        private readonly ProjectDbContext _context;
        public ProjectController(ProjectDbContext context)
        {
            _context=context;
        } 

        [HttpGet]
        public async Task<List<Project>> GetAllAProjects()
        {
            try
            {   
                return await _context.projects.ToListAsync();
            }
            catch(Exception ex)
            {
                throw ;
            }
            
        }

        [HttpGet("ProjectTitles")]
        public async Task<string>

    }
}