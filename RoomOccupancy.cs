using RoomManagement.TenantManagement;



namespace RoomManagement.RoomOccupancy
{
    public class RoomOccupancy
    {


        public Dictionary<Room, List<Tenant>> roomOccupancyList = new Dictionary<Room, List<Tenant>>();

        public bool IsRoomFull(Room room)
        {
            if (roomOccupancyList.ContainsKey(room))
            {
                if (roomOccupancyList[room].Count >= room.RoomCapacity)
                {
                    return true;
                }
            }
            return false;
        }
        public void AddTenantToRoom(Room room, Tenant tenant)
        {


            if (roomOccupancyList.ContainsKey(room))
            {

                if (IsRoomFull(room))
                {
                    Console.WriteLine($"Room {room.RoomId} is full");
                    return;
                }
                roomOccupancyList[room].Add(tenant);
                Console.WriteLine($"Room {room.RoomId} is occupied by {roomOccupancyList[room].Count} tenants | remaining {room.RoomCapacity - roomOccupancyList[room].Count} slots");

            }
            else
            {
                roomOccupancyList.Add(room, new List<Tenant>() { tenant });
                Console.WriteLine($"Room {room.RoomId} is occupied by {tenant.TenantName}");
            }
        }
        public void AddRoom(Room room)
        {

            if (roomOccupancyList.ContainsKey(room))
            {
                Console.WriteLine($"Room {room.RoomId} already exists");
            }
            else
            {
                roomOccupancyList.Add(room, new List<Tenant>());
                Console.WriteLine($"Room {room.RoomId} has been added");
            }


        }

        public void GetRoomOccupancy(Room room)
        {
            if (roomOccupancyList.ContainsKey(room))
            {
                Console.WriteLine($"Room {room.RoomId} is occupied by {roomOccupancyList[room].Count} tenants");
            }
            else
            {
                Console.WriteLine($"Room {room.RoomId} is empty");
            }
        }
    }
}