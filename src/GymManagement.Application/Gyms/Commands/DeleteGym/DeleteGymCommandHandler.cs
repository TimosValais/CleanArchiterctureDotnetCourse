using ErrorOr;
using GymManagement.Application.Common.Interfaces;
using MediatR;

namespace GymManagement.Application.Gyms.Commands;

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
        if (!await _subscriptionsRepository.ExistsAsync(request.SubscriptionId))
        {
            return Error.NotFound("Subscription not found");
        }

        await _gymsRepository.DeleteGymAsync(request.Id);

        await _unitOfWork.CommitChangesAsync();

        return Result.Deleted;
    }
}
