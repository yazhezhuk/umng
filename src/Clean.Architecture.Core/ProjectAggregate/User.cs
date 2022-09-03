using Ardalis.GuardClauses;
using Clean.Architecture.SharedKernel;
using Clean.Architecture.SharedKernel.Interfaces;

namespace Clean.Architecture.Core.ProjectAggregate;

public class User : EntityBase, IAggregateRoot
{
    public string Name { get; private set; }
    public string Email { get; private set; }
    
    public User(string name, string email)
    {
        Guard.Against.NullOrEmpty(name, nameof(name));
        Guard.Against.NullOrEmpty(email, nameof(email));
        
        Name = name;
        Email = email;
    }
    
    public void UpdateName(string name)
    {
        Guard.Against.NullOrEmpty(name, nameof(name));
        Name = name;
    }
    
}