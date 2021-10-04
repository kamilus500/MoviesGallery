using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Movies_Gallery.Entities
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Title")]
        [Required(ErrorMessage = "Please type title")]
        public string Title { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Release Year")]
        [Required(ErrorMessage = "Please type release year")]
        public DateTime ReleaseYear { get; set; }

        [DataType(DataType.Duration)]
        [Display(Name = "Duration")]
        [Required(ErrorMessage = "Please type duration on movie")]
        public double Duration { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Directorr")]
        [Required(ErrorMessage = "Please type director")]
        public string Director { get; set; }

        public virtual List<Mark> Marks { get; set; }
        public virtual List<Comment> Comments { get; set; }
    }
}
