using System.ComponentModel.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesMovies.Data;
using RazorPagesMovies.models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace RazorPagesMovies.Pages.Movies
{
    public class IndexModel : PageModel
    {
        private readonly RazorPagesMovies.Data.RazorPagesMoviesContext _context;

        public IndexModel(RazorPagesMovies.Data.RazorPagesMoviesContext context)
        {
            _context = context;
        }

        public IList<Movie> Movie { get; set; } = default!;

        [BindProperty(SupportsGet =true)]
        public string TermoBuscar { get; set; } = default!;

        [BindProperty(SupportsGet =true)]
        public string FilmeGeneros { get; set; } = default!;


        public SelectList Generos { get; set; }



        public async Task OnGetAsync()
        {
            var movies =  from m in _context.Movie
                           select m;


            if(!string.IsNullOrWhiteSpace(TermoBuscar))
            {
                movies = movies.Where(m => m.Title.Contains(TermoBuscar));
            }
            if(!string.IsNullOrWhiteSpace(FilmeGeneros))
            {
               movies = movies.Where(m => m.Genero == FilmeGeneros);

            }

            Generos = new SelectList( await _context.Movie.Select(o => o.Genero).Distinct().ToListAsync());
             Movie = await movies.ToListAsync();

        }
    }
}
