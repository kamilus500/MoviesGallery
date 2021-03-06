using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Movies_Gallery.Entities;
using Movies_Gallery.Models.Dtos;
using Movies_Gallery.ViewModel;
using System.IO;
using System.Linq;

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
            var comments = _dbContext.Comments.Where(x => x.MovieId == id).Include(x=>x.User).OrderByDescending(x => x.ReleaseCreate).ToList();

            MovieResultsViewModel movieResult = new MovieResultsViewModel()
            {
                Movie = movie,
                Comments = comments
            };

            return View(movieResult);
        }

        [Authorize]
        public IActionResult Create()
        {

            return View();
        }

        [Authorize]
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
