using Clean.Architecture.Core.ProjectAggregate;
using Clean.Architecture.IntegrationTests.Data.Db;
using Xunit;

namespace Clean.Architecture.IntegrationTests.Data.Ef;

public class EfRepositoryDelete : EfWithMemoryDbFixtureBase
{
  [Fact]
  public async Task DeletesItemAfterAddingIt()
  {
    // add a project
    var repository = GetRepository<Studio>();
    var initialName = Guid.NewGuid().ToString();
    var studio = new Studio(initialName);
    await repository.AddAsync(studio);

    // delete the item
    await repository.DeleteAsync(studio);

    // verify it's no longer there
    Assert.DoesNotContain(await repository.ListAsync(),
        s => s.Name == initialName);
  }
}
