using Packt.Shared;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;

namespace Northwind.Web.Pages
{
	public class CustomersModel : PageModel
    {
        private readonly NorthwindContext _db;
        public ILookup<string?, Customer>? customers;
        public Customer? SelectedCustomer { get; private set; }

        public CustomersModel(NorthwindContext db)
        {
            _db = db;
        }

        public void OnGet()
        {
            ViewData["Title"] = "Northwind B2B - Customers";

            customers = _db.Customers
                           .ToLookup(c => c.Country);
        }

        [HttpPost]
        public IActionResult ViewFullData(Customer customer)
        {
            Console.WriteLine("GO TO FULL DATA");
            SelectedCustomer = customer;
            return RedirectToPage("customerData");
        }
    }
}
