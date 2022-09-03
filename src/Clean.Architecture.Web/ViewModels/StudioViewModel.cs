using System.Collections.Generic;
using Clean.Architecture.Core.Entities;
using Clean.Architecture.Core.ProjectAggregate;

namespace Clean.Architecture.Web.ViewModels;

public class StudioViewModel
{
  public int Id { get; set; }
  public string? Name { get; set; }
  public List<Title> Titles = new();
}
