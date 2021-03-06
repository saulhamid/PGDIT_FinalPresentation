SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE  proc [dbo].[sp_Stocks]
(
@Id		int = null,
@ProductId		int = null,
@Replace		decimal = null,
@Return		decimal = null,
@Discount		decimal = null,
@Slup		decimal = null,
@Quantity		decimal = null,
@TotalPaid		decimal = null,
@TotalPrice		decimal = null,
@GrandTotal		decimal = null,
@Date		nvarchar(50) = null,
@UnitPrice		decimal = null,
@OpeningQuantity		decimal = null,
@Remarks		nvarchar(500) = null,
@StockStutes		bit = null,
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
--Save Stocks
if(@pOptions=1)
begin
INSERT INTO Stocks
(
ProductId,
[Replace],
[Return],
Discount,
Slup,
Quantity,
TotalPaid,
TotalPrice,
GrandTotal,
Date,
UnitPrice,
OpeningQuantity,
Remarks,
StockStutes,
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
@ProductId,
@Replace,
@Return,
@Discount,
@Slup,
@Quantity,
@TotalPaid,
@TotalPrice,
@GrandTotal,
@Date,
@UnitPrice,
@OpeningQuantity,
@Remarks,
@StockStutes,
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
--End of Save Stocks



--Update Stocks 
if(@pOptions=2)
begin
UPDATE	Stocks 
SET
Id	=	@Id ,
ProductId	=	@ProductId ,
Replace	=	@Replace ,
Return	=	@Return ,
Discount	=	@Discount ,
Slup	=	@Slup ,
Quantity	=	@Quantity ,
TotalPaid	=	@TotalPaid ,
TotalPrice	=	@TotalPrice ,
GrandTotal	=	@GrandTotal ,
Date	=	@Date ,
UnitPrice	=	@UnitPrice ,
OpeningQuantity	=	@OpeningQuantity ,
Remarks	=	@Remarks ,
StockStutes	=	@StockStutes ,
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
--End of Update Stocks 



--IsDelete Stocks



if(@pOptions=3)
begin
UPDATE	Stocks 
SET
IsArchive	=	@IsArchive ,
LastUpdateBy	=	@LastUpdateBy ,
LastUpdateAt	=	@LastUpdateAt ,
LastUpdateFrom	=	@LastUpdateFrom 
WHERE	Id	=	@Id;
SET @Msg='Data Deleted Successfully';
end



--End of IsDelete Stocks 



--IsDelete Stocks



if(@pOptions=4)
begin
Delete from Stocks Where Id=@Id;
SET @Msg='Data Deleted Successfully';
end



--End of Delete Stocks 



--Select All Stocks 



if(@pOptions=5)
begin	        
select * from Stocks where IsArchive=0;
if(@@ROWCOUNT=0)
SET @Msg='Data Not Found';
end



--End of Select All Stocks 



--Select Stocks By Id 
if(@pOptions=6)
begin
select * from Stocks Where Id=@Id and IsArchive=0;



if(@@ROWCOUNT=0)
SET @Msg='Data Not Found';
end
--End of Select Stocks By Id 



--Select Id,Name Stocks 



if(@pOptions=7)
begin	        
select Id,Name  from Stocks Where IsActive=1 and IsArchive=0;;
if(@@ROWCOUNT=0)
SET @Msg='Data Not Found';
end



--End Select Id,Name Stocks 
