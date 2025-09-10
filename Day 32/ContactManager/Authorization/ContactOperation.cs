using Microsoft.AspNetCore.Authorization.Infrastructure;

namespace ContactManager.Authorization
{
    public static class ContactOperations
    {
        public static OperationAuthorizationRequirement Create =   
          new OperationAuthorizationRequirement {Name="Create"};
        public static OperationAuthorizationRequirement Read = 
          new OperationAuthorizationRequirement {Name="Read"};  
        public static OperationAuthorizationRequirement Update = 
          new OperationAuthorizationRequirement {Name="Update"}; 
        public static OperationAuthorizationRequirement Delete = 
          new OperationAuthorizationRequirement {Name="Delete"};
        public static OperationAuthorizationRequirement Approve = 
          new OperationAuthorizationRequirement {Name="Approve"};
        public static OperationAuthorizationRequirement Reject = 
          new OperationAuthorizationRequirement {Name="Reject"};
    }

    public class Constants
    {
        public static readonly string ContactAdministratorsRole = "ContactAdministrators";
        public static readonly string ContactManagersRole = "ContactManagers";
    }
}