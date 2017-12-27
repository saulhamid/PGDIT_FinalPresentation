CREATE proc [dbo].[SP_Purchease] (
@Option int =null,
@Id int=null
,@InvoiecNo nvarchar(200)=null
,@SupplierId int=null
,@EmployeeId int=null
,@Date nvarchar(50)=null
,@StartDate nvarchar(50)=null
,@EndDate nvarchar(50)=null
,@Remarks nvarchar(500)=null
,@IsActive bit=null
,@IsArchive bit=null
,@CreatedBy nvarchar(50)=null
,@CreatedAt nvarchar(50)=null
,@CreatedFrom nvarchar(50)=null
,@LastUpdateBy nvarchar(50)=null
,@LastUpdateAt nvarchar(50)=null
,@LastUpdateFrom nvarchar(50)=null
,@MSG nvarchar(500)=null out
)
as
begin
if(@Option = 1)
begin
INSERT INTO dbo.Purchases(
Id,
InvoiecNo
,SupplierId
,EmployeeId
,Date
,Remarks
,IsActive
,IsArchive
,CreatedBy
,CreatedAt
,CreatedFrom)
VALUES(
@id,
@InvoiecNo
,@SupplierId
,@EmployeeId
,@Date
,@Remarks
,1
,0
,@CreatedBy
,@CreatedAt
,@CreatedFrom)
end
if(@Option = 2)
begin
update dbo.Purchases set 
@InvoiecNo=InvoiecNo
,SupplierId=@SupplierId
,EmployeeId=@EmployeeId
,Date=@Date
,Remarks=@Remarks
,IsActive=0
,IsArchive=1
,LastUpdateBy=@LastUpdateBy
,LastUpdateAt=@LastUpdateAt
,LastUpdateFrom=@LastUpdateFrom
where id=@id
end
if(@Option = 3)
begin
select pu.Id
,pu.InvoiecNo
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
,SUM(pud.Discount) TotalDiscount
,SUM(pud.Quantity) ProductQuantity
,SUM(pud.Quantity*pud.UnitePrice) SubAmount
,SUM(pud.Quantity*pud.UnitePrice-pud.Discount) GrandTotal
from Purchases pu 
left outer join Suppliers sup on pu.SupplierId=sup.Id
left outer join Employee emp on emp.Id=pu.EmployeeId
left outer join PurcheaseDetails pud on pud.PurchaseId=pu.Id
left outer join Products pro on pro.Id=pud.ProductId
left outer join UOM u on u.Id=pro.UOMId
left outer join ProductSizes ps on ps.Id=pro.ProductSizeId
group by 
pu.Id
,pu.InvoiecNo
,pu.[Date]
,sup.Id 
,sup.Code 
,sup.Name 
,sup.Mobile 
,sup.Email 
,sup.PresentAddress 
,emp.Id 
,emp.Code 
,emp.Name 
,emp.Mobile 
,emp.Email 
,emp.PresentAddress 
,pu.IsActive
, pu.IsArchive
having pu.IsActive=1 and pu.IsArchive=0 and
                (@Id IS  NULL OR (pu.Id = @Id))
            AND (@InvoiecNo  IS  NULL OR (pu.InvoiecNo  = @InvoiecNo ))
            AND (@SupplierId IS  NULL OR (sup.Id     = @SupplierId    ))
            AND (@StartDate  IS  NULL OR (pu.[Date]     >=CONVERT(datetime, @StartDate)))
            AND (@EndDate   IS  NULL OR (pu.[Date]     <= CONVERT(datetime, @EndDate)  ))
end
if(@Option = 4)
begin
select * from dbo.Purchases where id=@Id
end
end