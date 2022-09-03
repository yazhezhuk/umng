using Ardalis.Specification;
using Clean.Architecture.Core.Entities;
using Clean.Architecture.Core.ProjectAggregate;

namespace Clean.Architecture.Core.ProjectAggregate.Specifications;

public sealed class ProjectByIdWithItemsSpec : Specification<Project>, ISingleResultSpecification
{
  public ProjectByIdWithItemsSpec(int projectId)
  {
    Query
        .Where(project => project.Id == projectId)
        .Include(project => project.Items);
  }
}
