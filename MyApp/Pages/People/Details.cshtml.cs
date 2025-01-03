using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyApp.Data;
using MyApp.Models;

namespace MyApp.Pages.People
{
    public class DetailsModel : PageModel
    {
        private readonly MyApp.Data.ApplicationDbContext _context;

        public DetailsModel(MyApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Person Person { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var person = await _context.Person.FirstOrDefaultAsync(m => m.Id == id);
            if (person == null)
            {
                return NotFound();
            }
            else
            {
                Person = person;
            }
            return Page();
        }
    }
}
