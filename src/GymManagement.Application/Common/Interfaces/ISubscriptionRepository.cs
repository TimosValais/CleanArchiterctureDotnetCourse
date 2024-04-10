
using GymManagement.Domain.Subscriptions;

namespace GymManagement.Application.Common.Interfaces;

public interface ISubscriptionsRepository
{


    Task<Subscription?> GetByAdminIdAsync(Guid adminId);
    Task<List<Subscription>> ListAsync();
    Task RemoveSubscriptionAsync(Subscription subscription);
    Task UpdateAsync(Subscription subscription);

    Task AddSubscriptionAsync(Subscription subscription);

    Task<bool> ExistsAsync(Guid subscriptionId);
    Task<Subscription?> GetByIdAsync(Guid Id);
}