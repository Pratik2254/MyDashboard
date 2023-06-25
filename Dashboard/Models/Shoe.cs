using System;
using System.Collections.Generic;

namespace Dashboard.Models;

public partial class Shoe
{
    public int ShoesId { get; set; }

    public string? Name { get; set; }

    public decimal? Price { get; set; }

    public string? Quantity { get; set; }

    public string? Brand { get; set; }

    public DateTime? AddedDate { get; set; }
}
