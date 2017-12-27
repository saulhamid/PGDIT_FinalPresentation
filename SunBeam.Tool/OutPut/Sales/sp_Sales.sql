SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE  proc [dbo].[sp_Sales]
(
@Id		int = null,
@InvoiecNo		nvarchar(200) = null,
@ProductId		int = null,
@CustomerId		int = null,
@ZoneOrAreaId		int = null,
@EmployeeId		int = null,
@DiscountRemarks		nvarchar(200) = null,
@Discount		decimal = null,
@TotalDiscount		decimal = null,
@TotalPaid		decimal = null,
@GrandTotal		decimal = null,
@Date		nvarchar(50) = null,
@PackUnitPrice		decimal = null,
@PackQuantity		decimal = null,
@EventName		nvarchar(500) = null,
@EventAamount		decimal = null,
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
--Save Sales
if(@pOptions=1)
begin
INSERT INTO Sales
(
Id,
InvoiecNo,
ProductId,
CustomerId,
ZoneOrAreaId,
EmployeeId,
DiscountRemarks,
Discount,
TotalDiscount,
TotalPaid,
GrandTotal,
Date,
PackUnitPrice,
PackQuantity,
EventName,
EventAamount,
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
@InvoiecNo,
@ProductId,
@CustomerId,
@ZoneOrAreaId,
@EmployeeId,
@DiscountRemarks,
@Discount,
@TotalDiscount,
@TotalPaid,
@GrandTotal,
@Date,
@PackUnitPrice,
@PackQuantity,
@EventName,
@EventAamount,
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
--End of Save Sales



--Update Sales 
if(@pOptions=2)
begin
UPDATE	Sales 
SET
Id	=	@Id ,
InvoiecNo	=	@InvoiecNo ,
ProductId	=	@ProductId ,
CustomerId	=	@CustomerId ,
ZoneOrAreaId	=	@ZoneOrAreaId ,
EmployeeId	=	@EmployeeId ,
DiscountRemarks	=	@DiscountRemarks ,
Discount	=	@Discount ,
TotalDiscount	=	@TotalDiscount ,
TotalPaid	=	@TotalPaid ,
GrandTotal	=	@GrandTotal ,
Date	=	@Date ,
PackUnitPrice	=	@PackUnitPrice ,
PackQuantity	=	@PackQuantity ,
EventName	=	@EventName ,
EventAamount	=	@EventAamount ,
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
--End of Update Sales 



--IsDelete Sales



if(@pOptions=3)
begin
UPDATE	Sales 
SET
IsArchive	=	@IsArchive ,
LastUpdateBy	=	@LastUpdateBy ,
LastUpdateAt	=	@LastUpdateAt ,
LastUpdateFrom	=	@LastUpdateFrom 
WHERE	Id	=	@Id;
SET @Msg='Data Deleted Successfully';
end



--End of IsDelete Sales 



--IsDelete Sales



if(@pOptions=4)
begin
Delete from Sales Where Id=@Id;
SET @Msg='Data Deleted Successfully';
end



--End of Delete Sales 



--Select All Sales 



if(@pOptions=5)
begin	        
select * from Sales where IsArchive=0;
if(@@ROWCOUNT=0)
SET @Msg='Data Not Found';
end



--End of Select All Sales 



--Select Sales By Id 
if(@pOptions=6)
begin
select * from Sales Where Id=@Id and IsArchive=0;



if(@@ROWCOUNT=0)
SET @Msg='Data Not Found';
end
--End of Select Sales By Id 



--Select Id,Name Sales 



if(@pOptions=7)
begin	        
select Id,Name  from Sales Where IsActive=1 and IsArchive=0;;
if(@@ROWCOUNT=0)
SET @Msg='Data Not Found';
end



--End Select Id,Name Sales 
