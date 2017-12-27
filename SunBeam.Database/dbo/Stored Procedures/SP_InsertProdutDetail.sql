CREATE proc  [dbo].[SP_InsertProdutDetail]
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
,@Remarks  nvarchar(50) = null
,@StockStutes bit = null
,@LastUpdateBy nvarchar(50) = null
,@LastUpdateAt nvarchar(50) = null
,@LastUpdateFrom nvarchar(50) = null
)
as
begin
DECLARE @TotalQuantity1 decimal
DECLARE @TotalQuantityproduct decimal
DECLARE @Date1 nvarchar(50)
DECLARE @TotalReplace1 decimal
DECLARE @TotalReturn1 decimal
DECLARE @TotalSlup1 decimal
DECLARE @TotalDiscount1 decimal
DECLARE @FinalUnitPrice1 decimal
DECLARE @TotalPaid1 decimal
DECLARE @StockId int
DECLARE @Remarks1  nvarchar(50)
--get productdetail stock by product id
 
--get product detail by productid
select @TotalQuantityproduct=Quantity from PurcheaseDetails where ProductId=@ProductId
--check exit in product detail
if (@@ROWCOUNT > 0)
--if yes

delete PurcheaseDetails where PurchaseId=@PurcheaseId
	--delete by productid
	else
	--if no
	--insert product detail
	INSERT INTO dbo.PurcheaseDetails
           (PurchaseId
           ,ProductId
           ,UnitePrice
           ,Date
           ,Quantity
           ,Discount
           ,Slup
           ,Remarks
           ,IsActive
           ,IsArchive
           ,CreatedAt
           ,CreatedFrom
           ,CreatedAtBy
           )
     VALUES
           (@PurcheaseId,@ProductId,@FinalUnitPrice,@Date,@TotalQuantity,
		   @TotalDiscount,@TotalSlup,@Remarks,1,0,@LastUpdateAt,@LastUpdateFrom,@LastUpdateBy)
--check row count
	-- get stock quantity by productid
	--update stock (remove exit productdetail quantity) 
	
	--update Stocks  set TotalQuantity= case when @TotalQuantity1 is null then @TotalQuantity else
	--@TotalQuantity1-@TotalQuantityproduct end  where ProductId=@ProductId
	----update stock (add new productdetail quantity)
	--update Stocks  set TotalQuantity= case when @TotalQuantity1 is null then @TotalQuantity else
	--@TotalQuantity1+@TotalQuantity end  where ProductId=@ProductId
	if (@@ROWCOUNT > 0)
	INSERT INTO  dbo . StockDetails 
           (  SalesId , SalesReturnId , PurcheaseId , PurcheaseReturnId   , StockId , StockReplace , TransReplace 
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
     VALUES(
             @SalesId
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
           , case when @TotalQuantity > @TotalQuantityproduct then  1 else 0 end
           , @Date
           , 1
           , 0
           , @LastUpdateBy
           , @LastUpdateAt
           , @LastUpdateFrom )
	--insert in stockdetail
	return @TotalQuantityproduct
end