CREATE proc PurcheaseDetail(
@Option int =null
,@PurchaseId int  =null
,@ProductId int	=null
,@ProductName nvarchar(50) =null
,@ProductCode nvarchar(50)=null
,@UnitePrice decimal(18,2) =null
,@Date nvarchar(50)=null
,@Quantity decimal(18,1)	=null
,@Discount decimal(18,2)	=null
,@Slup decimal(18,2)	=null
,@TotalPrice decimal(18,2)  =null
,@Remarks nvarchar(500)=null
,@IsActive	bit	=null
,@IsArchive bit	=null
,@CreatedAt nvarchar(50)=null
,@CreatedFrom nvarchar(50)=null
,@CreatedAtBy nvarchar(50)=null
,@LastUpdateBy nvarchar(50)	=null
,@LastUpdateAt nvarchar(50)	=null
,@LastUpdateFrom nvarchar(50) =null
)
as
begin
if(@Option = 1)
begin
INSERT INTO dbo.PurcheaseDetails
           (PurchaseId
           ,ProductId
           ,UnitePrice
           ,Date
           ,Quantity
           ,Discount
           ,Slup
           ,TotalPrice
           ,Remarks
           ,IsActive
           ,IsArchive
           ,CreatedAt
           ,CreatedFrom
           ,CreatedAtBy)
     VALUES(
@PurchaseId
,@ProductId
,@UnitePrice
,@Date
,@Quantity
,@Discount
,@Slup
,@TotalPrice
,@Remarks
,0,1
,@CreatedAt
,@CreatedFrom
,@CreatedAtBy)
end
if(@Option = 2)
begin
update PurcheaseDetails set
PurchaseId=@PurchaseId
,ProductId=@ProductId
,UnitePrice=@UnitePrice
,Date=@Date
,Quantity=@Quantity
,Discount=@Discount
,Slup=@Slup
,TotalPrice=@TotalPrice
,Remarks=@Remarks
,IsActive=@IsActive
,IsArchive=@IsArchive
,LastUpdateBy=@LastUpdateBy
,LastUpdateAt=@LastUpdateAt
,LastUpdateFrom=@LastUpdateFrom
end
if(@Option = 3)
begin
select *from   PurcheaseDetails
end
if(@Option = 4)
begin
select *from   PurcheaseDetails	 where PurchaseId=	@PurchaseId
end
end