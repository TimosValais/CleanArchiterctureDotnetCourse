using ErrorOr;
using GymManagement.Domain.Gyms;
using MediatR;

namespace GymManagement.Application.Gyms.Queries.GetGym;


public record GetGymQuery(Guid Id) : IRequest<ErrorOr<Gym>>;