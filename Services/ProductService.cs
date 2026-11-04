using System;
using System.Collections.Generic;
using System.Text;

using SOLIDInventoryDemo.Interfaces;
using SOLIDInventoryDemo.Models;

namespace SOLIDInventoryDemo.Services;

public class ProductService
{
    private readonly IProductReader _reader;
    private readonly IProductWriter _writer;

    public ProductService(
        IProductReader reader,
        IProductWriter writer)
    {
        _reader = reader;
        _writer = writer;
    }

    public void AddProduct(string name, decimal price)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Product name is required.");
        }

        if (price <= 0)
        {
            throw new ArgumentException("Price must be greater than zero.");
        }

        var product = new Product
        {
            Id = _reader.GetAll().Count + 1,
            Name = name,
            Price = price
        };

        _writer.Add(product);
    }

    public List<Product> GetAllProducts()
    {
        return _reader.GetAll();
    }
}
