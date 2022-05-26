using OnlineShop.Domain;
using OnlineShop.Infrastructure.Persistance.Contexts;

namespace OnlineShop.Infrastructure.Persistance.DataSeed
{
    public class TypesSeed
    {
        public static async Task Seed(OnlineShopDbContext context)
        {
            if (!context.ProductTypes.Any())
            {
                {
                    var ts1 = new ProductType()
                    {
                        Id = 1,
                        Name = "Boards"
                    };

                    var ts2 = new ProductType()
                    {
                        Id = 2,
                        Name = "Hats"
                    };

                    var ts3 = new ProductType()
                    {
                        Id = 3,
                        Name = "Boots"
                    };

                    var ts4 = new ProductType()
                    {
                        Id = 4,
                        Name = "Gloves"
                    };

                    context.ProductTypes.Add(ts1);

                    context.ProductTypes.Add(ts2);

                    context.ProductTypes.Add(ts3);

                    context.ProductTypes.Add(ts4);




                    await context.SaveChangesAsync();
                }
            }
        }

    }
}