CREATE proc [dbo].[PurcheasReturnsByInvoice]
(
@InvoiecNo nvarchar(200)
)
as
begin 
if @InvoiecNo != '' 
select pur.Id,pp.Id ProductId,pur.Date, pur.InvoiecNo,purd.Code ProductCode,(purd.Name +'-'+ ps.Name+''+u.Name) ProductName,purd.Quantity,
purd.UnitePrice,purd.Discount,sup.Name SupplierName,emp.Name Employee from Purchases pur 
left outer join PurcheaseDetails purd on pur.Id=purd.PurchaseId
left outer join Products pp on pp.Id=purd.ProductId
left outer join Suppliers sup on sup.Id=pur.SupplierId
left outer join Employee emp on emp.Id=pur.EmployeeId
left outer join UOM u on u.Id=pp.UOMId
left outer join ProductSizes ps on ps.Id=pp.ProductSizeId 
where pur.InvoiecNo = @InvoiecNo and (select st.TotalQuantity from Stocks st ) > 0
else 
select pur.Id,pp.Id ProductId,pur.Date, pur.InvoiecNo,purd.Code ProductCode,(purd.Name +'-'+ ps.Name+''+u.Name) ProductName
,purd.Quantity,
purd.UnitePrice,purd.Discount,sup.Name SupplierName,emp.Name Employee 
from Purchases pur 
left outer join PurcheaseDetails purd on pur.Id=purd.PurchaseId
left outer join Products pp on pp.Id=purd.ProductId
left outer join Suppliers sup on sup.Id=pur.SupplierId
left outer join Employee emp on emp.Id=pur.EmployeeId
left outer join Stocks st on st.ProductId=purd.ProductId
left outer join UOM u on u.Id=pp.UOMId
left outer join ProductSizes ps on ps.Id=pp.ProductSizeId 
where st.TotalQuantity > 0
end