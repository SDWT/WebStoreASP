using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using WebStore.DAL.SQLDBData;
using WebStore.Domain.Entity;
using WebStore.Services.DataProviders.MSSQLDataProvider;
using Assert = Xunit.Assert;

namespace WebStore.Services.Tests.DataProviders.MSSQLDataProvider
{
    [TestClass]
    public class ProductDataProviderTest
    {
        private DbContextOptions<WebStoreDBContext> options;

        [TestInitialize]
        public void SetupTest()
        {
            options = new DbContextOptionsBuilder<WebStoreDBContext>()
                .UseInMemoryDatabase(databaseName: "testDB")
                .Options;

            using (var context = new WebStoreDBContext(options))
            {

                context.Brands.Add(new Brand
                {
                    Id = 2,
                    Name = "Brand 2",
                    Order = 0
                });
                context.Sections.Add(new Section
                {
                    Id = 3,
                    Name = "Section 3",
                    Order = 0
                });
                context.SaveChanges();
            }

            using (var context = new WebStoreDBContext(options))
            {

                context.Products.Add(new Product
                {
                    Id = 1,
                    Name = "Product 1",
                    Order = 0,
                    Price = 10m,
                    ImageUrl = "product1.jpg",
                    Brand = context.Brands.FirstOrDefault(),
                    Section = context.Sections.FirstOrDefault()
                });
                context.SaveChanges();
            }
        }

        [TestCleanup]
        public void MyTestMethod()
        {
            using (var context = new WebStoreDBContext(options))
            {
                context.Brands.RemoveRange(context.Brands.ToArray());
                context.Sections.RemoveRange(context.Sections.ToArray());
                context.Products.RemoveRange(context.Products.ToArray());
                context.SaveChanges();
            }
        }

        [TestMethod]
        public void GetProductById_Id_Exist()
        {
            using (var context = new WebStoreDBContext(options))
            {
                var dataProvider = new ProductDataProvider(context);
                
                var results = dataProvider.GetProducts();
                var result = dataProvider.GetProductById(1);

                Assert.IsType<Product>(result);

                Assert.Equal(1, result.Id);
                Assert.Equal("Product 1", result.Name);
                Assert.Equal(0, result.Order);
                Assert.Equal(10m, result.Price);
                Assert.Equal("product1.jpg", result.ImageUrl);
                Assert.Equal(2, result.Brand?.Id);
                Assert.Equal(3, result.Section?.Id);
            }
        }

        [TestMethod]
        public void GetProductById_Id_Not_Exist()
        {
            using (var context = new WebStoreDBContext(options))
            {
                var dataProvider = new ProductDataProvider(context);

                var result = dataProvider.GetProductById(5);

                Assert.Null(result);
            }
        }
    }
}
