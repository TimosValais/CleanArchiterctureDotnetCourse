using GymManagement.Application.Common.Interfaces;
using GymManagement.Domain.Gyms;
using GymManagement.Infrastructure.Common.Persistence;

namespace GymManagement.Infrastructure.Gyms.Persistence;

class GymsRepository : IGymsRepository
{
    private readonly GymManagementDbContext _dbContext;

    public GymsRepository(GymManagementDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task AddGymAsync(Gym gym)
    {
        await _dbContext.Gyms.AddAsync(gym);
    }


    public Task DeleteGymAsync(Guid gymId)
    {
        throw new NotImplementedException();
    }

    public Task<ICollection<Gym>> GetAll(Guid subscriptionId)
    {
        throw new NotImplementedException();
    }

    public Task<Gym?> GetByIdAsync(Guid gymId)
    {
        throw new NotImplementedException();
    }

    public Task UpdateGymAsync(Gym gym)
    {
        _dbContext.Update(gym);
        return Task.CompletedTask;
    }
}
