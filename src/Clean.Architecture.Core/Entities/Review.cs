using Ardalis.GuardClauses;
using Clean.Architecture.Core.Entities;
using Clean.Architecture.SharedKernel;
using Clean.Architecture.SharedKernel.Interfaces;

namespace Clean.Architecture.Core.ProjectAggregate;

public class Review : EntityBase
{ 
    public int UserId { get; }
    public User User { get; }
    public int TitleId { get; }
    public Title Title { get; }
    public Review(int userId, int titleId, string comment)
    {
        UserId = Guard.Against.Negative(userId, nameof(userId));
        TitleId = Guard.Against.Negative(titleId, nameof(titleId));
        Comment = Guard.Against.NullOrEmpty(comment, nameof(comment));
    }

    private Review()
    {
        
    }
    public int Rating { get; private set; } 
    public string Comment { get; private set; }
    
    public void UpdateRating(int rating)
    {
        Rating = Guard.Against.NegativeOrZero(rating);
    }
    public void UpdateComment(string comment)
    {
        Comment = Guard.Against.NullOrEmpty(comment);
    }
    
}