namespace Cigirci.Budgeteer.Interfaces.Services;

/// <summary>
/// Base interface for all services.
/// </summary>
/// <typeparam name="TRecord">The record(s) (rows) you're retrieving</typeparam>
public interface IBudgeteerService<TRecord>
{
    Task<TRecord> Get(Guid id);

    Task<IEnumerable<TRecord>> GetAll();

    Task<TRecord> Create(TRecord record);

    Task<TRecord> Update(TRecord record);

    Task Delete(Guid id);

    Task<bool> Exists(Guid id);
}