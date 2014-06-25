using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClockShop.Entities;

namespace ClockShop.DAL
{
    public class CommentRepository : Repository<Comment>
    {
        public CommentRepository(ClockShopContext context) : base(context)
        {
        }
    }
}
