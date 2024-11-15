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
    public class DetailsModel : PageModel
    {
        private readonly dwdm_pws2_gym.Data.GymContext _context;

        public DetailsModel(dwdm_pws2_gym.Data.GymContext context)
        {
            _context = context;
        }

        public Registration Registration { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registration = await _context.Registration.FirstOrDefaultAsync(m => m.Id == id);

            if (registration is not null)
            {
                Registration = registration;

                return Page();
            }

            return NotFound();
        }
    }
}
