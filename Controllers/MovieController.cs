using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Movies_Gallery.Entities;
using Movies_Gallery.Models.Dtos;
using Movies_Gallery.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Movies_Gallery.Controllers
{
    public class MovieController : Controller
    {
        private readonly MoviesDbContext _dbContext;
        private readonly IMapper _mapper;

        public MovieController(MoviesDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public IActionResult Index()
        {

            var movies = _dbContext.Movies.ToList();

            return View(movies);
        }

        public IActionResult SingleMovie(int id)
        {

            var movie = _dbContext.Movies.Include(x=>x.Comments).FirstOrDefault(x => x.Id == id);
            var comments = _dbContext.Comments.Include(x=>x.User).Where(x => x.MovieId == id).ToList();
            var user = _dbContext.Users.FirstOrDefault(x => x.Id == 2);

            MovieResultsViewModel movieResult = new MovieResultsViewModel()
            {
                Movie = movie,
                Comments = comments,
                User = user
            };

            return View(movieResult);
        }

        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(MovieDto movieDto)
        {

            if(!ModelState.IsValid)
            {
                return View(movieDto);
            }

            var fileName = Path.GetFileName(movieDto.Image.FileName);

            var filePath = Path.Combine(@"C:\Users\LanowY\Desktop\c# projects\Movie_Gallery_MVC\Movies_Gallery\Movies_Gallery\wwwroot\img\", $"{fileName}");

            movieDto.Image.CopyTo(new FileStream(filePath, FileMode.Create));

            var movie = _mapper.Map<Movie>(movieDto);

            _dbContext.Movies.Add(movie);
            _dbContext.SaveChanges();

            return View(nameof(Index), _dbContext.Movies.ToList());
        }
    }
}
