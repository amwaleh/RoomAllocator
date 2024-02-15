namespace RoomManagement.TenantManagement
{


    public class Tenant {
        public string TenantID {get; set;}
        public string TenantName {get; set;}

        public Tenant( string tenantName)
        {
            TenantID = Guid.NewGuid().ToString();
            TenantName = tenantName;
        }
      
    }
}