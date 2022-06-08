using NubimetricsChallenge.Application.Interfaces.Contexts;
using NubimetricsChallenge.Domain.Entities;

namespace NubimetricsChallenge.Infrastructure.Persistence.Contexts;

public class DataSeeder : IDataSeeder
{
    private readonly NubiChallengeContext _context;

    public DataSeeder(NubiChallengeContext context)
    {
        _context = context;
        Users = new List<User>();
    }

    public List<User> Users { get; set; }

    public void Seed()
    {
        if (!_context.Users.Any())
        {
            var usersToAdd = new List<User>()
            {
                new User()
                {
                    FirstName = "Jordon",
                    LastName = "Braxton",
                    Mail = "jbraxton0@psu.edu",
                    Password = "3M3MwBTW"
                },
                new User()
                {
                    FirstName = "West",
                    LastName = "Androck",
                    Mail = "wandrock1@walmart.com",
                    Password = "NcUZQ4wQZ"
                },
                new User()
                {
                    FirstName = "Pietro",
                    LastName = "Alton",
                    Mail = "palton2@flavors.me",
                    Password = "zhC6hTwFBX"
                },
                new User()
                {
                    FirstName = "Beatriz",
                    LastName = "Esgate",
                    Mail = "besgate3@stumbleupon.com",
                    Password = "lT32DN"
                },
                new User()
                {
                    FirstName = "Shayne",
                    LastName = "Pumfrett",
                    Mail = "spumfrett4@a8.net",
                    Password = "bfRwyReNIDK5"
                },
                new User()
                {
                    FirstName = "Broddie",
                    LastName = "Goadsby",
                    Mail = "bgoadsby5@behance.net",
                    Password = "X4v8l6MO"
                },
                new User()
                {
                    FirstName = "Bordie",
                    LastName = "Gibling",
                    Mail = "bgibling6@narod.ru",
                    Password = "HNbL4QXrdjG"
                },
                new User()
                {
                    FirstName = "Polly",
                    LastName = "Cowdry",
                    Mail = "pcowdry7@naver.com",
                    Password = "FWxY7A"
                },
                new User()
                {
                    FirstName = "Jodee",
                    LastName = "Crotty",
                    Mail = "jcrotty8@i2i.jp",
                    Password = "Rl9LfbF"
                },
                new User()
                {
                    FirstName = "Grange",
                    LastName = "Cullin",
                    Mail = "gcullin9@buzzfeed.com",
                    Password = "TChiUCeY"
                },
                new User()
                {
                    FirstName = "Dmitri",
                    LastName = "Twitchett",
                    Mail = "dtwitchetta@networksolutions.com",
                    Password = "wHJIcY"
                },
                new User()
                {
                    FirstName = "Townsend",
                    LastName = "Goggan",
                    Mail = "tgogganb@yahoo.com",
                    Password = "jVb4KMkqU3"
                },
                new User()
                {
                    FirstName = "Florrie",
                    LastName = "Gave",
                    Mail = "fgavec@tripod.com",
                    Password = "1HuxVaOFSFId"
                },
                new User()
                {
                    FirstName = "Ivie",
                    LastName = "Oldknow",
                    Mail = "ioldknowd@mozilla.com",
                    Password = "kD01tKK"
                },
                new User()
                {
                    FirstName = "Lucretia",
                    LastName = "Gaylard",
                    Mail = "lgaylarde@mozilla.org",
                    Password = "8TxTFg0g"
                }
            };
            
            Users.AddRange(usersToAdd);

            _context.Users.AddRange(Users);
            _context.SaveChanges();
        }
    }
}
