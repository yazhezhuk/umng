using Clean.Architecture.Core.Entities;
using Clean.Architecture.Core.ProjectAggregate;
using Clean.Architecture.IntegrationTests.Data.Db;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Clean.Architecture.IntegrationTests.Data.Ef;

public class EfRepoAddListItem : EfWithMemoryDbFixtureBase
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
        var dbStudio = (await repository.ListAsync())
            .FirstOrDefault(project => project.Name == initialName);
        if (dbStudio == null)
        {
            Assert.NotNull(dbStudio);
            return;
        }
        Assert.NotSame(studio, dbStudio);
        var title = new Title("title1", "tuc");
        dbStudio.AddTitle(title);

        // Update the item
        await repository.UpdateAsync(dbStudio);

        // Fetch the updated item
        var updatedItem = (await repository.ListAsync())
            .FirstOrDefault(t => t.Name == dbStudio.Name);

        Assert.NotNull(updatedItem);
        Assert.Equal(1, updatedItem.Titles.Count);
        Assert.Same(updatedItem.Titles.First(),title);
    }
}