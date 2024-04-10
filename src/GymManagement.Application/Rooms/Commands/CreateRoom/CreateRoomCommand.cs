using ErrorOr;
using GymManagement.Domain.Gyms;
using GymManagement.Domain.Rooms;
using MediatR;

namespace GymManagement.Application.Rooms.CreateRoom;

public record CreateRoomCommand(Room Room) : IRequest<ErrorOr<Gym>>;