CREATE proc [dbo].[SP_PucheaseAllParam]
(
 @PurcheaseId int= null,
 @SupplierId int= null,
 @EmployeeId int= null,
 @InvoiecNo varchar(50) = null,
 @StartDate varchar(50) = null,
 @EndDate varchar(50) = null
)
as
begin
select pu.Id,pu.InvoiecNo,pu.[Date], sup.Name SupplierName,emp.Name EmployeeName,SUM(pud.Discount) TotolDiscount, SUM(pud.Quantity*pud.UnitePrice) GrandTotal 
,pu.Remarks from Purchases pu 
left outer join Suppliers sup on pu.SupplierId=sup.Id
left outer join Employee emp on emp.Id=pu.EmployeeId
left outer join PurcheaseDetails pud on pud.PurchaseId=pu.Id
group by pu.Id,pu.InvoiecNo,sup.Name,emp.Name,pu.[Date],pu.Remarks,pu.EmployeeId,pu.SupplierId
having
                (@PurcheaseId IS NULL OR (pu.Id = @PurcheaseId))
            AND (@SupplierId  IS NULL OR (pu.SupplierId  = @SupplierId ))
            AND (@EmployeeId  IS NULL OR (pu.EmployeeId  = @EmployeeId ))
            AND (@InvoiecNo  IS NULL OR (pu.InvoiecNo  = @InvoiecNo ))
            AND (CONVERT(datetime,@StartDate)  IS NULL OR (CONVERT(datetime,pu.[Date])  <= CONVERT(datetime,@StartDate) ))
            AND (CONVERT(datetime,@EndDate)  IS NULL OR (CONVERT(datetime,pu.[Date])  >= CONVERT(datetime,@EndDate) ))
end