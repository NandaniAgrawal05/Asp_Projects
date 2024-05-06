using System;
using System.Collections.Generic;

namespace BookShoppingCart.Models;

public partial class Book
{
    public int Id { get; set; }

    public string? BookName { get; set; }

    public double? Price { get; set; }

    public string? Image { get; set; }

    public int? GenreId { get; set; }
}
