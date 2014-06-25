using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClockShop.Entities
{
    public class Card
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public DateTime Created { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime DeletedDate { get; set; }
        public virtual List<Photo> Photos { get; set; }
        public virtual List<Comment> Comments { get; set; }
        public virtual  User User { get; set; }
        public virtual List<CardRating> CardRatings { get; set; }
        public virtual List<Tag> Tags { get; set; }

        public Card()
        {
            Created = DateTime.Now;
            IsDeleted = false;
        }
    }
}
