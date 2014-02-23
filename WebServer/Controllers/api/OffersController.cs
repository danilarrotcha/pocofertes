

using Offers.Entity;

namespace WebServer.Controllers
{
    using Offers.Entities;
    using Repository;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using System.Net;
    using System.Threading.Tasks;
    using System.Web.Http;
    using System.Web.Http.Description;

    public class OffersController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Offer> _offersRepository;

        public OffersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _offersRepository = unitOfWork.Repository<Offer>();
        }

        // GET api/Offers
        public async Task<IHttpActionResult> GetOffers()
        {
            var offers = await _offersRepository
                .Query()
                .Include(o => o.OfferType)
                .Include(o => o.OfferStatus)
                .Include(o => o.Customer)
                .Include(o => o.Manager)
                .GetAsync();
            
            var enumerable = offers as Offer[] ?? offers.ToArray();
            
            if (enumerable.Any())
            {
                var resp = enumerable
                    .Select(o => new
                    {
                        customer = o.Customer.GetFullName(),
                        customerIsClient = o.Customer.IsClient,
                        createdOn = o.CreatedOn,
                        offerType = o.OfferType.Description,
                        followedOn = o.FollowedOn,
                        offerStatus = o.OfferStatus.Description,
                        offerStatusId = o.OfferStatusID,
                        offerTypeId = o.OfferTypeID,
                        successAmount = o.SuccessAmount + " %",
                        priceAmount = o.PriceAmount,
                        manager = o.Manager.GetFullName()
                    });
                return Ok(resp);
            }

            return NotFound();
        }

        // GET api/Offers/5
        [ResponseType(typeof(Offer))]
        public async Task<IHttpActionResult> GetOffer(int id)
        {

            Offer offer = await _offersRepository.FindAsync(id);

            if (offer == null)
            {
                return NotFound();
            }

            return Ok(offer);
        }

        // PUT api/Offers/5
        public async Task<IHttpActionResult> PutOffer(int id, Offer offer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != offer.OfferID)
            {
                return BadRequest();
            }

            var existingOffer = _offersRepository.Find(id);

            existingOffer = offer;
            existingOffer.ObjectState = ObjectState.Modified;

            try
            {
                await _unitOfWork.SaveAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OfferExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST api/Offers
        [ResponseType(typeof(Offer))]
        public async Task<IHttpActionResult> PostOffer(Offer offer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _offersRepository.Insert(offer);

            try
            {
                await _unitOfWork.SaveAsync();
            }
            catch (DbUpdateException)
            {
                if (OfferExists(offer.OfferID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = offer.OfferID }, offer);
        }

        // DELETE api/Offers/5
        [ResponseType(typeof(Offer))]
        public async Task<IHttpActionResult> DeleteOffer(int id)
        {
            Offer offer = await _offersRepository.FindAsync(id);
            if (offer == null)
            {
                return NotFound();
            }

            _offersRepository.Delete(offer);
            await _unitOfWork.SaveAsync();

            return Ok(offer);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _unitOfWork.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool OfferExists(int id)
        {
            return _offersRepository.Query().Get().Count(e => e.OfferID == id) > 0;
        }
    }
}