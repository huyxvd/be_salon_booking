﻿using Application;

namespace Infrastructures;
public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;

    public UnitOfWork(AppDbContext context)
    {
        _context = context;
    }

    public async Task<int> SaveChangeAsync()
    {
        return await _context.SaveChangesAsync();
    }
}