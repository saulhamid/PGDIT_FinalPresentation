CREATE proc [dbo].[SP_Stock](
@id int
,@ProductId  int  
,@TotalReplace  decimal(18, 2) =null 
,@TotalReturn  decimal(18, 2)  =null 
,@TotalDiscount  decimal(18, 2) =null  
,@TotalSlup  decimal(18, 2)    =null 
,@StockQuantity  decimal(18, 2) =null  
,@Quantity  decimal(18, 2)   =null 
,@TotalPaid  decimal(18, 2)  =null 
,@TotalPrice  decimal(18, 2)  =null 
,@GrandTotal  decimal(18, 2)  =null 
,@Date  nvarchar(50)  	 =null 
,@FinalUnitPrice  decimal(18, 2) =null 
,@OpeningQuantity  decimal(18, 2) =null 
,@Remarks  nvarchar(500)  		  =null 
,@StockStutes  bit  			  =null 
,@IsActive  bit  				=0
,@IsArchive  bit  				 =1 
,@CreatedBy  nvarchar(50)  	=null 
,@CreatedAt  nvarchar(50)  	  =null 
,@CreatedFrom  nvarchar(50)    =null 
,@LastUpdateBy  nvarchar(50)  	=null 
,@LastUpdateAt  nvarchar(50)  	=null 
,@LastUpdateFrom  nvarchar(50)	=null 
,@Option int=null
)
as
begin
declare @QuantityTemp decimal
if(@Option = 1)
begin
DECLARE @rowcount int
select @rowcount=COUNT(*) from dbo.Stocks
INSERT INTO  dbo . Stocks 
           ( Id ,ProductId  ,Quantity ,TotalPaid ,TotalPrice ,Date ,FinalUnitPrice ,OpeningQuantity ,Remarks ,StockStutes ,IsActive ,IsArchive 
,CreatedBy ,CreatedAt ,CreatedFrom )
VALUES( @rowcount+1,@ProductId ,@Quantity ,@TotalPaid ,@Quantity*@FinalUnitPrice ,@Date ,@FinalUnitPrice ,@OpeningQuantity ,@Remarks   ,@StockStutes 
,1,0 ,@CreatedBy ,@CreatedAt ,@CreatedFrom  )
end
if(@Option = 2)
begin
update Stocks set
ProductId=@ProductId 
,Quantity=@Quantity 
,TotalPaid=@TotalPaid 
,TotalPrice=@Quantity*@FinalUnitPrice
,GrandTotal=@GrandTotal 
,Date=@Date 
,FinalUnitPrice=@FinalUnitPrice 
,OpeningQuantity=@OpeningQuantity
,Remarks=@Remarks 
,StockStutes=@StockStutes  
   where id=@id
end
if(@Option = 3)
begin

select @QuantityTemp= Quantity from Stocks where ProductId=@ProductId
update Stocks set
Quantity=@QuantityTemp-@Quantity 
,TotalPaid=@TotalPaid 
,TotalPrice=@Quantity*@FinalUnitPrice
,GrandTotal=@GrandTotal 
,Date=@Date 
,FinalUnitPrice=@FinalUnitPrice 
,OpeningQuantity=@OpeningQuantity
,Remarks=@Remarks  
   where ProductId=@ProductId
end
if(@Option = 4)
begin

select @QuantityTemp= Quantity from Stocks where ProductId=@ProductId
update Stocks set
Quantity=@QuantityTemp+@Quantity 
,TotalPaid=@TotalPaid 
,TotalPrice=@Quantity*@FinalUnitPrice
,GrandTotal=@GrandTotal 
,Date=@Date 
,FinalUnitPrice=@FinalUnitPrice 
,OpeningQuantity=@OpeningQuantity
,Remarks=@Remarks 
,StockStutes=@StockStutes   
   where ProductId=@ProductId
end
if(@Option = 5)
begin
select *from Stocks
end
if(@Option = 6)
begin
select *from Stocks	 where id=@id
end
if(@Option = 7)
begin
select *from Stocks	 where ProductId=@ProductId
end
end
