using System.Diagnostics.Contracts;
using Clean.Architecture.SharedKernel;
using Clean.Architecture.SharedKernel.Interfaces;

namespace Clean.Architecture.Core.ProjectAggregate;

public class Title : EntityBase, IAggregateRoot
{
    public string Name { get; set; } 
    public string Description { get; set; }
    
    public int StudioId { get; set; }
    
    public byte[] Image { get; set; }
    public double Rating { get; set; }
}
