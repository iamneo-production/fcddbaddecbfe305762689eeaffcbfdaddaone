using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace dotnetmicroservicetwo
{
    public class FreelancerDbContext:DbContext
    {
        public FreelancerDbContext(DbContextOptions<FreelancerDbContext> options):base(options)
        {

        }

        public DbSet<Freelancer> freelancer{get;set;}
    }
}