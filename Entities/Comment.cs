using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Movies_Gallery.Entities
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        public DateTime ReleaseCreate { get; set; }
        public string CommentText { get; set; }
        public string UserId { get; set; }
        public int MovieId { get; set; }
        public virtual Movie Movie { get; set; }
        public virtual User User { get; set; }
    }
}
