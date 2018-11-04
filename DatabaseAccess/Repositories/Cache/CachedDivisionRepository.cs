using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatabaseAccess.ExternalModel;
using DatabaseAccess.Repositories.Interfaces;

namespace DatabaseAccess.Repositories.Cache
{
    public class CachedDivisionRepository : IDivisionRepository
    {
        private readonly DivisionRepository _divisionRepository;
        private readonly Dictionary<DateTime, Division> _divisions;

        public CachedDivisionRepository()
        {
            _divisionRepository = new DivisionRepository();
            _divisions = new Dictionary<DateTime, Division>();
        }

        public async Task<Division> GetDivisionAsync(int divisionId)
        {
            Division division = _divisions.Values.FirstOrDefault(d => d.DivisionId == divisionId);

            if (division == null)
            {
                division = await _divisionRepository.GetDivisionAsync(divisionId);

                if (division != null)
                {
                    _divisions.Add(DateTime.Now, division);
                }
            }

            return division;
        }
    }
}
