using ErrorOr;
using GymManagement.Domain.Rooms;


namespace GymManagement.Domain.Gyms;

public class Gym
{
    private readonly int _maxRooms;

    private readonly List<Guid> _roomIds = new();
    private readonly List<Guid> _trainerIds = new();
    public Guid Id { get; private set; }

    public string Name { get; private set; }

    public Guid SubscriptionId { get; private set; }


    public Gym(Guid subscriptionId, string name, int maxRooms, Guid? id = null)
    {
        Id = id ?? Guid.NewGuid();
        Name = name;
        SubscriptionId = subscriptionId;
        _maxRooms = maxRooms;
    }
    public ErrorOr<Success> AddRoom(Room room)
    {
        if (_roomIds.Contains(room.Id))
        {
            return Error.Conflict(description: "Room already added to gym");
        }

        if (_roomIds.Count >= _maxRooms)
        {
            return GymErrors.CannotHaveMoreRoomsThanSubscriptionAllows;
        }

        _roomIds.Add(room.Id);

        return Result.Success;
    }

    public ErrorOr<Success> AddTrainer(Guid trainerId)
    {
        if (_trainerIds.Contains(trainerId))
        {
            return Error.Conflict(description: "Trainer already added to gym");
        }

        _trainerIds.Add(trainerId);
        return Result.Success;
    }



    public bool HasRoom(Guid roomId) => _roomIds.Contains(roomId);

    public void RemoveRoom(Guid roomId) => _roomIds.Remove(roomId);

    public bool HasTrainer(Guid trainerId) => _trainerIds.Contains(trainerId);

    private Gym()
    {

    }

}