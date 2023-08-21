using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Recore.Data.IRepositories;
using Recore.Domain.Entities.Users;
using Recore.Service.DTOs.Users;
using Recore.Service.Exceptions;
using Recore.Service.Interfaces;

namespace Recore.Service.Services;

public class UserService : IUserService
{
    private readonly IMapper mapper;
    private readonly IRepository<User> repository;
    public UserService(IRepository<User> repository, IMapper mapper)
    {
        this.mapper = mapper;
        this.repository = repository;
    }

    public async ValueTask<UserResultDto> AddAsync(UserCreationDto dto)
    {
        User existUser = await this.repository.SelectAsync(u => u.Phone.Equals(dto.Phone));
        if (existUser is not null)
            throw new AlreadExistException($"This user is already exists with phone = {dto.Phone}");

        var mappedUser = this.mapper.Map<User>(dto);
        await this.repository.CreateAsync(mappedUser);
        await this.repository.SaveAsync();

        var result = this.mapper.Map<UserResultDto>(mappedUser);
        return result;
    }

    public async ValueTask<UserResultDto> ModifyAsync(UserUpdateDto dto)
    {
        User existUser = await this.repository.SelectAsync(u => u.Id.Equals(dto.Id));
        if (existUser is null)
            throw new NotFoundException($"This user is not found with ID = {dto.Id}");

        this.mapper.Map(dto, existUser);
        this.repository.Update(existUser);
        await this.repository.SaveAsync();

        var result = this.mapper.Map<UserResultDto>(existUser);
        return result;
    }

    public async ValueTask<bool> RemoveAsync(long id)
    {
        User existUser = await this.repository.SelectAsync(u => u.Id.Equals(id));
        if (existUser is null)
            throw new NotFoundException($"This user is not found with ID = {id}");

        this.repository.Delete(existUser);
        await this.repository.SaveAsync();
        return true;
    }

    public async ValueTask<UserResultDto> RetrieveByIdAsync(long id)
    {
        User existUser = await this.repository.SelectAsync(u => u.Id.Equals(id));
        if (existUser is null)
            throw new NotFoundException($"This user is not found with ID = {id}");

        var result = this.mapper.Map<UserResultDto>(existUser);
        return result;
    }

    public async ValueTask<IEnumerable<UserResultDto>> RetrieveAllAsync()
    {
        var users = await this.repository.SelectAll().ToListAsync();
        var result = this.mapper.Map<IEnumerable<UserResultDto>>(users);
        return result;
    }
}
