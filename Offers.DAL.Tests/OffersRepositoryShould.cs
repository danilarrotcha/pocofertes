

using Xunit.Extensions;

namespace Offers.DAL.Tests
{
    using Offers.Entities;
    using Repository;
    using System;
    using System.Globalization;
    using System.Linq;
    using Xunit;

    public class OffersRepositoryShould
    {
        private readonly IRepository<Offer> offersRepository; 
        public OffersRepositoryShould()
        {
            offersRepository = new UnitOfWork(new OffersContext()).Repository<Offer>();
        }

        [Fact]
        public void ReturnAllOffers()
        {
            var result = offersRepository
                .Query()
                .GetAsync()
                .Result;

            Assert.NotNull(result);
            Assert.True(result.Any());
        }

        [Fact]
        public void FindOffersForClientsWithoutCustomerInformation()
        {
            var result = offersRepository
                .Query()
                .Filter(o => o.Customer.IsClient)
                .Get()
                .AsEnumerable();


            Assert.NotNull(result);

            var enumerable
                = result as Offer[] ?? result.ToArray();

            Assert.True(enumerable.Any());
            Assert.Null(enumerable.First().Customer);
        }

        [Fact]
        public void FindOffersForClientsWithCustomerInformation()
        {
            var result = offersRepository
                .Query()
                .Include(o => o.Customer)
                .Filter(o => o.Customer.IsClient)
                .Get()
                .AsEnumerable();


            Assert.NotNull(result);

            var enumerable
                = result as Offer[] ?? result.ToArray();

            Assert.True(enumerable.Any());
            Assert.NotNull(enumerable.First().Customer);
        }

        [Fact]
        public void FindOffersForSpecificManagerWithCustomerInformation()
        {
            var result = offersRepository
                .Query()
                .Include(o => o.Customer)
                .Filter(o => o.Manager.Name == "Albert")
                .Get()
                .AsEnumerable();


            Assert.NotNull(result);

            var enumerable
                = result as Offer[] ?? result.ToArray();

            Assert.True(enumerable.Any());
            Assert.NotNull(enumerable.First().Customer);
        }

        [Fact]
        public void FindOffersForSpecificManagerWithCustomerAndManagerInformation()
        {
            var result = offersRepository
                .Query()
                .Include(o => o.Customer)
                .Include(o => o.Manager)
                .Filter(o => o.Manager.Name == "Albert")
                .Get()
                .AsEnumerable();

            Assert.NotNull(result);

            var enumerable
                = result as Offer[] ?? result.ToArray();

            Assert.True(enumerable.Any());
            Assert.NotNull(enumerable.First().Customer);
            Assert.NotNull(enumerable.First().Manager);
            Assert.True(enumerable.First().Manager.Name == "Albert");
        }

        private  DateTime createdOn = new DateTime(2013, 7, 1);

        [Theory(DisplayName ="Requirement 1 and 3: Search offers by pending to validate and creation date" )]
        [InlineData("7/1/2013", OfferStatus.PendingToValidate)]
        [InlineData("7/1/2013", OfferStatus.PendingToAccept)]
        public void SearchOffersByCreationDateAndPendingToValidateStatus(string date, int status)
        {
            var createdOn = DateTime.Parse(date);
            var offerStatus = status;

            var queryTask = offersRepository
                .Query()
                .Include(o => o.Manager)
                .Include(o => o.Customer)
                .Filter(o => o.OfferStatusID == offerStatus && o.CreatedOn >= createdOn)
                .GetAsync();

            System.Console.WriteLine("--------------------------------------------------------");
            System.Console.WriteLine("Some other work to do before querying for the results...");
            System.Console.WriteLine("--------------------------------------------------------");

            System.Console.WriteLine("now we're ready to get the results...");
            var resultNow = queryTask.Result.ToArray();

            Assert.NotNull(resultNow);
            Assert.True(resultNow.Any());

            var customers =
                String.Join("\n\t- ", 
                    resultNow
                    .Select(o => o.Customer)
                    .Distinct()
                    .Select(c => c.GetFullName()));

            var managers =
                String.Join("\n\t- ", 
                    resultNow
                    .Select(o => o.Manager)
                    .Distinct()
                    .Select(m => m.GetFullName()));

            System.Console.WriteLine("\nFound {0} offers with '{1}' status. \nCreated at '{2}' for customer(s): \n\t- {3} \n managed by:\n\t- {4}", 
                resultNow.Count(), Enum.GetName(typeof(OfferStatus), status), createdOn, customers, managers);
        }

        [Fact(DisplayName = "Requirement 2: Search offers by Contact to measure  % accepted - rejected")]
        public void SearchOffersByContact()
        {
            var unitOfWork = new UnitOfWork(new OffersContext());
            var offersRepository = unitOfWork.Repository<Offer>();
            var createdOn = new DateTime(2013, 7, 1);
            var offerStatus = Convert.ToInt32(OfferStatus.PendingToValidate);

            var queryTask = offersRepository
                .Query()
                .Include(o => o.Customer)
                .Filter(o => 
                    o.CustomerID == 36 || 
                    o.CustomerID == 35 || 
                    o.CustomerID == 58)
                .GetAsync();

            System.Console.WriteLine("--------------------------------------------------------");
            System.Console.WriteLine("Some other work to do before querying for the results...");
            System.Console.WriteLine("--------------------------------------------------------");

            System.Console.WriteLine("now we're ready to get the results...");
            var resultNow =
                queryTask
                    .Result;

            Assert.NotNull(resultNow);
            Assert.True(resultNow.Any());

            var offersByCustomers = 
                (resultNow as Offer[] ?? resultNow.ToArray())
                .GroupBy(o => o.CustomerID);
           
            System.Console.WriteLine("--------------------------------------------------------");
            System.Console.WriteLine("Who's customer with more accepted offers?");

            var bestRatedCustomer = new Customer();
            decimal bestAverage = 0;

            foreach (var offerByCustomer in offersByCustomers)
            {
                System.Console.WriteLine(
                    "For customer {0} {1}:", 
                    offerByCustomer.First().Customer.Name, 
                    offerByCustomer.First().Customer.SurName);
                
                decimal totalAccepted = offerByCustomer.Sum(o => o.OfferStatusID == Convert.ToInt32(OfferStatus.Accepted) ? 1 : 0);
                var rejected = Math.Abs(totalAccepted - offerByCustomer.Count());
                var average = (totalAccepted/offerByCustomer.Count())*100;

                if (bestAverage == 0 || bestAverage < average)
                {
                    bestAverage = average;
                    bestRatedCustomer = offerByCustomer.First().Customer;
                }

                var averageExpression = Math.Round(average, 2).ToString(CultureInfo.InvariantCulture);
               
                System.Console.WriteLine("\t- % Accepted: {0}", totalAccepted);
                System.Console.WriteLine("\t- % Rejected: {0}", rejected);
                System.Console.WriteLine("\t- % Average: {0} %", averageExpression);
                System.Console.WriteLine();
            }

            System.Console.WriteLine();
            System.Console.WriteLine("--------------------------------------------------------");
            System.Console.WriteLine("Best rated customer is: " + bestRatedCustomer.GetFullName());
            System.Console.WriteLine("--------------------------------------------------------");
        }
    }

    public static class HelperExtensions
    {
        public static string GetFullName(this Customer customer)
        {
            return string.Format("{0} {1}", customer.Name, customer.SurName);
        }

        public static string GetFullName(this Manager manager)
        {
            return string.Format("{0} {1}", manager.Name, manager.SurName);
        }
    }
}
