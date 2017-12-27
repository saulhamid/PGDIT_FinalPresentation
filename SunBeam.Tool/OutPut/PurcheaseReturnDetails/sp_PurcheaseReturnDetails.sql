SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE  proc [dbo].[sp_PurcheaseReturnDetails]
(
@Id		int = null,
@PurchaseReturnId		int = null,
@ProductId		int = null,
@ProductName		nvarchar(50) = null,
@ProductCode		nvarchar(50) = null,
@UnitePrice		decimal = null,
@Data		nvarchar(50) = null,
@Quantity		decimal = null,
@Discount		decimal = null,
@TotalPrice		decimal = null,
@Remarks		nvarchar(500) = null,
@IsActive		bit = null,
@IsArchive		bit = null,
@CreatedBy		nvarchar(50) = null,
@CreatedAt		nvarchar(50) = null,
@CreatedFrom		nvarchar(50) = null,
@LastUpdateBy		nvarchar(50) = null,
@LastUpdateAt		nvarchar(50) = null,
@LastUpdateFrom		nvarchar(50) = null,

@Msg				nvarchar(MAX)=null OUT ,
@pOptions			int 
)
AS
--Save PurcheaseReturnDetails
if(@pOptions=1)
begin
INSERT INTO PurcheaseReturnDetails
(
Id,
PurchaseReturnId,
ProductId,
ProductName,
ProductCode,
UnitePrice,
Data,
Quantity,
Discount,
TotalPrice,
Remarks,
IsActive,
IsArchive,
CreatedBy,
CreatedAt,
CreatedFrom,
LastUpdateBy,
LastUpdateAt,
LastUpdateFrom

)
VALUES
(	
@Id,
@PurchaseReturnId,
@ProductId,
@ProductName,
@ProductCode,
@UnitePrice,
@Data,
@Quantity,
@Discount,
@TotalPrice,
@Remarks,
@IsActive,
@IsArchive,
@CreatedBy,
@CreatedAt,
@CreatedFrom,
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
--End of Save PurcheaseReturnDetails



--Update PurcheaseReturnDetails 
if(@pOptions=2)
begin
UPDATE	PurcheaseReturnDetails 
SET
PurchaseReturnId	=	@PurchaseReturnId ,
ProductId	=	@ProductId ,
ProductName	=	@ProductName ,
ProductCode	=	@ProductCode ,
UnitePrice	=	@UnitePrice ,
Data	=	@Data ,
Quantity	=	@Quantity ,
Discount	=	@Discount ,
TotalPrice	=	@TotalPrice ,
Remarks	=	@Remarks ,
IsActive	=	@IsActive ,
IsArchive	=	@IsArchive ,
CreatedBy	=	@CreatedBy ,
CreatedAt	=	@CreatedAt ,
CreatedFrom	=	@CreatedFrom ,
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
--End of Update PurcheaseReturnDetails 



--IsDelete PurcheaseReturnDetails



if(@pOptions=3)
begin
UPDATE	PurcheaseReturnDetails 
SET
IsArchive	=	@IsArchive ,
LastUpdateBy	=	@LastUpdateBy ,
LastUpdateAt	=	@LastUpdateAt ,
LastUpdateFrom	=	@LastUpdateFrom 
WHERE	Id	=	@Id;
SET @Msg='Data Deleted Successfully';
end



--End of IsDelete PurcheaseReturnDetails 



--IsDelete PurcheaseReturnDetails



if(@pOptions=4)
begin
Delete from PurcheaseReturnDetails Where Id=@Id;
SET @Msg='Data Deleted Successfully';
end



--End of Delete PurcheaseReturnDetails 



--Select All PurcheaseReturnDetails 



if(@pOptions=5)
begin	        
select * from PurcheaseReturnDetails where IsArchive=0;
if(@@ROWCOUNT=0)
SET @Msg='Data Not Found';
end



--End of Select All PurcheaseReturnDetails 



--Select PurcheaseReturnDetails By Id 
if(@pOptions=6)
begin
select * from PurcheaseReturnDetails Where Id=@Id and IsArchive=0;



if(@@ROWCOUNT=0)
SET @Msg='Data Not Found';
end
--End of Select PurcheaseReturnDetails By Id 



--Select Id,Name PurcheaseReturnDetails 



if(@pOptions=7)
begin	        
select Id,Name  from PurcheaseReturnDetails Where IsActive=1 and IsArchive=0;;
if(@@ROWCOUNT=0)
SET @Msg='Data Not Found';
end



--End Select Id,Name PurcheaseReturnDetails 
