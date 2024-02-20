using RoomManagement.RoomOccupancy;
using RoomManagement.TenantManagement;


namespace RoomManagement.RoomOccupancy
{
    public struct RoomContainer
        {
            public Room room;
            public List<Tenant> tenants;
        }
    public class RoomOccupancy : IRoomOccupancy
    {

        public Dictionary<string, RoomContainer> roomOccupancyContainer = new Dictionary<string, RoomContainer>(); // Change the accessibility modifier to match the class
        public bool IsRoomFull(Room room)
        {
           if (roomOccupancyContainer.ContainsKey(room.RoomId))
            {
                if (roomOccupancyContainer[room.RoomId].tenants.Count >= room.RoomCapacity)
                {
                    return true;
                }
            }
            return false;
        }

        public void AddTenantToRoom(Room room, Tenant tenant)
        {
            if (roomOccupancyContainer.ContainsKey(room.RoomId))
            {
                if (roomOccupancyContainer[room.RoomId].tenants.Count >= room.RoomCapacity)
                {
                    Console.WriteLine($"Room {room.RoomId} is full");
                    return;
                }
                roomOccupancyContainer[room.RoomId].tenants.Add(tenant);
                Console.WriteLine($"Room {room.RoomId} is occupied by {roomOccupancyContainer[room.RoomId].tenants.Count} tenants | remaining {room.RoomCapacity - roomOccupancyContainer[room.RoomId].tenants.Count} slots");
            }
            else
            {
                roomOccupancyContainer[room.RoomId] = new RoomContainer { room = room, tenants = new List<Tenant> { tenant } };
                Console.WriteLine($"Room {room.RoomId} is occupied by {tenant.TenantName}");
            }
        }

        public void AddRoom(Room room)
        {
           if (!roomOccupancyContainer.ContainsKey(room.RoomId)){
            roomOccupancyContainer.Add(room.RoomId, new RoomContainer {room = room , tenants = new List<Tenant>()});
            Console.WriteLine($"Room {room.RoomId} has been added");
           }
           else
           {
               Console.WriteLine($"Room {room.RoomId} already exists");
           }
        }

        public void GetRoomOccupancy(string roomId)
        {
            if (roomOccupancyContainer.ContainsKey(roomId))
            {
                Console.WriteLine($"Room {roomId} is occupied by {roomOccupancyContainer[roomId].tenants.Count} tenants | remaining {roomOccupancyContainer[roomId].room.RoomCapacity - roomOccupancyContainer[roomId].tenants.Count} slots");
            }
            else
            {
                Console.WriteLine($"Room {roomId} does not exist");
            }
        }

 
    }
}