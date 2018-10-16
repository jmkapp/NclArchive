using System.Data.Entity;
using System.Threading.Tasks;
using DatabaseAccess.ExternalModel;

namespace DatabaseAccess.Repositories
{
    public class DivisionRepository : IDivisionRepository
    {
        public async Task<Division> GetDivisionAsync(int divisionId)
        {
            Division newDivision = null;

            using (var context = new DatabaseContext())
            {
                InternalModel.Division division =
                    await context.Divisions.FirstOrDefaultAsync(d => d.DivisionId == divisionId);

                if (division != null)
                {
                    newDivision = Division.Convert(division);
                }
            }

            return newDivision;
        }
    }
}
