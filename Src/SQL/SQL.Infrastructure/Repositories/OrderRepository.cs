
using Microsoft.EntityFrameworkCore;
using SQL.Application.Contracts.Persistence;
using SQL.Domain.Entities;
using SQL.Infrastructure.Persistence;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace SQL.Infrastructure.Repositories
{  public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        public OrderRepository(OrderContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Order>> GetOrdersByUserName(string userName)
        {
            var orderList = await _dbContext.Orders
                                // .Where(o => o.UserName == userName)
                                .ToListAsync();
            return orderList;
        }
    }
}