using Clean.Architecture.Core.Entities;
using Clean.Architecture.Core.ProjectAggregate;
using Xunit;

namespace Clean.Architecture.UnitTests.Core.StudioAggregate;

public class Studio_AddItem
{
  private Studio _testStudio = new(0,"Test Studio");

  [Fact]
  public void AddsTitleToStudio()
  {
    var _testTitle = new Title
    {
      Name = "title",
      Description = "description"
    };

    _testStudio.AddTitle(_testTitle);

    Assert.Contains(_testTitle, _testStudio.Titles);
  }
  
  [Fact]
  public void ThrowsOnAddingDuplicateTitle()
  {
    var testTitle1 = new Title
    {
      Name = "title",
      Description = "description"
    };
    
    var testTitle2 = new Title
    {
      Name = "title",
      Description = "description1"
    };

    Assert.Throws<ArgumentException>(() =>
    {
      _testStudio.AddTitle(testTitle1);
      _testStudio.AddTitle(testTitle2);
    });
    Assert.Equal(1, _testStudio.Titles.Count);
  }

  [Fact]
  public void ThrowsExceptionGivenNullItem()
  {
    void Action() => _testStudio.AddTitle(null!);

    var ex = Assert.Throws<ArgumentNullException>(Action);
    Assert.Equal("title", ex.ParamName);
  }
}
