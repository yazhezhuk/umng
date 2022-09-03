using Clean.Architecture.Core.Entities;
using Clean.Architecture.Core.ProjectAggregate;
using Clean.Architecture.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Clean.Architecture.Web;

public static class SeedData
{
  public static readonly Studio TestStudio1 = new("Studio1");
  public static readonly Title Title1 = new(0, "Title1", "Description1");

  public static void Initialize(IServiceProvider serviceProvider)
  {
    using var dbContext = new AppDbContext(
      serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>(), null);
    
    if (dbContext.Studios.Any()) { return; }

    PopulateTestData(dbContext);
  }
  public static void PopulateTestData(AppDbContext dbContext)
  {
    TestProject1.AddItem();
    TestProject1.AddItem(ToDoItem2);
    TestProject1.AddItem(ToDoItem3);
    dbContext.Projects.Add(TestProject1);

    dbContext.SaveChanges();
  }
}
