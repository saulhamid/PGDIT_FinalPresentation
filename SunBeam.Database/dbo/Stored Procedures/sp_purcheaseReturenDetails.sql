CREATE proc [dbo].[sp_purcheaseReturenDetails]
as
begin
select pu.Id
,pu.Discount
,pu.Quantity
,pu.InvoiceNo InvoiecNo
,pu.PurcheaseDate
,pu.ReturnDate
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
,(pro.Name +'-'+ ps.Name+''+u.Name) ProductName
,pud.Discount ProductDiscount
,pud.Quantity ProductQuantity
,pud.UnitePrice ProdutUnitePrice
,u.Name UOMName
,ps.Name ProductSize
from PurcheaseReturns pu 
left outer join Purchases pur on pur.Id=pu.PurchaseId
left outer join Suppliers sup on pu.SupplierId=sup.Id
left outer join Employee emp on emp.Id=pu.EmployeeId
left outer join PurcheaseDetails pud on pud.PurchaseId=pu.Id
--left outer join Products pro on pro.Id=pu.
left outer join UOM u on u.Id=pro.UOMId
left outer join ProductSizes ps on ps.Id=pro.ProductSizeId 
where pu.IsActive=1 and pu.IsArchive=0
end