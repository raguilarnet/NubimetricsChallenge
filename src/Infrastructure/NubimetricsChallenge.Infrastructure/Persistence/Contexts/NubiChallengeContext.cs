using Microsoft.EntityFrameworkCore;
using NubimetricsChallenge.Application.Interfaces;
using NubimetricsChallenge.Domain.Entities;

namespace NubimetricsChallenge.Infrastructure.Persistence.Contexts;

public class NubiChallengeContext : DbContext, INubiChallengeContext
{
    private readonly string _connectionString = String.Empty;

    public NubiChallengeContext(DbContextOptions<NubiChallengeContext> options)
         : base(options)
    {
    }
    public NubiChallengeContext(string connectionString)
    {
        _connectionString = connectionString;
    }

    public DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!String.IsNullOrWhiteSpace(_connectionString))
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }

        base.OnConfiguring(optionsBuilder);
    }
}
