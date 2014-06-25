using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClockShop.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public virtual User User { get; set; }
        public virtual Card Card { get; set; }
        public DateTime Created { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime DeletedDate { get; set; }
        public virtual List<CommentRating> CommentRatings { get; set; }

        public Comment()
        {
            Created = DateTime.Now;
            IsDeleted = false;
        }
    }
}
