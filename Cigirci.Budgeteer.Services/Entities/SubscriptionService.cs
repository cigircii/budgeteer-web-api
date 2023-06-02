namespace Cigirci.Budgeteer.Services.Entities;

using Contracts.Requests.Entities.Subscription;
using DbContext;
using Models.Entities;

public class SubscriptionService : BudgeteerService<Subscription>
{
    public SubscriptionService(BudgeteerContext? budgeteerContext = null) : base(budgeteerContext)
    {
    }

    public async Task<Subscription?> CreateSubscription(CreateSubscription createRequest)
    {
        var subscription = new Subscription
        {
            Name = createRequest.Name,
            Description = createRequest.Description,
            Start = createRequest.Start,
            End = createRequest.End,
            Recurrence = createRequest.Recurrence,
            Due = createRequest.Due,
            Active = createRequest.Active
        };

        return await Add(subscription);
    }

    public async Task<Subscription?> UpdateSubscription(Guid id, UpdateSubscription updateRequest)
    {
        var subscription = await Get(id);
        if (subscription is null) return null;

        if (!string.IsNullOrWhiteSpace(updateRequest.Name)) subscription.Name = updateRequest.Name;

        if (!string.IsNullOrWhiteSpace(updateRequest.Description)) subscription.Description = updateRequest.Description;

        if (updateRequest.Due.HasValue) subscription.Due = updateRequest.Due.Value;

        if (updateRequest.End.HasValue) subscription.End = updateRequest.End.Value;

        if (updateRequest.Recurrence.HasValue) subscription.Recurrence = updateRequest.Recurrence.Value;

        if (updateRequest.Start.HasValue) subscription.Start = updateRequest.Start.Value;

        return await Update(subscription);
    }
}