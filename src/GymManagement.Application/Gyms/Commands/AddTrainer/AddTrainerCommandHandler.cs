using GymManagement.Application.Common.Interfaces;
using MediatR;

namespace GymManagement.Application.Gyms.Commands.AddTrainer;

public class AddTrainerCommandHandler : IRequestHandler<AddTrainerCommand>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IGymsRepository _gymsRepository;

    public AddTrainerCommandHandler(IGymsRepository gymsRepository, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _gymsRepository = gymsRepository;
    }
    public async Task Handle(AddTrainerCommand request, CancellationToken cancellationToken)
    {
        await _gymsRepository.AddTrainerAsync(request.GymId, request.Trainer);

        await _unitOfWork.CommitChangesAsync();
    }
}
