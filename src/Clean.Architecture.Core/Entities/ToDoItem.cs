﻿using Clean.Architecture.Core.ProjectAggregate.Events;
using Clean.Architecture.SharedKernel;

namespace Clean.Architecture.Core.ProjectAggregate;

public class ToDoItem : EntityBase
{
  public string Title { get; set; } = string.Empty;
  public string Description { get; set; } = string.Empty;
  public bool IsDone { get; private set; }

  public void MarkComplete()
  {
    if (IsDone) return;
    IsDone = true;

    RegisterDomainEvent(new ToDoItemCompletedEvent(this));
  }

  public override string ToString()
  {
    string status = IsDone ? "Done!" : "Not done.";
    return $"{Id}: Status: {status} - {Title} - {Description}";
  }
}
