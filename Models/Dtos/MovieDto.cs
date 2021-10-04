using Microsoft.AspNetCore.Http;
using Movies_Gallery.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Movies_Gallery.Models.Dtos
{
    public class MovieDto
    {
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
        [Display(Name = "Director")]
        [Required(ErrorMessage = "Please type director")]
        public string Director { get; set; }

        [DataType(DataType.Upload)]
        [Display(Name = "Upload Image")]
        [Required(ErrorMessage = "Please choose image to upload")]
        public IFormFile Image { get; set; }

        public List<Mark> Marks { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
