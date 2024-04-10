using ErrorOr;
using GymManagement.Domain.Gyms;
using MediatR;

namespace GymManagement.Application.Gyms.Queries.ListGyms;

public record ListGymQuery(Guid SubscriptionId) : IRequest<ErrorOr<ICollection<Gym>>>;