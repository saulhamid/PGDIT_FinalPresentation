using System;
namespace SunBeam.Domain.Models
{
    public class ProductDetails
    {
      public int Id { get; set; }
      public int ProductId { get; set; }
      public int UOMId { get; set; }
      public int ProductBrandId { get; set; }
      public int ProductCatagoriesId { get; set; }
      public int ProductColorId { get; set; }
      public int ProductSizeId { get; set; }
      public int ProductTypeId { get; set; }
      public int SupplierId { get; set; }
      public decimal Quantity { get; set; }
      public decimal UnitPrice { get; set; }
      public decimal OpenQuantity { get; set; }
      public int MinimumStock { get; set; }
      public decimal OtherCost { get; set; }
      public decimal Discount { get; set; }
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
