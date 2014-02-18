

namespace Offers.Data.Initializer
{
    using Offers.Data.Initializer.Models;
    using System.Linq;
    using Xunit;

    /// <summary>
    /// Run this test class to autogenerate the data into your database.
    /// <see cref="OffersContextInitializer"/> to check the seed data.
    /// </summary>
    public class OffersDbInitializer
    {
        /// <summary>
        /// Will generate the data and try to retrive an example for each entity.
        /// </summary>
        [Fact]
        public void ShouldReturnDataAfterInitialization()
        {
            var context = new OffersContext();
            var thecustomer = context.Customers.First();
            var themanager = context.Managers.First();
            var theoffer = context.Offers.First();
            var theofferstatus = context.OfferStatus.First();
            var theofferType = context.OfferTypes.First();
            var theofferreason = context.OfferReasons.First();

            Assert.NotNull(thecustomer);
            Assert.NotNull(themanager);
            Assert.NotNull(theoffer);
            Assert.NotNull(theofferstatus);
            Assert.NotNull(theofferType);
            Assert.NotNull(theofferreason);
        }
    }
}
