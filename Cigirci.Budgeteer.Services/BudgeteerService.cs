namespace Cigirci.Budgeteer.Services;

using DbContext;
using Interfaces.Services;
using Microsoft.ApplicationInsights;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

/// <summary>
/// Base class for all controller services using BudgeteerContext.
/// </summary>
public abstract class BudgeteerService<TEntity> : IBudgeteerService<TEntity> where TEntity : Record
{
    private readonly BudgeteerContext? _budgeteerContext;
    private readonly TelemetryClient? _telemetryClient;

    protected BudgeteerService(BudgeteerContext? budgeteerContext = null, TelemetryClient? telemetryClient = null)
    {
        _budgeteerContext = budgeteerContext;
        _telemetryClient = telemetryClient;
    }

    public async Task<TEntity>? Get(Guid id)
    {
        return await _budgeteerContext?.Set<TEntity>()
        .FirstOrDefaultAsync(record => record.Id.Equals(id));
    }

    public async Task<IEnumerable<TEntity>> GetAll()
    {
        return await _budgeteerContext?.Set<TEntity>()
            .ToListAsync();
    }

    public Task<TEntity> Create(TEntity record)
    {
        throw new NotImplementedException();
    }

    public Task<TEntity> Update(TEntity record)
    {
        throw new NotImplementedException();
    }

    public Task Delete(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Exists(Guid id)
    {
        throw new NotImplementedException();
    }
}