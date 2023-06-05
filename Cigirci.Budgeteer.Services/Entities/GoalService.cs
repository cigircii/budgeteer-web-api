namespace Cigirci.Budgeteer.Services.Entities;

using Contracts.Requests.Entities.Goal;
using DbContext;
using Models.Entities;

public class GoalService : BudgeteerService<Goal>
{
    public GoalService(BudgeteerContext? budgeteerContext = null) : base(budgeteerContext)
    {
    }
    
    public async Task<Goal?> CreateGoal(CreateGoal createRequest)
    {
        var goal = new Goal
        {
            Name = createRequest.Name,
            Description = createRequest.Description,
            Amount = createRequest.Amount,
            Balance = createRequest.Balance
        };

        return await Add(goal);
    }

    public async Task<Goal?> UpdateGoal(Guid id, UpdateGoal updateRequest)
    {
        var goal = await Get(id);
        if (goal is null) return null;
        
        if (!string.IsNullOrWhiteSpace(updateRequest.Name)) goal.Name = updateRequest.Name;
        if (!string.IsNullOrWhiteSpace(updateRequest.Description)) goal.Description = updateRequest.Description;
        if (updateRequest.Amount.HasValue) goal.Amount = updateRequest.Amount.Value;
        if (updateRequest.Balance.HasValue) goal.Balance = updateRequest.Balance.Value;
        if (updateRequest.State.HasValue) goal.Status.State = updateRequest.State.Value;
            
        return await Update(goal);
    }
}