using ErrorOr;
using GymManagement.Application.Common.Interfaces;
using GymManagement.Domain.Gyms;
using MediatR;

namespace GymManagement.Application.Gyms.Queries.GetGym;

public class GetGymQueryHandler : IRequestHandler<GetGymQuery, ErrorOr<Gym>>
{
    private readonly IGymsRepository _gymsRepository;

    public GetGymQueryHandler(IGymsRepository gymsRepository)
    {
        _gymsRepository = gymsRepository;
    }
    public async Task<ErrorOr<Gym>> Handle(GetGymQuery request, CancellationToken cancellationToken)
    {
        Gym? gym = await _gymsRepository.GetByIdAsync(request.Id);

        return gym is null
        ? Error.NotFound($"Gym with Id : {request.Id} was not found")
        : gym;
    }
}
