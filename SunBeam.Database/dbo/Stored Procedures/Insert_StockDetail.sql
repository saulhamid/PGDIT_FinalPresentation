
create proc Insert_StockDetail
 @StockIdint int
,@StockReplace	decimal
,@TransReplace	decimal
,@TotalReplace	decimal(18,2)
,@StockReturn		decimal(18,2)
,@TransReturn		decimal(18,2)
,@TotalReturn		decimal(18,2)
,@StockDiscount	decimal(18,2)
,@TransDiscount	decimal(18,2)
,@TotalDiscount	decimal(18,2)
,@TransSlup		decimal(18,2)
,@StockSlup		decimal(18,2)
,@TotalSlup		decimal(18,2)
,@StockQuantity	decimal(18,2)
,@TransQuantity	decimal(18,2)
,@TotalQuantity	decimal(18,2)
,@TotalPaid		decimal(18,2)
,@StockPrice		decimal(18,2)
,@TransPrice		decimal(18,2)
,@TotalPrice		decimal(18,2)
,@Remarks			nvarchar(500)
,@StockStutes		bit
,@Date			nvarchar(50)
as
begin
INSERT INTO  dbo . StockDetails 
           ( StockId 
           , StockReplace 
           , TransReplace 
           , TotalReplace 
           , StockReturn 
           , TransReturn 
           , TotalReturn 
           , StockDiscount 
           , TransDiscount 
           , TotalDiscount 
           , TransSlup 
           , StockSlup 
           , TotalSlup 
           , StockQuantity 
           , TransQuantity 
           , TotalQuantity 
           , TotalPaid 
           , StockPrice 
           , TransPrice 
           , TotalPrice 
           , Remarks 
           , StockStutes 
           , Date )
     VALUES
           ( 
          @StockIdint 
		 ,@StockReplace	
		 ,@TransReplace	
		 ,@TotalReplace	
		 ,@StockReturn	
		 ,@TransReturn	
		 ,@TotalReturn	
		 ,@StockDiscount
		 ,@TransDiscount
		 ,@TotalDiscount
		 ,@TransSlup		
		 ,@StockSlup		
		 ,@TotalSlup		
		 ,@StockQuantity
		 ,@TransQuantity
		, @TotalQuantity	
		 ,@TotalPaid		
		, @StockPrice	
		, @TransPrice	
		, @TotalPrice	
		, @Remarks		
		, @StockStutes	
		, @Date		
		)	
		   end
