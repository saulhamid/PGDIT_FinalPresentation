SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE  proc [dbo].[sp_StockDetails]
(
@Id		int = null,
@SalesId		int = null,
@SalesReturnId		int = null,
@PurcheaseId		int = null,
@PurcheaseReturnId		int = null,
@StockId		int = null,
@StockReplace		decimal = null,
@TransReplace		decimal = null,
@TotalReplace		decimal = null,
@StockReturn		decimal = null,
@TransReturn		decimal = null,
@TotalReturn		decimal = null,
@StockDiscount		decimal = null,
@TransDiscount		decimal = null,
@TotalDiscount		decimal = null,
@TransSlup		decimal = null,
@StockSlup		decimal = null,
@TotalSlup		decimal = null,
@StockQuantity		decimal = null,
@TransQuantity		decimal = null,
@TotalQuantity		decimal = null,
@TotalPaid		decimal = null,
@StockPrice		decimal = null,
@TransPrice		decimal = null,
@TotalPrice		decimal = null,
@Remarks		nvarchar(500) = null,
@StockStutes		bit = null,
@Date		nvarchar(50) = null,
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
--Save StockDetails
if(@pOptions=1)
begin
INSERT INTO StockDetails
(
Id,
SalesId,
SalesReturnId,
PurcheaseId,
PurcheaseReturnId,
StockId,
StockReplace,
TransReplace,
TotalReplace,
StockReturn,
TransReturn,
TotalReturn,
StockDiscount,
TransDiscount,
TotalDiscount,
TransSlup,
StockSlup,
TotalSlup,
StockQuantity,
TransQuantity,
TotalQuantity,
TotalPaid,
StockPrice,
TransPrice,
TotalPrice,
Remarks,
StockStutes,
Date,
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
@SalesId,
@SalesReturnId,
@PurcheaseId,
@PurcheaseReturnId,
@StockId,
@StockReplace,
@TransReplace,
@TotalReplace,
@StockReturn,
@TransReturn,
@TotalReturn,
@StockDiscount,
@TransDiscount,
@TotalDiscount,
@TransSlup,
@StockSlup,
@TotalSlup,
@StockQuantity,
@TransQuantity,
@TotalQuantity,
@TotalPaid,
@StockPrice,
@TransPrice,
@TotalPrice,
@Remarks,
@StockStutes,
@Date,
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
--End of Save StockDetails



--Update StockDetails 
if(@pOptions=2)
begin
UPDATE	StockDetails 
SET
SalesId	=	@SalesId ,
SalesReturnId	=	@SalesReturnId ,
PurcheaseId	=	@PurcheaseId ,
PurcheaseReturnId	=	@PurcheaseReturnId ,
StockId	=	@StockId ,
StockReplace	=	@StockReplace ,
TransReplace	=	@TransReplace ,
TotalReplace	=	@TotalReplace ,
StockReturn	=	@StockReturn ,
TransReturn	=	@TransReturn ,
TotalReturn	=	@TotalReturn ,
StockDiscount	=	@StockDiscount ,
TransDiscount	=	@TransDiscount ,
TotalDiscount	=	@TotalDiscount ,
TransSlup	=	@TransSlup ,
StockSlup	=	@StockSlup ,
TotalSlup	=	@TotalSlup ,
StockQuantity	=	@StockQuantity ,
TransQuantity	=	@TransQuantity ,
TotalQuantity	=	@TotalQuantity ,
TotalPaid	=	@TotalPaid ,
StockPrice	=	@StockPrice ,
TransPrice	=	@TransPrice ,
TotalPrice	=	@TotalPrice ,
Remarks	=	@Remarks ,
StockStutes	=	@StockStutes ,
Date	=	@Date ,
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
--End of Update StockDetails 



--IsDelete StockDetails



if(@pOptions=3)
begin
UPDATE	StockDetails 
SET
IsArchive	=	@IsArchive ,
LastUpdateBy	=	@LastUpdateBy ,
LastUpdateAt	=	@LastUpdateAt ,
LastUpdateFrom	=	@LastUpdateFrom 
WHERE	Id	=	@Id;
SET @Msg='Data Deleted Successfully';
end



--End of IsDelete StockDetails 



--IsDelete StockDetails



if(@pOptions=4)
begin
Delete from StockDetails Where Id=@Id;
SET @Msg='Data Deleted Successfully';
end



--End of Delete StockDetails 



--Select All StockDetails 



if(@pOptions=5)
begin	        
select * from StockDetails where IsArchive=0;
if(@@ROWCOUNT=0)
SET @Msg='Data Not Found';
end



--End of Select All StockDetails 



--Select StockDetails By Id 
if(@pOptions=6)
begin
select * from StockDetails Where Id=@Id and IsArchive=0;



if(@@ROWCOUNT=0)
SET @Msg='Data Not Found';
end
--End of Select StockDetails By Id 



--Select Id,Name StockDetails 



if(@pOptions=7)
begin	        
select Id  from StockDetails Where IsActive=1 and IsArchive=0;;
if(@@ROWCOUNT=0)
SET @Msg='Data Not Found';
end



--End Select Id,Name StockDetails 
