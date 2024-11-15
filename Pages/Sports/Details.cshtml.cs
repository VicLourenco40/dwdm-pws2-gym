using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using dwdm_pws2_gym.Data;
using dwdm_pws2_gym.Models;

namespace dwdm_pws2_gym.Pages.Sports
{
    public class DetailsModel : PageModel
    {
        private readonly dwdm_pws2_gym.Data.GymContext _context;

        public DetailsModel(dwdm_pws2_gym.Data.GymContext context)
        {
            _context = context;
        }

        public Sport Sport { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sport = await _context.Sport.FirstOrDefaultAsync(m => m.Id == id);

            if (sport is not null)
            {
                Sport = sport;

                return Page();
            }

            return NotFound();
        }
    }
}
