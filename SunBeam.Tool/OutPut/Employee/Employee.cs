using System;
namespace SunBeam.Domain.Models
{
    public class Employee
    {
      public int Id { get; set; }
      public int BranchId { get; set; }
      public string Code { get; set; }
      public string Name { get; set; }
      public string Salutation_E { get; set; }
      public string MiddleName { get; set; }
      public string LastName { get; set; }
      public int CountryId { get; set; }
      public int DivisionId { get; set; }
      public int DistrictId { get; set; }
      public string Mobile { get; set; }
      public string PermanentAddress { get; set; }
      public string PresentAddress { get; set; }
      public string PABX { get; set; }
      public string Email { get; set; }
      public string FAX { get; set; }
      public string Remarks { get; set; }
      public bool IsActive { get; set; }
      public bool IsArchive { get; set; }
      public string CreatedBy { get; set; }
      public string CreatedAt { get; set; }
      public string CreatedFrom { get; set; }
      public string LastUpdateBy { get; set; }
      public string LastUpdateAt { get; set; }
      public string LastUpdateFrom { get; set; }
    }
}
