namespace GymManagement.Domain.Rooms;

public class Room
{


    public Guid Id { get; private set; }

    public string Name { get; private set; }

    public Room(Guid id, string name)
    {
        Id = id;
        Name = name;
    }

    private Room()
    {

    }

}