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
            catch(System.Exception)
            {
                throw ;
            }
            
        }

        [HttpGet("ProjectTitles")]
        public async Task<List<string>> Get()
        {
            try
            {
                var project=await _context.projects.Select(u=>u.ProjectTitle);
                return project;
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }

        [HttpPost]
        public async Task AddProject(Project pro)
        {
            try
            {
                _context.projects.Add(pro);
                await _context.SaveChangesAsync();
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteProject(int id)
        {
            try
            {
                var pro=await _context.projects.Where(u=>u.ProjectID==id).FirstOrDefault();
                _context.projects.Remove(pro);
                if(_context.SaveChangesAsync()>0)
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