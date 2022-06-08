using NubimetricsChallenge.Application.Interfaces.Repositories;
using NubimetricsChallenge.Domain.Entities;
using NubimetricsChallenge.Infrastructure.Persistence.Contexts;

namespace NubimetricsChallenge.Infrastructure.Persistence.Repositories;

public class UserRepository : GenericRepository<User>, IUserRepository
{
    public UserRepository(NubiChallengeContext context) : base(context)
    {

    }
}
