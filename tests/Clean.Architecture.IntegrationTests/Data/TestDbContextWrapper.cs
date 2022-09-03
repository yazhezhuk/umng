using Clean.Architecture.Infrastructure.Data;
using Clean.Architecture.SharedKernel.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;

namespace Clean.Architecture.IntegrationTests.Data;

public sealed class TestDbContext : AppDbContext
{
    public TestDbContext(DbContextOptions<AppDbContext> options) : base(options,null)
    {
        Database.EnsureDeleted();
        Database.EnsureCreated();
    }
}