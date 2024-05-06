using System;
using System.Collections.Generic;

namespace BookShoppingCart.Models;

public partial class Genre
{
    public int Id { get; set; }

    public string GenreName { get; set; } = null!;
}
