using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClockShop.Entities
{
    public class CardRating
    {
        public int Id { get; set; }
        public int Vote { get; set; }
        public virtual Card Card { get; set; }
        public virtual User User { get; set; }
        public DateTime Created { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime DeletedDate { get; set; }

        public CardRating()
        {
            Created = DateTime.Now;
            IsDeleted = false;
        }
    }
}
