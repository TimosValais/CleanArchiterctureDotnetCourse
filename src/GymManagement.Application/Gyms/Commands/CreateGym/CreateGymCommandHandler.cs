using ErrorOr;
using GymManagement.Application.Common.Interfaces;
using GymManagement.Domain.Gyms;
using MediatR;

namespace GymManagement.Application.Gyms.Commands.CreateGym;

public class CreateGymCommandHandler : IRequestHandler<CreateGymCommand, ErrorOr<Gym>>
{
    private readonly IGymsRepository _gymsRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateGymCommandHandler(IGymsRepository gymsRepository, IUnitOfWork unitOfWork)
    {
        _gymsRepository = gymsRepository;
        _unitOfWork = unitOfWork;
    }
    public async Task<ErrorOr<Gym>> Handle(CreateGymCommand request, CancellationToken cancellationToken)
    {

        Gym gym = new(request.Id, request.Name, request.Rooms, request.Trainers);

        await _gymsRepository.AddGymAsync(gym);

        await _unitOfWork.CommitChangesAsync();

        return gym;

    }
}
