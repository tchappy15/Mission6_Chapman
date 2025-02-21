using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Mission6_Chapman.Models;

public class Category
{

    [Key]
    [Required]
    public int CategoryId { get; set; }

    public required string CategoryName { get; set; }
}
