using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace dotnetmicroserviceone
{
    public class ProjectDbContext:DbContext
    {
        public ProjectDbContext(DbContextOptions<ProjectDbContext> options):base(options)
        {}

        public DbSet<Project> projects{get;set;}
    }
}