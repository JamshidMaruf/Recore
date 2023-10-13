﻿using Recore.Domain.Enums;
using Recore.Service.DTOs.Users;
using Recore.Domain.Configurations;

namespace Recore.Service.Interfaces;

public interface IUserService
{
    ValueTask<UserResultDto> AddAsync(UserCreationDto dto);
    ValueTask<UserResultDto> ModifyAsync(UserUpdateDto dto);
    ValueTask<bool> RemoveAsync(long id);
    ValueTask<UserResultDto> RetrieveByIdAsync(long id);
    ValueTask<IEnumerable<UserResultDto>> RetrieveAllAsync(PaginationParams @params,Filter filter, string search = null);
    ValueTask<IEnumerable<UserResultDto>> RetrieveAllAsync();
    ValueTask<UserResultDto> UpgradeRoleAsync(long id, UserRole role);
}