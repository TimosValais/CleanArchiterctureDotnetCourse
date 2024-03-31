using GymManagement.Application.Subscriptions.Commands.CreateSubscription;
using GymManagement.Contracts.Subscriptions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ErrorOr;
using GymManagement.Domain.Subscriptions;
using GymManagement.Application.Subscriptions.Querries.GetSubscription;
namespace GymManagement.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class SubscriptionsController : ControllerBase
{
    private readonly ISender _mediator;

    public SubscriptionsController(ISender mediator)
    {
        _mediator = mediator;
    }
    [HttpPost]
    public async Task<IActionResult> CreateSubscription(CreateSubscriptionRequest request)
    {
        var command = new CreateSubscriptionCommand(request.SubscriptionType.ToString(), request.AdminId);
        var createSubscriptionResult = await _mediator.Send(command);

        return createSubscriptionResult.MatchFirst(
            subscription => Ok(new SubscriptionResponse(subscription.Id, request.SubscriptionType)),
            error => Problem()
        );
    }

    [HttpGet("{subscriptionId:guid}")]
    public async Task<IActionResult> GetSubscription(Guid subscriptionId)
    {
        var getSubscriptionResult = await _mediator.Send(new GetSubscriptionQuerry(subscriptionId));
        return getSubscriptionResult.Match(
            subscription => Ok(new SubscriptionResponse(subscription.Id, Enum.Parse<SubscriptionType>(subscription.SubscriptionType))),
            errors =>
            {
                string error = "";
                errors.ForEach(err =>
                    error += err.Code
                );
                return StatusCode(404, error);
            }
        );
    }
}