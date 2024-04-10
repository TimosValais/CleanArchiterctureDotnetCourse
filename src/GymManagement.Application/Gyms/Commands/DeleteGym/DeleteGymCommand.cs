using ErrorOr;
using MediatR;

namespace GymManagement.Application.Gyms.Commands;

public record DeleteGymCommand(Guid SubscriptionId, Guid Id) : IRequest<ErrorOr<Deleted>>;