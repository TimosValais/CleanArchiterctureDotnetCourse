using ErrorOr;
using GymManagement.Domain.Gyms;
using GymManagement.Domain.Rooms;
using MediatR;

namespace GymManagement.Application.Gyms.Commands.CreateGym;

public record CreateGymCommand(Guid SubscriptionId, Guid Id, string Name) : IRequest<ErrorOr<Gym>>;