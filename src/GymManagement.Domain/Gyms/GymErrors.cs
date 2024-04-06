namespace GymManagement.Domain.Gyms;

public class GymErrors
{

    public ICollection<(int errorCode, string errorMessage)> Errors { get; }


    public GymErrors(ICollection<(int errorCodes, string errorMessages)> errors)
    {
        Errors = errors;
    }

    public void AddError((int errorCode, string errorMessage) error)
    {
        Errors.Add(error);
    }

}