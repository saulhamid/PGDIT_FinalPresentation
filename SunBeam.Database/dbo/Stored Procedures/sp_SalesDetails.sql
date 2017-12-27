CREATE proc [dbo].[sp_SalesDetails]
as
begin
select sal.Id,sal.InvoiecNo,zon.Name ZoneName,cus.Name CustomerName,(sal.PackQuantity*sal.PackUnitPrice) TotalPackPrice, 
SUM(sad.Discount) TotalDiscount,SUM(sad.AssaignQuantity) AssaignQuantity ,
SUM(sad.Replace) TotalReplace,SUM(sad.[Return]) TotalReturn,SUM(sad.SalesQuantity) SalesQuantity,SUM(sad.TotalSlupPrice) TotalSlupPrice,
SUM(sad.SalesQuantity*sad.UnitePrice) TotalSalesPrice from Sales sal
left outer join SalesDetails sad on sad.SalesId=sal.Id
left outer join Customers cus on cus.Id=sal.CustomerId
left outer join ZoneOrAreas zon on zon.Id=sal.ZoneOrAreaId
group by sal.Id,sal.InvoiecNo,zon.Name,cus.Name,sal.PackQuantity,sal.PackUnitPrice
end