//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SunBeam.Domain.Models
{
    using SunBeam.Domain;
    using System;
    using System.Collections.Generic;

    public partial class Users: BaseEntity
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string LogId { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string VerificationCode { get; set; }
        public Nullable<int> BranchId { get; set; }
        public string EmployeeId { get; set; }
        public Nullable<bool> IsAdmin { get; set; }
        public bool Remember { get; set; }
    }
}
