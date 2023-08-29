using Packt.Shared;

namespace Northwind.Mvc.Models;

public record HomeIndexViewModel
{
    public int VisitorCount;
    public IList<Category>? Categories;
    public IList<Product>? Products;
}

