using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClockShop.Entities;

namespace ClockShop.DAL
{
    public class TagRepository : Repository<Tag>
    {
        public TagRepository(ClockShopContext context) : base(context)
        {
        }
    }
}
