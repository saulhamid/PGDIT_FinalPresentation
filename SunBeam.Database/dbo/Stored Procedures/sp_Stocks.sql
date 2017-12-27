
CREATE  proc [dbo].[sp_Stocks]
(
@Id		int = null,
@ProductId		int = null,
@TotalPaid		decimal = null,
@TotalPrice		decimal = null,
@Quantity		decimal = null,
@GrandTotal		decimal = null,
@Date		nvarchar(50) = null,
@FinalUnitPrice		decimal = null,
@OpeningQuantity		decimal = null,
@Remarks		nvarchar(500) = null,
@StockStutes		bit = null,
@IsActive		bit = null,
@IsArchive		bit = null,
@CreatedBy		nvarchar(50) = null,
@CreatedAt		nvarchar(50) = null,
@CreatedFrom		nvarchar(50) = null,

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
TotalPaid,
TotalPrice,
Quantity,
GrandTotal,
Date,
FinalUnitPrice,
OpeningQuantity,
Remarks,
StockStutes,
IsActive,
IsArchive,
CreatedBy,
CreatedAt,
CreatedFrom

)
VALUES
(	
@ProductId,
@TotalPaid,
@TotalPrice,
@Quantity,
@GrandTotal,
@Date,
@FinalUnitPrice,
@OpeningQuantity,
@Remarks,
@StockStutes,
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
--End of Save Stocks



--Update Stocks 
if(@pOptions=2)
begin
UPDATE	Stocks 
SET
ProductId	=	@ProductId ,
TotalPaid	=	@TotalPaid ,
TotalPrice	=	@TotalPrice ,
Quantity	=	@Quantity ,
GrandTotal	=	@GrandTotal ,
Date	=	@Date ,
FinalUnitPrice	=	@FinalUnitPrice ,
OpeningQuantity	=	@OpeningQuantity ,
Remarks	=	@Remarks ,
StockStutes	=	@StockStutes ,
IsActive	=	@IsActive ,
IsArchive	=	@IsArchive ,
CreatedBy	=	@CreatedBy ,
CreatedAt	=	@CreatedAt ,
CreatedFrom	=	@CreatedFrom 




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
IsArchive	=	@IsArchive 

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
select
sk.Id ,
sk.ProductId,
sk.TotalPaid,
sk.TotalPrice,
sk.Quantity,
sk.GrandTotal,
sk.Date,
sk.FinalUnitPrice,
sk.OpeningQuantity,
sk.Remarks,
sk.StockStutes,
sk.IsActive,
sk.IsArchive,
sk.CreatedBy,
sk.CreatedAt,
sk.CreatedFrom 
,( p.Code+'~'+p.Name +' '+ ps.Name+' ('+u.Name+')') ProductName
from Stocks sk 
left outer join Products p on p.Id=sk.ProductId
left outer join ProductSize ps on ps.Id=p.ProductSizeId
left outer join ProductTypes pt on pt.Id=p.ProductTypeId
left outer join UOM u on u.Id=p.UOMId
where sk.IsArchive=0;
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
select Id  from Stocks Where IsActive=1 and IsArchive=0;;
if(@@ROWCOUNT=0)
SET @Msg='Data Not Found';
end



--End Select Id,Name Stocks 
