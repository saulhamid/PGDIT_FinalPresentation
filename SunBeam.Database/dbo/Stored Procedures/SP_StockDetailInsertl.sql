

CREATE proc  [dbo].[SP_StockDetailInsertl]
(
@ProductId int = null
,@PurcheaseId int = null
,@SalesId  int = null
,@SalesReturnId  int = null
,@PurcheaseReturnId int = null
,@Date nvarchar(50) = null
,@TotalQuantity decimal = null
,@TotalReplace decimal = null
,@TotalReturn decimal = null
,@TotalDiscount decimal = null
,@TotalSlup decimal = null
,@FinalUnitPrice decimal = null
,@TotalPaid decimal = null
,@Remarks decimal = null
,@StockStutes bit = null
,@LastUpdateBy nvarchar(50) = null
,@LastUpdateAt nvarchar(50) = null
,@LastUpdateFrom nvarchar(50) = null
,@Option int =null
)
as
begin
DECLARE @TotalQuantity1 decimal
DECLARE @Date1 nvarchar(50)
DECLARE @TotalReplace1 decimal
DECLARE @TotalReturn1 decimal
DECLARE @TotalSlup1 decimal
DECLARE @TotalDiscount1 decimal
DECLARE @FinalUnitPrice1 decimal
DECLARE @TotalPaid1 decimal
DECLARE @StockId int
DECLARE @Remarks1 decimal
if(@Option =1)
begin
select @StockId=Id, @TotalQuantity1=Quantity,@Date1=Date,@FinalUnitPrice1=FinalUnitPrice,@TotalPaid1=TotalPaid from dbo . Stocks  where ProductId=@ProductId
INSERT INTO  dbo . StockDetails 
           ( SalesId , SalesReturnId , PurcheaseId , PurcheaseReturnId , StockId , StockReplace , TransReplace 
, TotalReplace , StockReturn , TransReturn , TotalReturn , StockDiscount , TransDiscount , TotalDiscount 
, TransSlup , StockSlup , TotalSlup 
, StockQuantity , TransQuantity , TotalQuantity 
, TotalPaid 
, Remarks 
, StockStutes 
, Date 
, IsActive 
, IsArchive 
, CreatedBy 
, CreatedAt 
, CreatedFrom  )
     VALUES
           ( @SalesId
           , @SalesReturnId
           , @PurcheaseId
           , @PurcheaseReturnId
           , @StockId
           , @TotalReplace1
           , @TotalReplace-@TotalReplace1
           , @TotalReplace
           , @TotalReturn1
           , @TotalReturn-@TotalReturn1
           , @TotalReturn
		   ,@TotalDiscount1
		   ,@TotalDiscount-@TotalDiscount1
		   ,@TotalDiscount
           , @TotalSlup1
           , @TotalSlup-@TotalSlup1
           , @TotalSlup
           , @TotalQuantity1
           , @TotalQuantity+@TotalQuantity1
           , @TotalQuantity
           , @TotalPaid
           , @Remarks
           , 1
           , @Date
           , 1
           , 0
           , @LastUpdateBy
           , @LastUpdateAt
           , @LastUpdateFrom )
		   end
		   end





