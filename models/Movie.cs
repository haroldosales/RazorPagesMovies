using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace RazorPagesMovies.models
{
    public class Movie
    {

     public int Id { get; set; }

     [StringLength(100, MinimumLength =3)]
     [MaxLength(100, ErrorMessage ="Digite o titulo")]
    public string? Title { get; set; }

    [Display(Name = "Data de Lançamento")]
    [DataType(DataType.Date)]
    public DateTime ReleaseDate { get; set; }

    [Required(ErrorMessage = "Digite o genero do filme")]
    [StringLength(30, MinimumLength =3)]
    public string? Genero { get; set; }

    [DataType(DataType.Currency)]
    [Column(TypeName ="decimal(18,12)")]
    public decimal Price { get; set; } =  0;


    [Range(0,10)]
    public int? NotaFilme {get; set;} = 0;
    }
}
