// See https://aka.ms/new-console-template for more information
using System.Collections;
using RoomManagement;
using RoomManagement.RoomOccupancy;
using RoomManagement.TenantManagement;

Room room1 = new Room("101", 1);

List<Room> availableRooms = new List<Room> {
   room1,
    room1,
    new Room("102", 3),
    new Room("103", 4),
    new Room("104", 5) };

List<Tenant> tenants = new List<Tenant>
{
    new Tenant("John"),
    new Tenant("Jane"),
    new Tenant("Michael"),
    new Tenant("Emily"),
    new Tenant("David"),
    new Tenant("Sarah"),
    new Tenant("Daniel"),
    new Tenant("Olivia"),
    new Tenant("Matthew"),
    new Tenant("Sophia")
};

RoomOccupancy roomOccupancy = new RoomOccupancy();

foreach (Room r in availableRooms)
{
    roomOccupancy.AddRoom(r);
}

Random random = new Random();

foreach (Tenant t in tenants)
{
    int randomIndex = random.Next(availableRooms.Count);
    

    Room randomRoom = availableRooms[randomIndex];
    roomOccupancy.AddTenantToRoom(randomRoom, t);
}
roomOccupancy.GetRoomOccupancy("101");