using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission6_Chapman.Models;

public class Movie
{
    //this will becomes a table with our various fields in it

    //Column names:	Category	Title	Year	Director	Rating	Edited	Lent To Copied to Plex	Notes

    [Key]
    [Required] 
    public int MovieId { get; set; } //PK. 

    [Required(ErrorMessage = "Category is required.")]
    public int CategoryId { get; set; }

    [ForeignKey("CategoryId")]
    public Category? Category { get; set; } //attatch a public instance of category and call it category

    [Required(ErrorMessage = "Title is required.")]
    public string Title { get; set; }

    [Required(ErrorMessage = "Year is required.")]
    [Range(1888, int.MaxValue, ErrorMessage = "Year must be 1888 or later.")]
    public int Year { get; set; } = 2;

    //[Required(ErrorMessage = "Director is required.")]
    public string? Director { get; set; }

    //[Required(ErrorMessage = "Rating is required.")]
    public string Rating { get; set; }

    [Required(ErrorMessage = "Edited is required.")]
    public int Edited { get; set; }

    public string? LentTo { get; set; }

    [Required(ErrorMessage = "CopiedToPlex is required.")]
    public int CopiedToPlex { get; set; }

    [StringLength(25, ErrorMessage = "Notes cannot exceed 25 characters.")]
    public string? Notes { get; set; }
    }
