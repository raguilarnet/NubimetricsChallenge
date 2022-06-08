using NubimetricsChallenge.Application.Interfaces;
using NubimetricsChallenge.Application.Interfaces.Repositories;
using NubimetricsChallenge.Infrastructure.Persistence.Contexts;
using NubimetricsChallenge.Infrastructure.Persistence.Repositories;

namespace NubimetricsChallenge.Infrastructure.Persistence;

public class UnitOfWork : IUnitOfWork
{
    private readonly IUserRepository _userRepository;
    private readonly NubiChallengeContext _context;

    public UnitOfWork(NubiChallengeContext context)
    {
        _context = context;
        _userRepository = new UserRepository(context);
    }

    public IUserRepository userRepository => _userRepository ?? new UserRepository(_context);

    public async Task SaveChanges()
    {
        await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
