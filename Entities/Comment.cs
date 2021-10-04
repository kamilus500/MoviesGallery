using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies_Gallery.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public DateTime ReleaseCreate { get; set; }
        public string CommentText { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }

        public int MovieId { get; set; }
        public virtual Movie Movie { get; set; }
    }
}
