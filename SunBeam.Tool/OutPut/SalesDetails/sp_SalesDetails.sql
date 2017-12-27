SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE  proc [dbo].[sp_SalesDetails]
(
@Id		int = null,
@SalesId		int = null,
@ProductId		int = null,
@ProductName		nvarchar(50) = null,
@ProductCode		nvarchar(50) = null,
@Discount		decimal = null,
@UnitePrice		decimal = null,
@Date		nvarchar(50) = null,
@Slup		decimal = null,
@Bonus		decimal = null,
@AssaignQuantity		decimal = null,
@SalesQuantity		decimal = null,
@Return		decimal = null,
@Replace		decimal = null,
@TotalSlupPrice		decimal = null,
@WithOurDiscountPrice		decimal = null,
@TotalAmount		decimal = null,
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
--Save SalesDetails
if(@pOptions=1)
begin
INSERT INTO SalesDetails
(
Id,
SalesId,
ProductId,
ProductName,
ProductCode,
Discount,
UnitePrice,
Date,
Slup,
Bonus,
AssaignQuantity,
SalesQuantity,
[Return],
Replace,
TotalSlupPrice,
WithOurDiscountPrice,
TotalAmount,
Remarks,
IsActive,
IsArchive,
CreatedBy,
CreatedAt,
CreatedFrom

)
VALUES
(	
@Id,
@SalesId,
@ProductId,
@ProductName,
@ProductCode,
@Discount,
@UnitePrice,
@Date,
@Slup,
@Bonus,
@AssaignQuantity,
@SalesQuantity,
@Return,
@Replace,
@TotalSlupPrice,
@WithOurDiscountPrice,
@TotalAmount,
@Remarks,
@IsActive,
@IsArchive,
@CreatedBy,
@CreatedAt,
@CreatedFrom

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
--End of Save SalesDetails



--Update SalesDetails 
if(@pOptions=2)
begin
UPDATE	SalesDetails 
SET
SalesId	=	@SalesId ,
ProductId	=	@ProductId ,
ProductName	=	@ProductName ,
ProductCode	=	@ProductCode ,
Discount	=	@Discount ,
UnitePrice	=	@UnitePrice ,
Date	=	@Date ,
Slup	=	@Slup ,
Bonus	=	@Bonus ,
AssaignQuantity	=	@AssaignQuantity ,
SalesQuantity	=	@SalesQuantity ,
[Return]	=	@Return ,
Replace	=	@Replace ,
TotalSlupPrice	=	@TotalSlupPrice ,
WithOurDiscountPrice	=	@WithOurDiscountPrice ,
TotalAmount	=	@TotalAmount ,
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
--End of Update SalesDetails 



--IsDelete SalesDetails



if(@pOptions=3)
begin
UPDATE	SalesDetails 
SET
IsArchive	=	@IsArchive ,
LastUpdateBy	=	@LastUpdateBy ,
LastUpdateAt	=	@LastUpdateAt ,
LastUpdateFrom	=	@LastUpdateFrom 
WHERE	Id	=	@Id;
SET @Msg='Data Deleted Successfully';
end



--End of IsDelete SalesDetails 



--IsDelete SalesDetails



if(@pOptions=4)
begin
Delete from SalesDetails Where Id=@Id;
SET @Msg='Data Deleted Successfully';
end



--End of Delete SalesDetails 



--Select All SalesDetails 



if(@pOptions=5)
begin	        
select * from SalesDetails where IsArchive=0;
if(@@ROWCOUNT=0)
SET @Msg='Data Not Found';
end



--End of Select All SalesDetails 



--Select SalesDetails By Id 
if(@pOptions=6)
begin
select * from SalesDetails Where Id=@Id and IsArchive=0;



if(@@ROWCOUNT=0)
SET @Msg='Data Not Found';
end
--End of Select SalesDetails By Id 



--Select Id,Name SalesDetails 



if(@pOptions=7)
begin	        
select Id,Name  from SalesDetails Where IsActive=1 and IsArchive=0;;
if(@@ROWCOUNT=0)
SET @Msg='Data Not Found';
end



--End Select Id,Name SalesDetails 
