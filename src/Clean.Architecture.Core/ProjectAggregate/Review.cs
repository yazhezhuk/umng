using Clean.Architecture.SharedKernel;
using Clean.Architecture.SharedKernel.Interfaces;

namespace Clean.Architecture.Core.ProjectAggregate;

public class Review : EntityBase, IAggregateRoot
{
    public int UserId { get; private set; }
    public User User { get; }
    
    public int TitleId { get; private set; }
    public Title Title { get; }
    
    public int Rating { get; private set; }
    public string Comment { get; private set; }
    
}