using System.Security.Cryptography.X509Certificates;
using RoomManagement.RoomOccupancy;
using RoomManagement.TenantManagement;


namespace RoomManagement.RoomOccupancy
{
    public struct RoomTenantInfo
        {
            public Room room;
            public List<Tenant> tenants;
            
        }
    public class RoomOccupancy : IRoomOccupancy
    {

        private Dictionary<string, RoomTenantInfo> roomOccupancyInfo = new Dictionary<string, RoomTenantInfo>(); 
        private readonly Dictionary <string, string> tenantRoomInfo = new Dictionary<string, string>();

        public RoomOccupancy()
        {
        }

        public bool IsRoomFull(Room room)
        {
           if (roomOccupancyInfo.ContainsKey(room.RoomId))
            {
                if (roomOccupancyInfo[room.RoomId].tenants.Count >= room.RoomCapacity)
                {
                    return true;
                }
            }
            return false;
        }

        public void AddTenantToRoom(Room room, Tenant tenant)
        {
            if (roomOccupancyInfo.ContainsKey(room.RoomId))
            {
                if (roomOccupancyInfo[room.RoomId].tenants.Count >= room.RoomCapacity)
                {
                    Console.WriteLine($"Room {room.RoomId} is full");
                    return;
                }
                roomOccupancyInfo[room.RoomId].tenants.Add(tenant);
                Console.WriteLine($"Room {room.RoomId} is occupied by {roomOccupancyInfo[room.RoomId].tenants.Count} tenants | remaining {room.RoomCapacity - roomOccupancyInfo[room.RoomId].tenants.Count} slots");
            }
            else
            {
                roomOccupancyInfo[room.RoomId] = new RoomTenantInfo { room = room, tenants = new List<Tenant> { tenant } };
                Console.WriteLine($"Room {room.RoomId} is occupied by {tenant.TenantName}");
            }
            tenantRoomInfo.Add(tenant.TenantName, room.RoomId);
        }

        public void AddRoom(Room room)
        {
           if (!roomOccupancyInfo.ContainsKey(room.RoomId)){
            roomOccupancyInfo.Add(room.RoomId, new RoomTenantInfo {room = room , tenants = new List<Tenant>()});
            Console.WriteLine($"Room {room.RoomId} has been added");
           }
           else
           {
               Console.WriteLine($"Room {room.RoomId} already exists");
           }
        }

        public void GetRoomOccupancyInfo(string roomId)
        {
            if (roomOccupancyInfo.ContainsKey(roomId))
            {
                Console.WriteLine($"Room {roomId} is occupied by {roomOccupancyInfo[roomId].tenants.Count} tenants | remaining {roomOccupancyInfo[roomId].room.RoomCapacity - roomOccupancyInfo[roomId].tenants.Count} slots");
            }
            else
            {
                Console.WriteLine($"Room {roomId} does not exist");
            }
        }

        public string FindTenant(string tenantName)
        {
            if (tenantRoomInfo.ContainsKey(tenantName))
            {
                return tenantRoomInfo[tenantName];
            }
            else
            {
                return "Tenant not found";
            }
        }
    }
}