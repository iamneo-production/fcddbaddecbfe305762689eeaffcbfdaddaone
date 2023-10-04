using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        public async Task<ActionResult<IEnumerable<Project>>> GetAllAProjects()
        {
            try
            {   
                var pro=await _context.projects.ToListAsync();
                return Ok(pro);
            }
            catch(System.Exception)
            {
                throw ;
            }
            
        }

        [HttpGet("ProjectTitles")]
        public async Task<ActionResult<IEnumerable<string>>> Get()
        {
            try
            {
                var project=await _context.projects.Select(u=>u.ProjectTitle).ToListAsync();
                return Ok(project);
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }

        [HttpPost]
        public async Task<ActionResult> AddProject(Project pro)
        {
            try
            {
                _context.projects.Add(pro);
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
                var pro=await _context.projects.Where(u=>u.ProjectID==id).FirstOrDefaultAsync();
                _context.projects.Remove(pro);
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