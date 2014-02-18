

namespace Offers.Data.Initializer
{
    using Offers.Data.Initializer.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;

    /// <summary>
    /// Use this class to initialize the database.
    /// This is currently a hard copy of the Offers.DAL and Offers.Entities copy
    /// due to an issue with the Repository framework which does NOT allow
    /// to seed the data into the database.
    /// For this POC will fit fair enought
    /// 
    /// MAKE SURE:
    /// You have set the connection string properly to your database.
    /// 
    /// TESTED ON:
    /// SQL Express 2012.
    /// 
    /// How to use:
    /// Run the test found on the OffersDbInitializer.cs within this project, at root level.
    /// </summary>
    public class OffersContextInitializer : DropCreateDatabaseAlways<OffersContext>
    {
        protected override void Seed(OffersContext context)
        {
            var offerTypes = new List<OfferType>
            {
                new OfferType {Description = "Cuota", OfferTypeID = 0},
                new OfferType {Description = "Service", OfferTypeID = 1},
                new OfferType {Description = "Potential Client", OfferTypeID = 2},
            };
            offerTypes.ForEach(ot => context.OfferTypes.Add(ot));

            var offerStatuses = new List<OfferStatu>
            {
                new OfferStatu {Description = "Pending to validate", OfferStatusID = 0},
                new OfferStatu {Description = "Validated", OfferStatusID = 1},
                new OfferStatu {Description = "Pending to accept", OfferStatusID = 2},
                new OfferStatu {Description = "Accepted", OfferStatusID = 3},
                new OfferStatu {Description = "Refused", OfferStatusID = 4},
            };
            offerStatuses.ForEach(os => context.OfferStatus.Add(os));

            var offerReasons = new List<OfferReason>
            {
                new OfferReason {Description = "Fee Added", ReasonID = 0},
                new OfferReason {Description = "Consultation Services ", ReasonID = 1},
                new OfferReason {Description = "Income Management", ReasonID = 2},
                new OfferReason {Description = "Complete Accounting", ReasonID = 3},
                new OfferReason {Description = "Multiservice", ReasonID = 4},
            };
            offerReasons.ForEach(or => context.OfferReasons.Add(or));

            var customers = new List<Customer>
            {
                new Customer {CustomerID = 35, IsClient = true, Name = "Valentino", SurName = "Rossi"},
                new Customer {CustomerID = 36, IsClient = false, Name = "Dani", SurName = "Pedrosa"},
                new Customer {CustomerID = 37, IsClient = true, Name = "Marc", SurName = "Márquez"},
                new Customer {CustomerID = 38, IsClient = false, Name = "Jorge", SurName = "Lorenzo"},
                new Customer {CustomerID = 39, IsClient = false, Name = "Lionel", SurName = "Messi"},
                new Customer {CustomerID = 40, IsClient = false, Name = "Alex", SurName = "Rins"},
                new Customer {CustomerID = 41, IsClient = true, Name = "Marco", SurName = "Melandri"},
                new Customer {CustomerID = 42, IsClient = true, Name = "Marc", SurName = "Coma"},
                new Customer {CustomerID = 43, IsClient = false, Name = "Aleix", SurName = "Espargaró"},
                new Customer {CustomerID = 44, IsClient = false, Name = "Maveric", SurName = "Viñales"},
                new Customer {CustomerID = 45, IsClient = false, Name = "Nico", SurName = "Terol"},
                new Customer {CustomerID = 46, IsClient = true, Name = "Loris", SurName = "Capirosi"},
                new Customer {CustomerID = 47, IsClient = false, Name = "Álvaro", SurName = "Bautista"},
                new Customer {CustomerID = 48, IsClient = false, Name = "Nicky", SurName = "Haiden"},
                new Customer {CustomerID = 49, IsClient = false, Name = "Roberto", SurName = "Baggio"},
                new Customer {CustomerID = 50, IsClient = false, Name = "Andrés", SurName = "Iniesta"},
                new Customer {CustomerID = 51, IsClient = false, Name = "Xavi", SurName = "Hernández"},
                new Customer {CustomerID = 052, IsClient = false, Name = "Victor", SurName = "Valdés"},
                new Customer {CustomerID = 053, IsClient = true, Name = "Dani", SurName = "Alves"},
                new Customer {CustomerID = 054, IsClient = false, Name = "Mica", SurName = "Kalio"},
                new Customer {CustomerID = 055, IsClient = true, Name = "Michael", SurName = "Schumaker"},
                new Customer {CustomerID = 056, IsClient = false, Name = "Bratley", SurName = "Smith"},
                new Customer {CustomerID = 057, IsClient = true, Name = "Pol", SurName = "Espargaró"},
                new Customer {CustomerID = 058, IsClient = false, Name = "Toni", SurName = "Elías"},
                new Customer {CustomerID = 059, IsClient = true, Name = "Angel", SurName = "Nieto"},
                new Customer {CustomerID = 060, IsClient = true, Name = "Alex", SurName = "Crivillé"},
                new Customer {CustomerID = 061, IsClient = false, Name = "Carlos", SurName = "Checa"},
                new Customer {CustomerID = 062, IsClient = false, Name = "Alex", SurName = "Barros"},
                new Customer {CustomerID = 063, IsClient = true, Name = "Mick", SurName = "Dohan"},
                new Customer {CustomerID = 064, IsClient = true, Name = "Max", SurName = "Biaggi"},
                new Customer {CustomerID = 065, IsClient = false, Name = "Casey", SurName = "Stoner"},
                new Customer {CustomerID = 066, IsClient = false, Name = "Ricardo", SurName = "Tormo"},
                new Customer {CustomerID = 067, IsClient = true, Name = "Felipe", SurName = "Mass"},
                new Customer {CustomerID = 068, IsClient = true, Name = "Fernando", SurName = "Alonso"},
            };
            customers.ForEach(c => context.Customers.Add(c));

            var offersManagers = new List<Manager>
            {
                new Manager {ManagerID = 1, Name = "Albert", SurName = "Cumplido"},
                new Manager {ManagerID = 2, Name = "Toni", SurName = "Graella"},
                new Manager {ManagerID = 3, Name = "Dani", SurName = "Meta"},
            };
            offersManagers.ForEach(om => context.Managers.Add(om));

            var minMaxManagers =
                new KeyValuePair<int, int>(offersManagers.Min(m => m.ManagerID), offersManagers.Max(m => m.ManagerID));
            var minMaxOfferTypes =
                new KeyValuePair<int, int>(offerTypes.Min(m => m.OfferTypeID), offerTypes.Max(m => m.OfferTypeID));
            var minMaxOfferReasons =
                new KeyValuePair<int, int>(offerReasons.Min(m => m.ReasonID), offerReasons.Max(m => m.ReasonID));
            var minMaxOfferStatuses =
                new KeyValuePair<int, int>(offerStatuses.Min(m => m.OfferStatusID),
                    offerStatuses.Max(m => m.OfferStatusID));

            var descriptionsDictionay = new Dictionary<int, string>();
            descriptionsDictionay.Add(0, "Oferta generado por contacto relacionado");
            descriptionsDictionay.Add(1, "Intentar ampliar cuotas de servicios con más gestiones relacionadas");
            descriptionsDictionay.Add(2, "Campaña inicial y potencial cliente con otros servicios");
            descriptionsDictionay.Add(3, "Realizar oferta a la baja para capturar cliente con muchas opciones de venta");
            descriptionsDictionay.Add(4, "Oferta generado por contacto relacionado");

            var offerIndex = 0;
            foreach (var id in customers
                .Select(c => c.CustomerID)
                .ToList())
            {
                var addFollowedDate = id%6 == 0;
                var createdOn = new DateTime(2012, GetRandom(4, 12), GetRandom(15, 28));
                DateTime? followedOn = null;
                if (addFollowedDate)
                {
                    followedOn = createdOn.AddDays(GetRandom(100, 365));
                }
                context.Offers.Add(new Offer
                {
                    CreatedOn = createdOn,
                    OfferID = offerIndex++,
                    OfferTypeID = GetRandom(minMaxOfferTypes.Key, minMaxOfferTypes.Value -1),
                    OfferStatusID = GetRandom(minMaxOfferStatuses.Key, minMaxOfferStatuses.Value-2),
                    FollowedOn = followedOn,
                    SuccessAmount = GetRandom(10 + id, 90),
                    ReasonID = GetRandom(minMaxOfferReasons.Key, minMaxOfferReasons.Value -3),
                    Description = descriptionsDictionay[GetRandom(0, 4)],
                    PriceAmount = GetRandomAmount(),
                    CustomerID = id,
                    ManagerID = GetRandom(minMaxManagers.Key, minMaxManagers.Value -1)
                });
            }

            foreach (var id in customers
                                .Select(c => c.CustomerID)
                                .Skip(20)
                                .ToList())
            {
                var addFollowedDate = id%6 == 0;
                var createdOn = new DateTime(2012, GetRandom(1, 10), GetRandom(1, 20));
                DateTime? followedOn = null;
                if (addFollowedDate)
                {
                    followedOn = createdOn.AddDays(GetRandom(50, 300));
                }
                context.Offers.Add(new Offer
                {
                    CreatedOn = createdOn,
                    OfferID = offerIndex++,
                    OfferTypeID = GetRandom(minMaxOfferTypes.Key +1, minMaxOfferTypes.Value),
                    OfferStatusID = GetRandom(minMaxOfferStatuses.Key +2, minMaxOfferStatuses.Value),
                    FollowedOn = followedOn,
                    SuccessAmount = GetRandom(12 + id, 90),
                    ReasonID = GetRandom(minMaxOfferReasons.Key +3, minMaxOfferReasons.Value),
                    Description = descriptionsDictionay[GetRandom(0, 4)],
                    PriceAmount = GetRandomAmount(),
                    CustomerID = id,
                    ManagerID = GetRandom(minMaxManagers.Key +1, minMaxManagers.Value)
                });
            }

            context.SaveChanges();
        }

        public decimal GetRandomAmount()
        {
            Random r = new Random();
            double rDouble = r.NextDouble() * 3000;
            return (decimal)rDouble;
        }

        public int GetRandom(int i, int f)
        {
            Random r = new Random();
            return r.Next(i, f);
        }
    }
}
