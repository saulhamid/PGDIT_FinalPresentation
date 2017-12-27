SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE  proc [dbo].[sp_Products]
(
@Id		int = null,
@Code		nvarchar(20) = null,
@Name		nvarchar(50) = null,
@UOMId		int = null,
@ProductBrandId		int = null,
@ProductCatagoriesId		int = null,
@ProductColorId		int = null,
@ProductSizeId		int = null,
@ProductTypeId		int = null,
@SupplierName		nvarchar(100) = null,
@SupplierId		int = null,
@MinimumStock		int = null,
@OtherCost		decimal = null,
@Discount		decimal = null,
@UnitePrice		decimal = null,
@Quantity		decimal = null,
@OpeningQuantity		decimal = null,
@Remarks		nvarchar(500) = null,
@IsActive		bit = null,
@IsArchive		bit = null,
@CreatedBy		nvarchar(20) = null,
@CreatedAt		nvarchar(14) = null,
@CreatedFrom		nvarchar(50) = null,
@LastUpdateBy		nvarchar(20) = null,
@LastUpdateAt		nvarchar(14) = null,
@LastUpdateFrom		nvarchar(50) = null,

@Msg				nvarchar(MAX)=null OUT ,
@pOptions			int 
)
AS
--Save Products
if(@pOptions=1)
begin
INSERT INTO Products
(
Id,
Code,
Name,
UOMId,
ProductBrandId,
ProductCatagoriesId,
ProductColorId,
ProductSizeId,
ProductTypeId,
SupplierName,
SupplierId,
MinimumStock,
OtherCost,
Discount,
UnitePrice,
Quantity,
OpeningQuantity,
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
@Code,
@Name,
@UOMId,
@ProductBrandId,
@ProductCatagoriesId,
@ProductColorId,
@ProductSizeId,
@ProductTypeId,
@SupplierName,
@SupplierId,
@MinimumStock,
@OtherCost,
@Discount,
@UnitePrice,
@Quantity,
@OpeningQuantity,
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
--End of Save Products



--Update Products 
if(@pOptions=2)
begin
UPDATE	Products 
SET
Code	=	@Code ,
Name	=	@Name ,
UOMId	=	@UOMId ,
ProductBrandId	=	@ProductBrandId ,
ProductCatagoriesId	=	@ProductCatagoriesId ,
ProductColorId	=	@ProductColorId ,
ProductSizeId	=	@ProductSizeId ,
ProductTypeId	=	@ProductTypeId ,
SupplierName	=	@SupplierName ,
SupplierId	=	@SupplierId ,
MinimumStock	=	@MinimumStock ,
OtherCost	=	@OtherCost ,
Discount	=	@Discount ,
UnitePrice	=	@UnitePrice ,
Quantity	=	@Quantity ,
OpeningQuantity	=	@OpeningQuantity ,
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
--End of Update Products 



--IsDelete Products



if(@pOptions=3)
begin
UPDATE	Products 
SET
IsArchive	=	@IsArchive ,
LastUpdateBy	=	@LastUpdateBy ,
LastUpdateAt	=	@LastUpdateAt ,
LastUpdateFrom	=	@LastUpdateFrom 
WHERE	Id	=	@Id;
SET @Msg='Data Deleted Successfully';
end



--End of IsDelete Products 



--IsDelete Products



if(@pOptions=4)
begin
Delete from Products Where Id=@Id;
SET @Msg='Data Deleted Successfully';
end



--End of Delete Products 



--Select All Products 



if(@pOptions=5)
begin	        
select * from Products where IsArchive=0;
if(@@ROWCOUNT=0)
SET @Msg='Data Not Found';
end



--End of Select All Products 



--Select Products By Id 
if(@pOptions=6)
begin
select * from Products Where Id=@Id and IsArchive=0;



if(@@ROWCOUNT=0)
SET @Msg='Data Not Found';
end
--End of Select Products By Id 



--Select Id,Name Products 



if(@pOptions=7)
begin	        
select Id,Name  from Products Where IsActive=1 and IsArchive=0;;
if(@@ROWCOUNT=0)
SET @Msg='Data Not Found';
end



--End Select Id,Name Products 
