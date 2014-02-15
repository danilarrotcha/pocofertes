

namespace WebServer.Controllers
{
    using Offers.Entities;
    using Repository;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using System.Net;
    using System.Threading.Tasks;
    using System.Web.Http;
    using System.Web.Http.ModelBinding;
    using System.Web.Http.OData;

    public class OffersQueryController : ODataController
    {
        /* odata querying samples:
         * http://localhost:52282/odata/OffersQuery?$orderby=PriceAmount%20desc
         * http://localhost:52282/odata/OffersQuery?$filter=CustomerID%20eq%2030
         * http://localhost:52282/odata/OffersQuery?$filter=CustomerID%20eq%2036
         * http://localhost:52282/odata/OffersQuery?$filter=PriceAmount%20gt%201500&$top=10
         * 
         * The current support of query string parameters is limited to $top, $skip, $filter and $orderby.
         */

        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Offer> _offersRepository;

        public OffersQueryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _offersRepository = _unitOfWork.Repository<Offer>();
        }

        // GET odata/OffersQuery
        [Queryable]
        public IQueryable<Offer> GetOffersQuery()
        {
            return _offersRepository.Query().Get();
        }

        // GET odata/OffersQuery(5)
        [Queryable]
        public SingleResult<Offer> GetOffer([FromODataUri] int key)
        {
            return SingleResult.Create(_offersRepository.Query().Get().Where(offer => offer.OfferID == key));
        }

        // PUT odata/OffersQuery(5)
        public async Task<IHttpActionResult> Put([FromODataUri] int key, Offer offer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (key != offer.OfferID)
            {
                return BadRequest();
            }

            offer.ObjectState = ObjectState.Modified;
            _offersRepository.Update(offer);
            try
            {
                await _unitOfWork.SaveAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OfferExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(offer);
        }

        // POST odata/OffersQuery
        public async Task<IHttpActionResult> Post(Offer offer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _offersRepository.Insert(offer);
            await _unitOfWork.SaveAsync();

            return Created(offer);
        }

        // PATCH odata/OffersQuery(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<Offer> patch)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Offer offer = await _offersRepository.FindAsync(key);
            if (offer == null)
            {
                return NotFound();
            }

            patch.Patch(offer);

            try
            {
                await _unitOfWork.SaveAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OfferExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(offer);
        }

        // DELETE odata/OffersQuery(5)
        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
            Offer offer = await _offersRepository.FindAsync(key);
            if (offer == null)
            {
                return NotFound();
            }

            _offersRepository.Delete(offer);
            await _unitOfWork.SaveAsync();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET odata/OffersQuery(5)/Customer
        [Queryable]
        public SingleResult<Customer> GetCustomer([FromODataUri] int key)
        {
            return SingleResult.Create(_offersRepository.Query().Get().Where(m => m.OfferID == key).Select(m => m.Customer));
        }

        // GET odata/OffersQuery(5)/Manager
        [Queryable]
        public SingleResult<Manager> GetManager([FromODataUri] int key)
        {
            return SingleResult.Create(_offersRepository.Query().Get().Where(m => m.OfferID == key).Select(m => m.Manager));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _unitOfWork.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool OfferExists(int key)
        {
            return _offersRepository.Query().Get().Count(e => e.OfferID == key) > 0;
        }
    }
}
