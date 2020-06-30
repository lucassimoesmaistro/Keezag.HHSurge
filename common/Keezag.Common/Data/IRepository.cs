using Keezag.Common.DomainObjects;
using System;

namespace Keezag.Common.Data
{
    public interface IRepository<T> : IDisposable where T : IAggregateRoot
    {
        IUnitOfWork UnitOfWork { get; }
    }
}
