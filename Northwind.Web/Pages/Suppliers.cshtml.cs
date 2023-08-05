using Packt.Shared;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;

namespace Northwind.Web.Pages
{
    public class SuppliersModel : PageModel
    {
        private readonly NorthwindContext _db;
        public IEnumerable<Supplier>? Suppliers { get; set; }

        [BindProperty]
        public Supplier? Supplier { get; set; }

        //private readonly ILogger<SuppliersModel> _logger;

        public SuppliersModel(NorthwindContext db /*ILogger<SuppliersModel> logger*/)
        {
            _db = db;
        }

        public void OnGet()
        {
            ViewData["Title"] = "Northwind B2B - Suppliers";

            Suppliers = _db.Suppliers
                .OrderBy(c => c.Country)
                .ThenBy(c => c.CompanyName);
        }

        public IActionResult OnPost()
        {
            if ((Supplier is not null) && ModelState.IsValid)
            {
                _db.Suppliers.Add(Supplier);
                _db.SaveChanges();
                return RedirectToPage("/suppliers");
            }
            else
            {
                return Page();
            }
        }
    }
}