﻿namespace Cigirci.Budgeteer.Services;

using DbContext;
using Models;
using Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

/// <summary>
/// Base class for all services.
/// </summary>
public class BudgeteerService : IControllerService<Record>
{
    private readonly BudgeteerContext? _budgeteerContext;

    public BudgeteerService(BudgeteerContext? budgeteerContext = null)
    {
        _budgeteerContext = budgeteerContext;
    }

    public Task Create<TEntity>(Record record) where TEntity : Record
    {
        throw new NotImplementedException();
    }

    public Task Delete<TEntity>(Record record) where TEntity : Record
    {
        throw new NotImplementedException();
    }



    public Task<Record> Get<TEntity>(Guid id) where TEntity : Record
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Record>> GetAll<TEntity>() where TEntity : Record
    {
        return await _budgeteerContext?.Set<TEntity>().ToListAsync();
    }

    public Task Update<TEntity>(Record record) where TEntity : Record
    {
        throw new NotImplementedException();
    }
    
    public Task<bool> Exists<T>(Record record) where T : Record
    {
        throw new NotImplementedException();
    }
}