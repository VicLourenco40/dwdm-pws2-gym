using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using dwdm_pws2_gym.Data;
using dwdm_pws2_gym.Models;

namespace dwdm_pws2_gym.Pages.Registrations
{
    public class IndexModel : PageModel
    {
        private readonly dwdm_pws2_gym.Data.GymContext _context;

        public IndexModel(dwdm_pws2_gym.Data.GymContext context)
        {
            _context = context;
        }

        public IList<Registration> Registration { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Registration = await _context.Registration
                .Include(r => r.Sport)
                .Include(r => r.Student).ToListAsync();
        }
    }
}
