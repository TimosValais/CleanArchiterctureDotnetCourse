using ErrorOr;
using GymManagement.Domain.Subscriptions;
using MediatR;

namespace GymManagement.Application.Subscriptions.Querries.GetSubscription;


public record GetSubscriptionQuerry(Guid SubscriptionId) : IRequest<ErrorOr<Subscription>>;