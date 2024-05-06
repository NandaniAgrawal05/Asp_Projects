using System;
using System.Collections.Generic;

namespace BookShoppingCart.Models;

public partial class Orderstatus
{
    public int Id { get; set; }

    public string StatusName { get; set; } = null!;
}
