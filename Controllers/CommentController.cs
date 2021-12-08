using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Movies_Gallery.Entities;
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

        [Authorize]
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
                    Comments = _dbContext.Comments.Where(x => x.MovieId == comment.MovieId).Include(x=>x.User).OrderByDescending(x => x.ReleaseCreate).ToList()
                };

                return View("~/Views/Movie/SingleMovie.cshtml", movieResult);
            }

            return View("~/Views/Shared/_CommentBox.cshtml",comment);
        }
    }
}
