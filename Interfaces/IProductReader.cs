using System;
using System.Collections.Generic;
using System.Text;

using SOLIDInventoryDemo.Models;

namespace SOLIDInventoryDemo.Interfaces;

public interface IProductReader
{
    List<Product> GetAll();
}
