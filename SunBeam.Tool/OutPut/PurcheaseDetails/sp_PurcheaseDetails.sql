SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE  proc [dbo].[sp_PurcheaseDetails]
(
@Id		int = null,
@PurchaseId		int = null,
@ProductId		int = null,
@ProductName		nvarchar(50) = null,
@ProductCode		nvarchar(50) = null,
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
Id,
PurchaseId,
ProductId,
ProductName,
ProductCode,
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
CreatedAtBy,
LastUpdateBy,
LastUpdateAt,
LastUpdateFrom

)
VALUES
(	
@Id,
@PurchaseId,
@ProductId,
@ProductName,
@ProductCode,
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
@CreatedAtBy,
@LastUpdateBy,
@LastUpdateAt,
@LastUpdateFrom

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
ProductName	=	@ProductName ,
ProductCode	=	@ProductCode ,
UnitePrice	=	@UnitePrice ,
Date	=	@Date ,
Quantity	=	@Quantity ,
Discount	=	@Discount ,
Slup	=	@Slup ,
TotalPrice	=	@TotalPrice ,
Remarks	=	@Remarks ,
IsActive	=	@IsActive ,
IsArchive	=	@IsArchive ,
CreatedAt	=	@CreatedAt ,
CreatedFrom	=	@CreatedFrom ,
CreatedAtBy	=	@CreatedAtBy ,
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
SET @Msg='Data Deleted Successfully';
end



--End of IsDelete PurcheaseDetails 



--IsDelete PurcheaseDetails



if(@pOptions=4)
begin
Delete from PurcheaseDetails Where Id=@Id;
SET @Msg='Data Deleted Successfully';
end



--End of Delete PurcheaseDetails 



--Select All PurcheaseDetails 



if(@pOptions=5)
begin	        
select * from PurcheaseDetails where IsArchive=0;
if(@@ROWCOUNT=0)
SET @Msg='Data Not Found';
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
select Id,Name  from PurcheaseDetails Where IsActive=1 and IsArchive=0;;
if(@@ROWCOUNT=0)
SET @Msg='Data Not Found';
end



--End Select Id,Name PurcheaseDetails 
