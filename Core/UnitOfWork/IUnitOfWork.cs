using System.Threading;
using System.Threading.Tasks;

namespace Core.UnitOfWork
{
    public interface IUnitOfWork
    {
        Task CommmitAsync(CancellationToken cancellationToken = default);
        void Commit();
    }
}
