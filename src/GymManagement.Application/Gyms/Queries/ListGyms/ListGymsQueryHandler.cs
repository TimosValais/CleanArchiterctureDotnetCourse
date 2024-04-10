


using ErrorOr;
using GymManagement.Application.Common.Interfaces;
using GymManagement.Domain.Gyms;
using MediatR;

namespace GymManagement.Application.Gyms.Queries.ListGyms;
public class ListGymsQueryHandler : IRequestHandler<ListGymsQuery, ErrorOr<ICollection<Gym>>>
{
    private readonly IGymsRepository _gymsRepository;

    public ListGymsQueryHandler(IGymsRepository gymsRepository)
    {
        _gymsRepository = gymsRepository;
    }
    public async Task<ErrorOr<ICollection<Gym>>> Handle(ListGymsQuery request, CancellationToken cancellationToken)
    {
        ICollection<Gym> gyms = await _gymsRepository.ListBySubscriptionIdAsync(request.SubscriptionId);

        return gyms.Count >= 0 ? gyms.ToList() : Error.Failure("Couldn't retrieve the gyms");
    }
}
