using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;
using Offers.Entities;
using Repository;

namespace Offers.Service
{
    public interface IOffersService
    {
        Task<IEnumerable<Offer>> GetAsync();
        Task<Offer> FindAsync(int id);
        Offer Add(Offer offer);
    }

    public class OffersService : IOffersService
    {
        private readonly IRepository<Offer> _offerRepository;

        public OffersService(IRepository<Offer> offerRepository)
        {
            _offerRepository = offerRepository;
        }

        public async Task<IEnumerable<Offer>> GetAsync()
        {
            return await _offerRepository.Query().GetAsync();
        }

        public Task<Offer> FindAsync(int id)
        {
            return _offerRepository.FindAsync(id);
        }

        public Offer Add(Offer offer)
        {
            _offerRepository.Insert(offer);
            return offer;
        }
    }
}
