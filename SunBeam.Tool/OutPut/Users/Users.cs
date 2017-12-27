using System;
namespace SunBeam.Domain.Models
{
    public class Users
    {
      public int Id { get; set; }
      public  FullName { get; set; }
      public  UserName { get; set; }
      public  Email { get; set; }
      public  LogId { get; set; }
      public  Password { get; set; }
      public  VerificationCode { get; set; }
      public int BranchId { get; set; }
      public string EmployeeId { get; set; }
      public bool IsAdmin { get; set; }
      public bool Remember { get; set; }
      public bool IsActive { get; set; }
      public bool IsVerified { get; set; }
      public bool IsArchived { get; set; }
      public string CreatedBy { get; set; }
      public string CreatedAt { get; set; }
      public  CreatedFrom { get; set; }
      public string LastUpdateBy { get; set; }
      public string LastUpdateAt { get; set; }
      public  LastUpdateFrom { get; set; }
    }
}
