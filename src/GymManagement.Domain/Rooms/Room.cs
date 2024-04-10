namespace GymManagement.Domain.Rooms;

public class Room
{


    public Guid Id { get; }

    public Guid GymId { get; }

    public string Name { get; } = null!;

    public int MaxDailySessions { get; }

    public Room(Guid gymId, int maxDailySessions, string name, Guid? roomId = null)
    {
        Id = roomId ?? Guid.NewGuid();
        Name = name;
        GymId = gymId;
        MaxDailySessions = maxDailySessions;
    }

    private Room()
    {

    }

}