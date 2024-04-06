using GymManagement.Application.Common.Interfaces;
using MediatR;

namespace GymManagement.Application.Gyms.Commands;

public class DeleteGymCommandHandler : IRequestHandler<DeleteGymCommand>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IGymsRepository _gymsRepository;

    public DeleteGymCommandHandler(IGymsRepository gymsRepository, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _gymsRepository = gymsRepository;
    }

    public async Task Handle(DeleteGymCommand request, CancellationToken cancellationToken)
    {
        await _gymsRepository.DeleteGymAsync(request.Id);

        await _unitOfWork.CommitChangesAsync();
    }
}
