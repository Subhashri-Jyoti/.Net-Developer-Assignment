using System;
using System.Collections.Generic;

namespace Shopping_Products.Models;

public partial class MobileProduct
{
    public int ProductId { get; set; }

    public string? ProductName { get; set; }

    public string? ProductDesc { get; set; }

    public int? Quantity { get; set; }

    public int? ProductPrice { get; set; }
}
