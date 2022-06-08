using AutoMapper;
using NubimetricsChallenge.Application.DTOs;
using NubimetricsChallenge.Application.Interfaces;
using NubimetricsChallenge.Application.Interfaces.Repositories;
using NubimetricsChallenge.Application.Interfaces.Services;
using NubimetricsChallenge.Domain.Entities;

namespace NubimetricsChallenge.Application.Services;

public class UserServices : IUsersServices
{
    private readonly IMapper _mapper;

    protected readonly IUnitOfWork _unitOfWork;

    public UserServices(IUserRepository userRepository, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    
    public async Task<List<UserDTO>> GetAllUsersAsync()
    {
        return _mapper.Map<List<UserDTO>>(await _unitOfWork.userRepository.GetAllAsync()); ;
    }

    public async Task<UserDTO> GetUserByIdAsync(int id)
    {
        return null;
        return _mapper.Map<UserDTO>(await _unitOfWork.userRepository.GetByIdAsync(id));
    }

    public async Task<UserDTO> InsertAsync(UserDTO entityToInsert)
    {
        var user = _mapper.Map<User>(entityToInsert);
        await _unitOfWork.userRepository.InsertAsync(user);
        await _unitOfWork.SaveChanges();

        return _mapper.Map<UserDTO>(user);
    }

    public async Task<bool> UpdateAsync(int id, UserDTO entityToUpdate)
    {
        var foundUserToUpdate = await _unitOfWork.userRepository.GetByIdAsync(id);

        if (foundUserToUpdate is null)
        {
            return false;
        }

        var userToUpdate = _mapper.Map<User>(entityToUpdate);
        userToUpdate.Id = id;

        _unitOfWork.userRepository.Update(userToUpdate);
        await _unitOfWork.SaveChanges();

        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var userToDelete = await _unitOfWork.userRepository.GetByIdAsync(id);
        if (userToDelete is null)
        {
            return false;
        }
        _unitOfWork.userRepository.Delete(userToDelete);
        await _unitOfWork.SaveChanges();

        return true;
    }
}
