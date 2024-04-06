


using ErrorOr;
using GymManagement.Application.Common.Interfaces;
using GymManagement.Domain.Gyms;
using MediatR;

namespace GymManagement.Application.Gyms.Queries.ListGyms;
public class ListGymsQueryHandler : IRequestHandler<ListGymQuery, ErrorOr<ICollection<Gym>>>
{
    private readonly IGymsRepository _gymsRepository;

    public ListGymsQueryHandler(IGymsRepository gymsRepository)
    {
        _gymsRepository = gymsRepository;
    }
    public async Task<ErrorOr<ICollection<Gym>>> Handle(ListGymQuery request, CancellationToken cancellationToken)
    {
        ICollection<Gym> gyms = await _gymsRepository.GetAll();

        return gyms.Count >= 0 ? gyms.ToList() : Error.Failure("Couldn't retrieve the gyms");
    }
}
