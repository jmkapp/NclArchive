using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatabaseAccess.ExternalModel;

namespace DatabaseAccess.Repositories
{
    public class CachedRepository<T> where T : IArchiveItem
    {
        private readonly IRepository<T> _repository;
        private List<T> _items;

        public CachedRepository(IRepository<T> repository)
        {
            _repository = repository;
            _items = new List<T>();
        }

        public async Task<T> GetAsync(string id)
        {
            T item = _items.SingleOrDefault(i => i.Id == id);

            if (item == null)
            {
                item = await _repository.GetAsync(id);

                if (item != null)
                    _items.Add(item);
            }

            return item;
        }

        public void Clear()
        {
            _items = new List<T>();
        }
    }
}
