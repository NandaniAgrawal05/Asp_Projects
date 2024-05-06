using System;
using System.Collections.Generic;

namespace BookShoppingCart.Models;

public partial class Order
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public DateTime CreateDate { get; set; }

    public int OrderStatusId { get; set; }

    public bool IsDeleted { get; set; }
}
