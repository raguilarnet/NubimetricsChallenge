using Microsoft.EntityFrameworkCore;
using NubimetricsChallenge.Domain.Entities;

namespace NubimetricsChallenge.Application.Interfaces;

public interface INubiChallengeContext
{
    public DbSet<User> Users { get; set; }
}
