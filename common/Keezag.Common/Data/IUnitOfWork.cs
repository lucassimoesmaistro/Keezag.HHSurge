using System.Threading.Tasks;

namespace Keezag.Common.Data
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}
