using Cashbook.Api.Entities;

namespace Cashbook.Api.Repositories
{
    public interface IParticularRepo
    {
        Task<IEnumerable<Particular>> GetParticulars();
        Task<Particular> GetParticular(string id);
        Task CreateParticular(Particular particular);
        Task<bool> UpdateParticular(Particular particular);
        Task<bool> DeleteParticular(string id);
    }
}
