Create proc [dbo].[SP_PurcheaseReturnDetail]
(
@PurcheaseReturnId int = null
,@InvoiceNO nvarchar(50) = null
,@ProductId int = null
,@SupplierId int = null
,@StartDate nvarchar(50) = null
,@EndDate nvarchar(50) = null
)
as
begin
select pu.Id
,pu.InvoiceNo
,pu.[Date]
,sup.Id SupplierId
,sup.Code SupplierCode
,sup.Name SupplierName
,sup.Mobile SupplierMobile
,sup.Email SupplierEmail
,sup.PresentAddress SupplierPresentAddress
,emp.Id EmployeeId
,emp.Code EmployeeCode
,emp.Name EmployeeName
,emp.Mobile EmployeeMobile
,emp.Email EmployeeEmail
,emp.PresentAddress EmployeePresentAddress
,pro.Id ProductId
,pro.Code ProductCode
,pro.Name ProductName
,pud.Discount ProductDiscount
,pud.Quantity ProductQuantity
,pud.UnitePrice ProdutUnitePrice
,pud.Quantity+pud.UnitePrice SubAmount
,pud.Quantity+pud.UnitePrice-pud.Discount TotalAmount
,u.Name UOMName
,ps.Name ProductSize
from PurcheaseReturns pu 
left outer join Suppliers sup on pu.SupplierId=sup.Id
left outer join Employee emp on emp.Id=pu.EmployeeId
left outer join PurcheaseReturnDetails pud on pud.PurchaseReturnId=pu.Id
left outer join Products pro on pro.Id=pud.ProductId
left outer join UOM u on u.Id=pro.UOMId
left outer join ProductSizes ps on ps.Id=pro.ProductSizeId
  WHERE
                (@PurcheaseReturnId IS  NULL OR (pu.Id = @PurcheaseReturnId))
            AND (@InvoiceNO  IS  NULL OR (pu.InvoiceNo  = @InvoiceNO ))
            AND (@ProductId  IS  NULL OR (pro.Id  = @ProductId ))
            AND (@SupplierId IS  NULL OR (sup.Id     = @SupplierId    ))
            AND (@StartDate  IS  NULL OR (pu.[Date]     >=CONVERT(datetime, @StartDate)))
            AND (@EndDate   IS  NULL OR (pu.[Date]     <= CONVERT(datetime, @EndDate)  ))
end