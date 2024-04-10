using GymManagement.Domain.Gyms;

namespace GymManagement.Application.Common.Interfaces;

public interface IGymsRepository
{


    Task<bool> ExistsAsync(Guid id);
    Task RemoveGymAsync(Gym gym);
    Task RemoveRangeAsync(List<Gym> gyms);

    Task AddGymAsync(Gym gym);

    Task UpdateGymAsync(Gym gym);

    Task<Gym?> GetByIdAsync(Guid gymId);

    Task<ICollection<Gym>> ListBySubscriptionIdAsync(Guid subscriptionId);

}