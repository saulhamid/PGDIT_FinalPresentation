SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE  proc [dbo].[sp_PurcheaseReturns]
(
@Id		int = null,
@SupplierId		int = null,
@EmployeeId		int = null,
@PurchaseId		int = null,
@Discount		decimal = null,
@TotalPaid		decimal = null,
@InvoiceNo		nvarchar(50) = null,
@Date		nvarchar(50) = null,
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
--Save PurcheaseReturns
if(@pOptions=1)
begin
INSERT INTO PurcheaseReturns
(
Id,
SupplierId,
EmployeeId,
PurchaseId,
Discount,
TotalPaid,
InvoiceNo,
Date,
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
@SupplierId,
@EmployeeId,
@PurchaseId,
@Discount,
@TotalPaid,
@InvoiceNo,
@Date,
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
--End of Save PurcheaseReturns



--Update PurcheaseReturns 
if(@pOptions=2)
begin
UPDATE	PurcheaseReturns 
SET
SupplierId	=	@SupplierId ,
EmployeeId	=	@EmployeeId ,
PurchaseId	=	@PurchaseId ,
Discount	=	@Discount ,
TotalPaid	=	@TotalPaid ,
InvoiceNo	=	@InvoiceNo ,
Date	=	@Date ,
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
--End of Update PurcheaseReturns 



--IsDelete PurcheaseReturns



if(@pOptions=3)
begin
UPDATE	PurcheaseReturns 
SET
IsArchive	=	@IsArchive ,
LastUpdateBy	=	@LastUpdateBy ,
LastUpdateAt	=	@LastUpdateAt ,
LastUpdateFrom	=	@LastUpdateFrom 
WHERE	Id	=	@Id;
SET @Msg='Data Deleted Successfully';
end



--End of IsDelete PurcheaseReturns 



--IsDelete PurcheaseReturns



if(@pOptions=4)
begin
Delete from PurcheaseReturns Where Id=@Id;
SET @Msg='Data Deleted Successfully';
end



--End of Delete PurcheaseReturns 



--Select All PurcheaseReturns 



if(@pOptions=5)
begin	        
select * from PurcheaseReturns where IsArchive=0;
if(@@ROWCOUNT=0)
SET @Msg='Data Not Found';
end



--End of Select All PurcheaseReturns 



--Select PurcheaseReturns By Id 
if(@pOptions=6)
begin
select * from PurcheaseReturns Where Id=@Id and IsArchive=0;



if(@@ROWCOUNT=0)
SET @Msg='Data Not Found';
end
--End of Select PurcheaseReturns By Id 



--Select Id,Name PurcheaseReturns 



if(@pOptions=7)
begin	        
select Id,Name  from PurcheaseReturns Where IsActive=1 and IsArchive=0;;
if(@@ROWCOUNT=0)
SET @Msg='Data Not Found';
end



--End Select Id,Name PurcheaseReturns 
