using NubimetricsChallenge.Domain.Entities;

namespace NubimetricsChallenge.Application.Interfaces.Contexts;

public interface IDataSeeder
{
    public List<User> Users { get; set; }
}
