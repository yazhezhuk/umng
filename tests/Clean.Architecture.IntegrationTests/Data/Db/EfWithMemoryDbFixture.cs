﻿using Clean.Architecture.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Clean.Architecture.IntegrationTests.Data.Db;

public abstract class EfWithMemoryDbFixtureBase : BaseEfRepoTestFixture
{
    protected EfWithMemoryDbFixtureBase() : base(CreateNewContextOptions())
    { }

    private static DbContextOptions<AppDbContext> CreateNewContextOptions()
    {
        // Create a fresh service provider, and therefore a fresh
        // InMemory database instance.
        var serviceProvider = new ServiceCollection()
            .AddEntityFrameworkInMemoryDatabase()
            .BuildServiceProvider();

        // Create a new options instance telling the context to use an
        // InMemory database and the new service provider.
        var builder = new DbContextOptionsBuilder<AppDbContext>();
        builder.UseInMemoryDatabase("mangaDb")
            .UseInternalServiceProvider(serviceProvider);

        return builder.Options;
    }
}