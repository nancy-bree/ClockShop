using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClockShop.Entities
{
    public class CommentRating
    {
        public int Id { get; set; }
        public int Vote { get; set; }
        public virtual Comment Comment { get; set; }
        public virtual User User { get; set; }
        public DateTime Created { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime DeletedDate { get; set; }

        public CommentRating()
        {
            Created = DateTime.Now;
            IsDeleted = false;
        }
    }
}
