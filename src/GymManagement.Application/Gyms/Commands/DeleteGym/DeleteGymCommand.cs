using MediatR;

namespace GymManagement.Application.Gyms.Commands;

public record DeleteGymCommand(Guid Id) : IRequest;