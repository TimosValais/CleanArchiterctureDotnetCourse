using GymManagement.Domain.Gyms;

namespace GymManagement.Application.Common.Interfaces;

public interface IGymsRepository
{

    Task AddGymAsync(Gym gym);

    Task AddTrainerAsync(Guid gymId, string trainer);

    Task DeleteGymAsync(Guid gymId);

    Task<Gym?> GetByIdAsync(Guid gymId);

    Task<ICollection<Gym>> GetAll();

}