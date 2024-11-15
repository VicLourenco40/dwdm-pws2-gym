using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using dwdm_pws2_gym.Data;
using dwdm_pws2_gym.Models;

namespace dwdm_pws2_gym.Pages.Students
{
    public class IndexModel : PageModel
    {
        private readonly dwdm_pws2_gym.Data.GymContext _context;

        public IndexModel(dwdm_pws2_gym.Data.GymContext context)
        {
            _context = context;
        }

        public string NameSorting { get; set; }

        public string DateSorting { get; set; }

        public IList<Student> Student { get;set; } = default!;

        public async Task OnGetAsync(string sorting)
        {
            NameSorting = string.IsNullOrEmpty(sorting) ? "name_desc" : "";
            DateSorting = sorting == "date" ? "date_desc" : "date";

            IQueryable<Student> studentIQ = from s in _context.Student select s;

            switch (sorting)
            {
                case "name_desc":
                    studentIQ = studentIQ.OrderByDescending(s => s.FirstName);
                    break;
                case "date":
                    studentIQ = studentIQ.OrderBy(s => s.RegistrationDate);
                    break;
                case "date_desc":
                    studentIQ = studentIQ.OrderByDescending(s => s.RegistrationDate);
                    break;
                default:
                    studentIQ = studentIQ.OrderBy(s => s.FirstName);
                    break;
            }

            Student = await studentIQ.AsNoTracking().ToListAsync();
        }
    }
}
