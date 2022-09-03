using Ardalis.Specification.EntityFrameworkCore;
using Clean.Architecture.SharedKernel.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Clean.Architecture.Infrastructure.Data;

// inherit from Ardalis.Specification type
public class EfRepository<T> : RepositoryBase<T>, IReadRepository<T>, IRepository<T> where T : class, IAggregateRoot
{
  public EfRepository(DbContext dbContext) : base(dbContext)
  {
  }
}
