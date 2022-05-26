using OnlineShop.Domain;
using System;
using System.Linq.Expressions;


namespace OnlineShop.Application.Common.Models
{
    public class OrderWithItemsAndOrderingSpecipication : BaseSpecipication<Order>
    {
        public OrderWithItemsAndOrderingSpecipication(string email) : base(o => o.BuyerEmail == email)
        {
            AddInclude(o => o.OrderItems);
            AddInclude(o => o.DeliveryMethod);
            AddOrderByDescending(o => o.OrderDate);
        }

        public OrderWithItemsAndOrderingSpecipication(int id, string email) : base(o => o.Id == id && o.BuyerEmail == email)
        {
            AddInclude(o => o.OrderItems);
            AddInclude(o => o.DeliveryMethod);
        }
    }
}