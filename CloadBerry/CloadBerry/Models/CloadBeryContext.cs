using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CloadBerry.Models
{
    public class CloadBeryContext: DbContext
    {
        public CloadBeryContext(DbContextOptions<CloadBeryContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
    }
}
