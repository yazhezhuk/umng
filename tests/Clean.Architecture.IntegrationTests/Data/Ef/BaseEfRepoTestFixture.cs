using Clean.Architecture.Infrastructure.Data;
using Clean.Architecture.SharedKernel;
using Clean.Architecture.SharedKernel.Interfaces;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace Clean.Architecture.IntegrationTests.Data;

public abstract class BaseEfRepoTestFixture
{
  protected readonly AppDbContext _dbContext;

  protected BaseEfRepoTestFixture(DbContextOptions<AppDbContext> options)
  {
      _dbContext = new TestDbContext(options);
  }

  protected EfRepository<T> GetRepository<T>() where T : EntityBase, IAggregateRoot =>
    new (_dbContext);
}
