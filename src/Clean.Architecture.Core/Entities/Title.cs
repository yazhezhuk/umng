using Ardalis.GuardClauses;
using Clean.Architecture.Core.ProjectAggregate;
using Clean.Architecture.SharedKernel;
using Clean.Architecture.SharedKernel.Interfaces;

namespace Clean.Architecture.Core.Entities;

public class Title : EntityBase, IAggregateRoot
{
    public string Name { get; init; } 
    public string Description { get; init; }
    
    public Title(int id, string name, string description)
    {
        Guard.Against.NullOrWhiteSpace(name, nameof(name));
        Guard.Against.NullOrWhiteSpace(description, nameof(description));
        
        Id = id;
        Name = name;
        Description = description;
    }
    public Title(string name, string description)
    {
        Guard.Against.NullOrWhiteSpace(name, nameof(name));
        Guard.Against.NullOrWhiteSpace(description, nameof(description));
        
        Name = name;
        Description = description;
    }

    public Title()
    {
    }
    public double Rating => Reviews.Any() ? Reviews.Average(r => r.Rating) : 0;
    
    private List<Review>  _reviews = new();
    public IEnumerable<Review> Reviews => _reviews.AsReadOnly();

    public int StudioId { get; set; }
    
    public byte[] Image { get; private set; }
    
    public void UpdateImage(byte[] image)
    {
        Image = Guard.Against.NullOrInvalidInput(image, nameof(image),
            im => im.Length is > 0 and < 1000000);
    }
    
}
