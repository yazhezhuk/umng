using Clean.Architecture.Core.ProjectAggregate;
using Clean.Architecture.IntegrationTests.Data.Db;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Clean.Architecture.IntegrationTests.Data.Ef;

public class EfRepositoryUpdate : EfWithMemoryDbFixtureBase
{
  [Fact]
  public async Task UpdatesItemAfterAddingIt()
  {
    // add a project
    var repository = GetRepository<Studio>();
    var initialName = Guid.NewGuid().ToString();
    var studio = new Studio(initialName);

    await repository.AddAsync(studio);

    // detach the item so we get a different instance
    _dbContext.Entry(studio).State = EntityState.Detached;

    // fetch the item and update its title
    var newStudio = (await repository.ListAsync())
        .FirstOrDefault(project => project.Name == initialName);
    if (newStudio == null)
    {
      Assert.NotNull(newStudio);
      return;
    }
    Assert.NotSame(studio, newStudio);
    var newName = Guid.NewGuid().ToString();
    newStudio.ChangeName(newName);

    // Update the item
    await repository.UpdateAsync(newStudio);

    // Fetch the updated item
    var updatedItem = (await repository.ListAsync())
        .FirstOrDefault(project => project.Name == newName);

    Assert.NotNull(updatedItem);
    Assert.NotEqual(studio.Name, updatedItem?.Name);
    Assert.Equal(newStudio.Id, updatedItem?.Id);
  }
}
