using ContactManagement.Areas.Api.Models;
using ContactManagement.Data.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace ContactManagement.Areas.Api.Controllers
{
    public class ContactController : ApiController
    {
        private readonly IRestRepository<Data.Entity.Contact, int> _contactRepository;

        public ContactController()
        {
            this._contactRepository = new MockContactRepository();
        }

        // GET: api/Contact
        public IEnumerable<ContactModel> Get()
        {
            var entities = this._contactRepository.GetAll();
            return entities.Select(e => new ContactModel(e));
        }

        // GET: api/Contact/5
        public ContactModel Get(int id)
        {
            var entity = this._contactRepository.Get(id);
            return new ContactModel(entity);
        }

        // DELETE: api/Contact/5
        public bool Delete([FromUri]int id)
        {
            return this._contactRepository.Delete(id);
        }

        // POST: api/Contact
        public ContactModel Post([FromBody]ContactPostModel value)
        {
            var entity = this._contactRepository.Post(value.ToEntity());
            return new ContactModel(entity);
        }

        // PUT: api/Contact/5
        public void Put([FromBody]ContactPutModel value)
        {
            this._contactRepository.Put(value.ToEntity());
        }
    }
}