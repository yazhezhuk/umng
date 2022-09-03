using Ardalis.SmartEnum;

namespace Clean.Architecture.Core.ProjectAggregate;

public class Roles : SmartEnum<Roles>
{
    public static readonly Roles Admin = new (nameof(Admin), 1);
    public static readonly Roles User = new (nameof(User), 2);
    protected Roles(string name, int value) : base(name, value) { }
}