namespace RoomManagement.TenantManagement
{


    public class Tenant {
        private string tenantID ;
        public string TenantName {get; set;}

        public Tenant( string tenantName)
        {
            tenantID = Guid.NewGuid().ToString();
            TenantName = tenantName;
        }
      
    }
}