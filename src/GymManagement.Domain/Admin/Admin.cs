using GymManagement.Domain.Gyms;

namespace GymManagement.Domain.Admin;


public class Admin
{
    public Guid Id { get; private set; }

    public string Name { get; private set; }

    public ICollection<Gym> Gyms { get; private set; }
    public Admin(Guid id, string name, ICollection<Gym> gyms = null)
    {
        Id = id;
        Name = name;
        Gyms = gyms ?? new List<Gym>();
    }
    private Admin()
    {

    }
}