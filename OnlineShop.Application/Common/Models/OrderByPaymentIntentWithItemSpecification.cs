using OnlineShop.Domain;
using System;
using System.Linq.Expressions;

namespace OnlineShop.Application.Common.Models
{
    public class OrderByPaymentIntentWithItemSpecification : BaseSpecipication<Order>
    {
        public OrderByPaymentIntentWithItemSpecification(string paymentIntentId) :
            base(o => o.PaymentIntentId == paymentIntentId)
        {
        }
    }
}