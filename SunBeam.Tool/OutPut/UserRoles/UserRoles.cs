using System;
namespace SunBeam.Domain.Models
{
    public class UserRoles
    {
      public int Id { get; set; }
      public int BranchId { get; set; }
      public string UserInfoId { get; set; }
      public string RoleInfoId { get; set; }
      public bool IsArchived { get; set; }
    }
}
