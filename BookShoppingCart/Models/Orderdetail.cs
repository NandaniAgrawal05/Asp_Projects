using System;
using System.Collections.Generic;

namespace BookShoppingCart.Models;

public partial class Orderdetail
{
    public int Id { get; set; }

    public int OrderId { get; set; }

    public int BookId { get; set; }

    public int Quantity { get; set; }

    public double UnitPrice { get; set; }
}
