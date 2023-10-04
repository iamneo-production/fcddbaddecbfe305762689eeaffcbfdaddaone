using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameWork.Core

namespace dotnetmicroserviceone
{
    public class FreelancerDbContext:DbContext
    {
        public FreelancerDbContext(DbContextOptions<FreelancerDbContext> options):base(options)
        {

        }

        public DbSet<>
    }
}