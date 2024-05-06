using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;

namespace BookShoppingCart.Models;

[Authorize(Roles="Admin")]
public partial class Shoppingcart
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public bool IsDeleted { get; set; }
}
