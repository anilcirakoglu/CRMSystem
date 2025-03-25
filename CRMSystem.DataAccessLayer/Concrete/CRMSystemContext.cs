using CRMSystem.EntityLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMSystem.DataAccessLayer.Concrete
{
    public class CRMSystemContext:DbContext
    {
        public CRMSystemContext(DbContextOptions<CRMSystemContext> options) : base(options)
        { 
        }

       
        public DbSet<User> Users { get; set; }
        public DbSet<Customer> Customers { get; set; }
       
    }
}
