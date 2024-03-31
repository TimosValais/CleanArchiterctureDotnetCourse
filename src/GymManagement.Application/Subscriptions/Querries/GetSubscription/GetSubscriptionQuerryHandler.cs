using ErrorOr;
using GymManagement.Application.Common.Interfaces;
using GymManagement.Domain.Subscriptions;
using MediatR;

namespace GymManagement.Application.Subscriptions.Querries.GetSubscription;

class GetSubscriptionQuerryHandler : IRequestHandler<GetSubscriptionQuerry, ErrorOr<Subscription>>
{

    private readonly ISubscriptionsRepository _subscriptionsRepository;

    public GetSubscriptionQuerryHandler(ISubscriptionsRepository subscriptionsRepository)
    {
        _subscriptionsRepository = subscriptionsRepository;
    }
    public async Task<ErrorOr<Subscription>> Handle(GetSubscriptionQuerry request, CancellationToken cancellationToken)
    {
        Subscription? subscription = await _subscriptionsRepository.GetById(request.SubscriptionId);
        return subscription is null
            ? Error.NotFound($"Subscription with Id : {request.SubscriptionId} not found")
            : subscription;
    }
}
