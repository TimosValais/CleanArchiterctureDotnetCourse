using ErrorOr;
using GymManagement.Application.Common.Interfaces;
using GymManagement.Domain.Gyms;
using MediatR;

namespace GymManagement.Application.Rooms.CreateRoom;


class CreateRoomCommandHandler : IRequestHandler<CreateRoomCommand, ErrorOr<Gym>>
{
    private readonly IGymsRepository _gymsRepository;

    public CreateRoomCommandHandler(IGymsRepository gymsRepository)
    {
        _gymsRepository = gymsRepository;
    }
    public Task<ErrorOr<Gym>> Handle(CreateRoomCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
