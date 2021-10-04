using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Movies_Gallery.Entities;
using Movies_Gallery.Models.Dtos;
using Movies_Gallery.ViewModel;

namespace Movies_Gallery.Controllers
{
    public class CommentController : Controller
    {
        private readonly MoviesDbContext _dbContext;
        public CommentController(MoviesDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Comment comment)
        {

            if (ModelState.IsValid)
            {
                _dbContext.Comments.Add(comment);
                await _dbContext.SaveChangesAsync();

                MovieResultsViewModel movieResult = new MovieResultsViewModel()
                {
                    Movie = _dbContext.Movies.Include(x => x.Comments).FirstOrDefault(x => x.Id == comment.MovieId),
                    Comments = _dbContext.Comments.Include(x => x.User).Where(x => x.MovieId == comment.MovieId).ToList(),
                    User = _dbContext.Users.FirstOrDefault(x => x.Id == 2)
                };

                return View("~/Views/Movie/SingleMovie.cshtml", movieResult);
            }

            return View(comment);
        }
    }
}
