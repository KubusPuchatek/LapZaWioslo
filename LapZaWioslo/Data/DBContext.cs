using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LapZaWioslo.Models;

namespace LapZaWioslo.Data
{
    public class DBContext : DbContext
    {
        public DBContext (DbContextOptions<DBContext> options)
            : base(options)
        {
        }

        public DbSet<LapZaWioslo.Models.EventInformation> EventInformation { get; set; }

        public DbSet<LapZaWioslo.Models.Participant> Participant { get; set; }
    }
}
