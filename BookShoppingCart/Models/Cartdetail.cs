using System;
using System.Collections.Generic;

namespace BookShoppingCart.Models;

public partial class Cartdetail
{
    public int Id { get; set; }

    public int ShoppingCartId { get; set; }

    public int BookId { get; set; }

    public int Quantity { get; set; }
}
