﻿using Application.Repositories;

namespace Application;
public interface IUnitOfWork
{
    public Task<int> SaveChangeAsync();
    public IUserRepository UserRepository { get; }
}