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
    public class IndexModel : PageModel
    {
        private readonly MyApp.Data.ApplicationDbContext _context;

        public IndexModel(MyApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Person> Person { get; set; } = new List<Person>();

        [BindProperty(SupportsGet = true)]
        public string Search { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SortBy { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SortOrder { get; set; } = "asc";

        public async Task OnGetAsync()
        {
            // Start query
            IQueryable<Person> query = _context.Person;

            // Apply search filter
            if (!string.IsNullOrEmpty(Search))
            {
                query = query.Where(p =>
                    p.FirstName.Contains(Search) ||
                    p.LastName.Contains(Search) ||
                    p.Email.Contains(Search));
            }

            // Apply sorting
            query = SortBy switch
            {
                "FirstName" => SortOrder == "asc" ? query.OrderBy(p => p.FirstName) : query.OrderByDescending(p => p.FirstName),
                "LastName" => SortOrder == "asc" ? query.OrderBy(p => p.LastName) : query.OrderByDescending(p => p.LastName),
                "Email" => SortOrder == "asc" ? query.OrderBy(p => p.Email) : query.OrderByDescending(p => p.Email),
                _ => query.OrderBy(p => p.FirstName), // Default sorting by FirstName
            };

            // Fetch the records based on the current query (no pagination)
            Person = await query.ToListAsync();
        }
    }
}