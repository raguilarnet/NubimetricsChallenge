using NubimetricsChallenge.Application.Interfaces.Repositories;

namespace NubimetricsChallenge.Application.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IUserRepository userRepository { get; }
    Task SaveChanges();
}
