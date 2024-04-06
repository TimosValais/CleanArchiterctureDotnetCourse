namespace GymManagement.Domain.Subscriptions;

public class SubscriptionErrors
{

    public ICollection<(int errorCode, string errorMessage)> Errors { get; }


    public SubscriptionErrors(ICollection<(int errorCodes, string errorMessages)> errors)
    {
        Errors = errors;
    }

    public void AddError((int errorCode, string errorMessage) error)
    {
        Errors.Add(error);
    }

}