using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using dwdm_pws2_gym.Models;

namespace dwdm_pws2_gym.Data
{
    public class GymContext : DbContext
    {
        public GymContext (DbContextOptions<GymContext> options)
            : base(options)
        {
        }

        public DbSet<dwdm_pws2_gym.Models.Student> Student { get; set; } = default!;
        public DbSet<dwdm_pws2_gym.Models.Sport> Sport { get; set; }
        public DbSet<dwdm_pws2_gym.Models.Registration> Registration { get; set; }
    }
}
