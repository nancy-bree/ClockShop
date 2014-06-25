using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClockShop.Entities
{
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Created { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime DeletedDate { get; set; }
        public virtual List<Card> Cards { get; set; }

        public Tag()
        {
            Created = DateTime.Now;
            IsDeleted = false;
        }
    }
}
