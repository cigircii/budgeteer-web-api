namespace Cigirci.Budgeteer.Services;

using Cigirci.Budgeteer.Enums.Record;
using Cigirci.Budgeteer.Interfaces.Metadata.Record.Types;
using Cigirci.Budgeteer.Models.Components.Metadata;
using DbContext;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

/// <summary>
/// Base class for all controller services using BudgeteerContext.
/// </summary>
/// //: IBudgeteerService<TEntity> where TEntity : Record
public abstract class BudgeteerService<TEntity> where TEntity : Record
{
    private readonly BudgeteerContext? _budgeteerContext;

    protected BudgeteerService(BudgeteerContext? budgeteerContext = null)
    {
        _budgeteerContext = budgeteerContext;
    }

    public async Task<TEntity?> Get(Guid id)
    {
        if (_budgeteerContext == null) return null;
        return await _budgeteerContext.Set<TEntity>().FindAsync(id);
    }

    //ToList() returns an empty list if no records are found
    //TODO: Check if ToListAsync() returns null if no records are found
    public async Task<IEnumerable<TEntity>> GetAll()
    {
        if (_budgeteerContext == null) return new List<TEntity>();
        return await _budgeteerContext.Set<TEntity>().ToListAsync();
    }

    public async Task<TEntity?> Add(TEntity record)
    {
        if (_budgeteerContext == null) return null;
        
        await _budgeteerContext.Set<TEntity>().AddAsync(record);
        await _budgeteerContext.SaveChangesAsync();

        return record;
    }

    public async Task<TEntity?> Update(TEntity record)
    {
        if (_budgeteerContext == null) return null;
        
        _budgeteerContext.Set<TEntity>().Update(record);
        await _budgeteerContext.SaveChangesAsync();

        return record;
    }

    public async Task Delete(Guid id)
    {
        if (_budgeteerContext == null) return;

        var record = await Get(id);
        if (record == null) return;
        _budgeteerContext.Set<TEntity>().Remove(record);
        var result = await _budgeteerContext.SaveChangesAsync();
    }

    public async Task<bool> Exists(Guid id)
    {
        if (_budgeteerContext == null) return false;
        return await _budgeteerContext.Set<TEntity>().AnyAsync(record => record.Id == id);
    }
}