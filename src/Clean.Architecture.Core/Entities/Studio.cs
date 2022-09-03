using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography;
using Ardalis.GuardClauses;
using Clean.Architecture.Core.Entities;
using Clean.Architecture.SharedKernel;
using Clean.Architecture.SharedKernel.Interfaces;

namespace Clean.Architecture.Core.ProjectAggregate;

public class Studio : EntityBase, IAggregateRoot
{
    public Studio(string name)
    {
        Name = Guard.Against.NullOrEmpty(name, nameof(name));
    }
    
    public Studio(int id,string name)
    {
        Id = id;
        Name = Guard.Against.NullOrEmpty(name, nameof(name));
    }

    public string Name { get; private set; }

    private readonly List<Title> _titles = new();
    
    [NotMapped]
    public IReadOnlyCollection<Title> Titles => _titles.AsReadOnly();
    
    
    
    public double StudioRating => _titles.Any()
        ? _titles.Average(t => t.Rating) 
        : 0;
    
    public void ChangeName(string name)
    {
        Name = Guard.Against.NullOrEmpty(name, nameof(name));
    }
    
    public void AddTitle(Title title)
    { 
        Guard.Against.Null(title, nameof(title));

        if (_titles.Any(t => t.Name == title.Name))
            throw new ArgumentException("Studio with same name already exist", nameof(title));
        
        _titles.Add(title);
    }
    
    public void RemoveTitle(Title title)
    {
        if (title == null) throw new ArgumentNullException(nameof(title));
        if (!_titles.Remove(title)) throw new InvalidOperationException("Title not found");
    }

}
