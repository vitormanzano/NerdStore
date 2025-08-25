using NerdStore.Core.DomainObjects;

namespace NerdStore.Core.Data
{
    public interface IRepository<T> : IDisposable where T : IAggregateRoot //Um repo por agregação
    {
        IUnitOfWork UnitOfWork { get; }
    }
}
