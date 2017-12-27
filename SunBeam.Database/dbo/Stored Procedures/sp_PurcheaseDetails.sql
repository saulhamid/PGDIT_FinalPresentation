
CREATE  proc [dbo].[sp_PurcheaseDetails]
(
@Id		int = null,
@PurchaseId		int = null,
@ProductId		int = null,
@UnitePrice		decimal = null,
@Date		nvarchar(50) = null,
@Quantity		decimal = null,
@Discount		decimal = null,
@Slup		decimal = null,
@TotalPrice		decimal = null,
@Remarks		nvarchar(500) = null,
@IsActive		bit = null,
@IsArchive		bit = null,
@CreatedAt		nvarchar(50) = null,
@CreatedFrom		nvarchar(50) = null,
@CreatedAtBy		nvarchar(50) = null,
@LastUpdateBy		nvarchar(50) = null,
@LastUpdateAt		nvarchar(50) = null,
@LastUpdateFrom		nvarchar(50) = null,

@Msg				nvarchar(MAX)=null OUT ,
@pOptions			int 
)
AS
--Save PurcheaseDetails
if(@pOptions=1)
begin
INSERT INTO PurcheaseDetails
(
PurchaseId,
ProductId,
UnitePrice,
Date,
Quantity,
Discount,
Slup,
TotalPrice,
Remarks,
IsActive,
IsArchive,
CreatedAt,
CreatedFrom,
CreatedAtBy

)
VALUES
(	
@PurchaseId,
@ProductId,
@UnitePrice,
@Date,
@Quantity,
@Discount,
@Slup,
@TotalPrice,
@Remarks,
@IsActive,
@IsArchive,
@CreatedAt,
@CreatedFrom,
@CreatedAtBy

)
IF @@ROWCOUNT = 0
Begin
SET @Msg='Fail~Warning: No rows were Inserted';
End
Else
Begin
SET @Msg='Success~Data Saved Successfully';
End					
end
--End of Save PurcheaseDetails



--Update PurcheaseDetails 
if(@pOptions=2)
begin
UPDATE	PurcheaseDetails 
SET
PurchaseId	=	@PurchaseId ,
ProductId	=	@ProductId ,
UnitePrice	=	@UnitePrice ,
Date	=	@Date ,
Quantity	=	@Quantity ,
Discount	=	@Discount ,
Slup	=	@Slup ,
TotalPrice	=	@TotalPrice ,
Remarks	=	@Remarks ,
IsActive	=	@IsActive ,
IsArchive	=	@IsArchive ,
LastUpdateBy	=	@LastUpdateBy ,
LastUpdateAt	=	@LastUpdateAt ,
LastUpdateFrom	=	@LastUpdateFrom 




WHERE	Id	=	@Id;



IF @@ROWCOUNT = 0
Begin
SET @Msg = 'Fail~Warning: No rows were Updated';
End
Else
Begin
SET @Msg = 'Success~Data Updated Successfully';
End
End
--End of Update PurcheaseDetails 



--IsDelete PurcheaseDetails



if(@pOptions=3)
begin
UPDATE	PurcheaseDetails 
SET
IsArchive	=	@IsArchive ,
LastUpdateBy	=	@LastUpdateBy ,
LastUpdateAt	=	@LastUpdateAt ,
LastUpdateFrom	=	@LastUpdateFrom 
WHERE	Id	=	@Id;
SET @Msg='Success~Data Deleted Successfully';
end



--End of IsDelete PurcheaseDetails 



--IsDelete PurcheaseDetails



if(@pOptions=4)
begin
Delete from PurcheaseDetails Where Id=@Id;
SET @Msg='Success~Data Deleted Successfully';
end



--End of Delete PurcheaseDetails 



--Select All PurcheaseDetails 



if(@pOptions=5)
begin	        
select pd.Id
,pd.PurchaseId,
pd.ProductId,
pd.UnitePrice,
pd.Date,
pd.Quantity,
pd.Discount,
pd.Slup,
pd.TotalPrice,
pd.Remarks,
pd.IsActive,
pd.IsArchive,
pd.CreatedAt,
pd.CreatedFrom,
pd.CreatedAtBy
,p.Code ProductCode
,(p.Code+'~'+p.Name +' '+ ps.Name+' ('+u.Name+')') ProductName
 from PurcheaseDetails	pd
left outer join Products p on p.Id=pd.ProductId
left outer join ProductSize ps on ps.Id=p.ProductSizeId
left outer join ProductTypes pt on pt.Id=p.ProductTypeId
left outer join UOM u on u.Id=p.UOMId
 where pd.IsArchive=0;
if(@@ROWCOUNT=0)
SET @Msg='Fail~Data Not Found';
end



--End of Select All PurcheaseDetails 



--Select PurcheaseDetails By Id 
if(@pOptions=6)
begin
select * from PurcheaseDetails Where Id=@Id and IsArchive=0;



if(@@ROWCOUNT=0)
SET @Msg='Data Not Found';
end
--End of Select PurcheaseDetails By Id 



--Select Id,Name PurcheaseDetails 



if(@pOptions=7)
begin	        
select Id  from PurcheaseDetails Where IsActive=1 and IsArchive=0;;
if(@@ROWCOUNT=0)
SET @Msg='Data Not Found';
end



--End Select Id,Name PurcheaseDetails

--IsDelete PurcheaseDetails



if(@pOptions=8)
begin
Delete from PurcheaseDetails Where Id=@Id;
SET @Msg='Success~Data Deleted Successfully';
end



--End of Delete PurcheaseDetails  
