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

    public partial class ProductAssign: BaseEntity
    {
        public int Id { get; set; }
        public string InvoiecNo { get; set; }
        public Nullable<int> ProductId { get; set; }
        public Nullable<int> CustomerId { get; set; }
        public Nullable<int> ZoneOrAreaId { get; set; }
        public Nullable<int> EmployeeId { get; set; }
        public Nullable<decimal> TotalDiscount { get; set; }
        public Nullable<decimal> TotalSlup { get; set; }
        public Nullable<decimal> TotalQuantity { get; set; }
        public Nullable<decimal> TotalPaid { get; set; }
        public Nullable<decimal> TotalPrice { get; set; }
        public Nullable<decimal> GrandTotal { get; set; }
        public string Date { get; set; }
        public Nullable<decimal> OpeningQuantity { get; set; }
      
    }
}
