using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using dwdm_pws2_gym.Data;
using dwdm_pws2_gym.Models;

namespace dwdm_pws2_gym.Pages.Sports
{
    public class CreateModel : PageModel
    {
        private readonly dwdm_pws2_gym.Data.GymContext _context;

        public CreateModel(dwdm_pws2_gym.Data.GymContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Sport Sport { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Sport.Add(Sport);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
