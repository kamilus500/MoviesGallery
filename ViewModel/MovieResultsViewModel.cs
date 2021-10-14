using Microsoft.AspNetCore.Identity;
using Movies_Gallery.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies_Gallery.ViewModel
{
    public class MovieResultsViewModel
    {
        public Movie Movie { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
