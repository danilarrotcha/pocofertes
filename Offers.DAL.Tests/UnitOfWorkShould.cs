namespace Offers.DAL.Tests
{
    using Offers.Entities;
    using Repository;
    using Xunit;

    public class UnitOfWorkShould
    {
        public void BeCreatedWithOffersContext()
        {
            var unitOfWork = new UnitOfWork(new OffersContext());
            
            Assert.NotNull(unitOfWork);
        }

        public void ReturnOffersRepositoryInstance()
        {
            var unitOfWork = new UnitOfWork(new OffersContext());
            var offersRepository = unitOfWork.Repository<Offer>();

            Assert.NotNull(offersRepository);
        }
    }
}
