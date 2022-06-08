using NubimetricsChallenge.Application.DTOs;

namespace NubimetricsChallenge.WebAPI.UnitTests.Fixtures;

public static class UsersFixture
{
    public static List<UserDTO> GetAllTestUsers() => new()
        {
            new UserDTO
            {
                Id = 1,
                FirstName = "Pietro",
                LastName = "Alton",
                Mail = "palton2@flavors.me",
                Password = "zhC6hTwFBX"
            },
            new UserDTO
            {
                Id = 2,
                FirstName = "Shayne",
                LastName = "Pumfrett",
                Mail = "spumfrett4@a8.net",
                Password = "bfRwyReNIDK5"
            },
            new UserDTO
            {
                Id = 3,
                FirstName = "Bordie",
                LastName = "Gibling",
                Mail = "bgibling6@narod.ru",
                Password = "HNbL4QXrdjG"
            },
            new UserDTO
            {
                Id = 4,
                FirstName = "Polly",
                LastName = "Cowdry",
                Mail = "pcowdry7@naver.com",
                Password = "FWxY7A"
            },
            new UserDTO
            {
                Id = 5,
                FirstName = "Grange",
                LastName = "Cullin",
                Mail = "gcullin9@buzzfeed.com",
                Password = "TChiUCeY"
            },
            new UserDTO
            {
                Id = 6,
                FirstName = "Townsend",
                LastName = "Goggan",
                Mail = "tgogganb@yahoo.com",
                Password = "jVb4KMkqU3"
            },
            new UserDTO
            {
                Id = 7,
                FirstName = "Florrie",
                LastName = "Gave",
                Mail = "fgavec@tripod.com",
                Password = "1HuxVaOFSFId"
            },
            new UserDTO
            {
                Id = 8,
                FirstName = "Lucretia",
                LastName = "Gaylard",
                Mail = "lgaylarde@mozilla.org",
                Password = "8TxTFg0g"
            }
        };
    public static List<UserDTO> GetNoTestUsers() => new();
    public static UserDTO GetTestUserById(int id) => new()
    {
        Id = id,
        FirstName = "Pietro",
        LastName = "Alton",
        Mail = "palton2@flavors.me",
        Password = "zhC6hTwFBX"
    };
    public static UserDTO GetTestUser() => new()
    {
        Id = 0,
        FirstName = "Pietro",
        LastName = "Alton",
        Mail = "palton2@flavors.me",
        Password = "zhC6hTwFBX"
    };
    public static UserDTO GetNoTestUserById(int id) => null;
}
