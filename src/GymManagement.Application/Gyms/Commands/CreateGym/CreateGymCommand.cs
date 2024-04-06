using ErrorOr;
using GymManagement.Domain.Gyms;
using GymManagement.Domain.Rooms;
using MediatR;

namespace GymManagement.Application.Gyms.Commands.CreateGym;

public record CreateGymCommand(Guid Id, string Name, ICollection<Room> Rooms = default, ICollection<string> Trainers = default) : IRequest<ErrorOr<Gym>>;