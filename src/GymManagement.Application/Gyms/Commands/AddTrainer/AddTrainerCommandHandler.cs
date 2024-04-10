using System.Security.Cryptography.X509Certificates;
using ErrorOr;
using GymManagement.Application.Common.Interfaces;
using GymManagement.Domain.Gyms;
using MediatR;

namespace GymManagement.Application.Gyms.Commands.AddTrainer;

public class AddTrainerCommandHandler : IRequestHandler<AddTrainerCommand, ErrorOr<Success>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IGymsRepository _gymsRepository;

    public AddTrainerCommandHandler(IGymsRepository gymsRepository, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _gymsRepository = gymsRepository;
    }
    public async Task<ErrorOr<Success>> Handle(AddTrainerCommand request, CancellationToken cancellationToken)
    {
        Gym? gym = await _gymsRepository.GetByIdAsync(request.GymId);

        if (gym is null)
        {
            return Error.NotFound(description: "Gym not found");
        }

        var addTrainerResult = gym.AddTrainer(request.TrainerId);

        if (addTrainerResult.IsError)
        {
            return addTrainerResult.Errors;
        }
        await _gymsRepository.UpdateGymAsync(gym);

        await _unitOfWork.CommitChangesAsync();

        return Result.Success;
    }
}
