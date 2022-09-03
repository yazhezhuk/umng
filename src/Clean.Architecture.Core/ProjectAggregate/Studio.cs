using Clean.Architecture.SharedKernel;
using Clean.Architecture.SharedKernel.Interfaces;

namespace Clean.Architecture.Core.ProjectAggregate;

public class Studio : EntityBase, IAggregateRoot
{
    public string Name { get; set; }

    private readonly List<Title> _titles = new();
    public IReadOnlyCollection<Title> Titles => _titles.AsReadOnly();
    
    public double StudioRating => _titles.Average(t => t.Rating);
    
    public void AddTitle(Title title)
    { 
        if (title == null) throw new ArgumentNullException(nameof(title)); 
        _titles.Add(title);
    }
    
    public void RemoveTitle(Title title)
    {
        if (title == null) throw new ArgumentNullException(nameof(title));
        if (!_titles.Remove(title)) throw new InvalidOperationException("Title not found");
    }

}
