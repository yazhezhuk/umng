using Clean.Architecture.Core.ProjectAggregate;
using Clean.Architecture.IntegrationTests.Data.Db;
using Xunit;

namespace Clean.Architecture.IntegrationTests.Data.Ef.Add;

public class EfRepositoryAdd : EfWithSqlServerFixtureBase
{
  [Fact]
  public async Task AddsStudiosAndSetsId()
  {
      var repository = GetRepository<Studio>();
      var testStudioName = "Test Studio";
      var studio = new Studio(testStudioName);

    await repository.AddAsync(studio);

    var addedStudio = (await repository.ListAsync())
                    .FirstOrDefault();
    
    Assert.Equal(testStudioName, addedStudio?.Name);
    Assert.Equal(0, addedStudio?.StudioRating);
    Assert.Equal(0, addedStudio?.Titles.Count);
    Assert.True(addedStudio?.Id >= 0);
  }
  [Fact]
  public async Task ThrowsOnAddingNullStudio()
  {
      await Assert.ThrowsAnyAsync<Exception>(async () =>
      {
          var repository = GetRepository<Studio>();

          await repository.AddAsync(null);

          var addedStudio = (await repository.ListAsync())
              .FirstOrDefault();
      });
  }
  
}
