using System.Collections.Generic;

namespace OnlineShop.Domain
{
    public class CustomerBasket
    {
        public string PaymentIntentId;
        public string ClientSecret;
        public object DeliveryMethodId;

        public CustomerBasket()
        {
        }

        public CustomerBasket(string id)
        {
            Id = id;
        }

        public string Id { get; set; }
        public List<BasketItem> Items { get; set; } = new List<BasketItem>();
    }
}