using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using coreModel;
using coreModel.Model;
using corekatmanproje.Models;

namespace coreData.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Duty> dutys { get; set; }
        public DbSet<Employee> employees { get; set; }
        public DbSet<Kids> kids { get; set; }
        public DbSet<Project> projects { get; set; }
        public DbSet<Title> titles { get; set; }
        public DbSet<Units> units { get; set; }

    }
   

    
}
