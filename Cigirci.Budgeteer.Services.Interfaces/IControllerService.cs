namespace Cigirci.Budgeteer.Services.Interfaces;

using Cigirci.Budgeteer.Models;


/// <summary>
/// Base interface for all services.
/// </summary>
/// <typeparam name="Entity">The entity (table) you're accessing</typeparam>
/// <typeparam name="Record">The record(s) (rows) you're retrieving</typeparam>
public interface IControllerService<Entity> where Entity : Record
{
    Task<Record>? Get<T>(Guid id) where T : Entity;
    Task<IEnumerable<Record>>? GetAll<T>() where T : Entity;
    Task Create<T>(Record record) where T : Entity;
    Task Update<T>(Record record) where T : Entity;
    Task Delete<T>(Record record) where T : Entity;
    Task<bool> Exists<T>(Record record) where T : Entity;
}