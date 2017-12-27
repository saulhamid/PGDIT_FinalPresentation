CREATE proc [dbo].[sp_salesDatailrpts]
 as
 begin
 select 
sa.Id
,sa.Date
,ISNULL(sa.Discount,0) Discount
,sa.EventName
,ISNULL(sa.EventAamount,0) EventAamount
,sa.InvoiecNo
,ISNULL(sa.PackQuantity,0) PackQuantity
,ISNULL(sa.PackUnitPrice,0) PackUnitPrice
,ISNULL(sa.GrandTotal,0) GrandTotal
,ISNULL(sa.TotalDiscount,0) TotalDiscount
,ISNULL(sa.TotalPaid,0) TotalPaid
,ISNULL(zo.Id,0) ZoneId
,zo.Name ZoneName
,ma.Id MarketId
,ma.Name MarketName
,pro.Id ProductId
,pro.Code ProductCode
,pro.Name ProductName
,ISNULL(sad.Discount,0) ProDiscount
,ISNULL(sad.AssaignQuantity,0) AssaignQuantity
,ISNULL(sad.SalesQuantity,0) SalesQuantity
,ISNULL(sad.UnitePrice,0) ProUnitePrice
,sad.Date ProDatetime
,ISNULL(sad.[Return],0) ProRetrun
,ISNULL(sad.Replace,0) ProReplace
,ISNULL(sad.Slup,0) ProSlup
,ISNULL(sad.SalesQuantity*sad.UnitePrice,0) TotalPrice
,ISNULL(sad.UnitePrice*sad.SalesQuantity,0) TotalSalesQuantity
,ISNULL(sad.UnitePrice*sad.[Replace],0) TotalReplace
,ISNULL(sad.UnitePrice*sad.[Return],0) TotalReturn
,ISNULL(sad.UnitePrice*sad.Slup,0) TotalSlup
,u.Name UOMName
,ps.Name ProductSize
,emp.Id EmployeeId
,emp.Code EmployeeCode
,emp.Name EmployeeName
,emp.Mobile EmployeeMobile
,emp.Email EmployeeEmail
,emp.PresentAddress EmployeePresentAddress
,cus.Id CustomerId
,cus.Code CustomerCode
,cus.Name CustomerName
,cus.Mobile CustomerMobile
,cus.Email CustomerEmail
,cus.PresentAddress CustomerPresentAddress
from Sales sa
left outer join SalesDetails sad on sad.SalesId= sa.Id
left outer join ZoneOrAreas zo on zo.Id= sa.ZoneOrAreaId
left outer join Markets ma on ma.ZoneOrAreaId= zo.Id
left outer join Products pro on pro.Id=sad.ProductId
left outer join UOM u on u.Id=pro.UOMId
left outer join ProductSizes ps on ps.Id=pro.ProductSizeId
left outer join Employee emp on emp.Id=sa.EmployeeId
left outer join Customers cus on cus.Id=sa.CustomerId
end