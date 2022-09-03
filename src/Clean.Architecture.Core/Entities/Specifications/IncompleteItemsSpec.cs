using Ardalis.Specification;

namespace Clean.Architecture.Core.ProjectAggregate.Specifications;

public sealed class IncompleteItemsSpec : Specification<ToDoItem>
{
  public IncompleteItemsSpec()
  {
    Query.Where(item => !item.IsDone);
  }
}
