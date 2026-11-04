using System;
using System.Collections.Generic;
using System.Text;

using SOLIDInventoryDemo.Interfaces;
using SOLIDInventoryDemo.Models;

namespace SOLIDInventoryDemo.Repositories;

public class InMemoryProductRepository : IProductReader, IProductWriter
{
    private readonly List<Product> _products = new();

    public void Add(Product product)
    {
        _products.Add(product);
    }

    public List<Product> GetAll()
    {
        return _products.ToList();
    }
}
