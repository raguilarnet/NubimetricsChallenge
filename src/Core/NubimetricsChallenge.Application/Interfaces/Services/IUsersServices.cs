using NubimetricsChallenge.Application.DTOs;

namespace NubimetricsChallenge.Application.Interfaces.Services;

public interface IUsersServices
{
    Task<List<UserDTO>> GetAllUsersAsync();
    Task<UserDTO> GetUserByIdAsync(int id);
    Task<UserDTO> InsertAsync(UserDTO entityToInsert);
    Task<bool> UpdateAsync(int id, UserDTO entityToUpdate);
    Task<bool> DeleteAsync(int id);
}
