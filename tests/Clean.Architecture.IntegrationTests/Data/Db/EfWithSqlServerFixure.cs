using Clean.Architecture.Infrastructure.Data;
using Clean.Architecture.SharedKernel.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Moq;

namespace Clean.Architecture.IntegrationTests.Data.Db;

public class EfWithSqlServerFixtureBase : BaseEfRepoTestFixture
{
    protected EfWithSqlServerFixtureBase() : base(CreateNewContextOptions())
    { }

    private static DbContextOptions<AppDbContext> CreateNewContextOptions()
    {
        const string connString =
            "Server=DESKTOP-AJB46M7\\SQLEXPRESS;" +
            "Initial Catalog=mangaDb;" +
            "User=sa;" +
            "Password=1";

        // Create a new options instance telling the context to use an
        // InMemory database and the new service provider.
        
        var builder = new DbContextOptionsBuilder<AppDbContext>();
        builder
            .UseSqlServer(connString);

        return builder.Options;
    }

    
}