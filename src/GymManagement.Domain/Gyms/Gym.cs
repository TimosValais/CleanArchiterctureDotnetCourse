using GymManagement.Domain.Rooms;

namespace GymManagement.Domain.Gyms;

public class Gym
{

    public Guid Id { get; private set; }

    public string Name { get; private set; }

    public ICollection<Room> Rooms { get; private set; }

    public ICollection<string> Trainers { get; private set; }
    public Gym(Guid id, string name, ICollection<Room> rooms = null, ICollection<string> trainers = null)
    {
        Id = id;
        Name = name;
        Rooms = rooms ?? new List<Room>();
        Trainers = trainers ?? new List<string>();
    }

    private Gym()
    {

    }

}