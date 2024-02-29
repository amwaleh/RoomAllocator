using RoomManagement;
using RoomManagement.TenantManagement;

namespace RoomManagement.RoomOccupancy
{
    public interface IRoomOccupancy
    {
        bool IsRoomFull(Room room);
        void AddTenantToRoom(Room room, Tenant tenant);
        void AddRoom(Room room);
        void GetRoomOccupancyInfo(string roomId);
        string FindTenant(string tenantName);
    }
}
