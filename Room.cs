namespace RoomManagement{
    public class Room {
        public string RoomId {get; set;}    
        public int RoomCapacity {get; set;}

        public Room(string roomId, int roomCapacity)
        {
            RoomId = roomId;
            RoomCapacity = roomCapacity;
        }
        
    
    }
}