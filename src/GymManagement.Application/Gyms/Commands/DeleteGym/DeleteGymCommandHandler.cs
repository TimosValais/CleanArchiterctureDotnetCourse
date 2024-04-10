using ErrorOr;
using GymManagement.Application.Common.Interfaces;
using MediatR;

namespace GymManagement.Application.Gyms.Commands.DeleteGym;

public class DeleteGymCommandHandler : IRequestHandler<DeleteGymCommand, ErrorOr<Deleted>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IGymsRepository _gymsRepository;
    private readonly ISubscriptionsRepository _subscriptionsRepository;

    public DeleteGymCommandHandler(IGymsRepository gymsRepository, ISubscriptionsRepository subscriptionsRepository, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _gymsRepository = gymsRepository;
        _subscriptionsRepository = subscriptionsRepository;
    }

    public async Task<ErrorOr<Deleted>> Handle(DeleteGymCommand request, CancellationToken cancellationToken)
    {
        var gym = await _gymsRepository.GetByIdAsync(request.GymId);

        if (gym is null)
        {
            return Error.NotFound(description: "Gym not found");
        }

        var subscription = await _subscriptionsRepository.GetByIdAsync(request.SubscriptionId);

        if (subscription is null)
        {
            return Error.NotFound(description: "Subscription not found");
        }

        if (!subscription.HasGym(request.GymId))
        {
            return Error.Unexpected(description: "Gym not found");
        }

        subscription.RemoveGym(request.GymId);

        await _subscriptionsRepository.UpdateAsync(subscription);
        await _gymsRepository.RemoveGymAsync(gym);
        await _unitOfWork.CommitChangesAsync();

        return Result.Deleted;
    }
}
