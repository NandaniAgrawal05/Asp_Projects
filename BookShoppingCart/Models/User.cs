using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookShoppingCart.Models;

public partial class User
{
    [Required]
    public int Id { get; set; }
    [Required]
    public string? UserName { get; set; }
    [Required]
    public string? Password { get; set; }
}
