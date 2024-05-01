using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace XSISDataAccess.Models;

public partial class Movie
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public double? Rating { get; set; }

    public string? Images { get; set; }

    public DateTime Created_At { get; set; }

    public DateTime? Updated_At { get; set; }
}
