using MediatR;

namespace GymManagement.Application.Gyms.Commands.AddTrainer;

public record AddTrainerCommand(Guid GymId, string Trainer) : IRequest;