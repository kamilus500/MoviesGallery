using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Movies_Gallery.Entities
{
    public class Mark
    {
        public int Id { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Result")]
        [Required(ErrorMessage = "Please type grade of movie")]
        public double Result { get; set; }

        public int UserId { get; set; }
        public virtual User User { get; set; }

        public int MovieId { get; set; }
        public virtual Movie Movie { get; set; }
    }
}