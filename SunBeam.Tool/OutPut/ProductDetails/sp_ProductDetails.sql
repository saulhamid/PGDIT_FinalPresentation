SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE  proc [dbo].[sp_ProductDetails]
(
@Id		int = null,
@ProductId		int = null,
@UOMId		int = null,
@ProductBrandId		int = null,
@ProductCatagoriesId		int = null,
@ProductColorId		int = null,
@ProductSizeId		int = null,
@ProductTypeId		int = null,
@SupplierId		int = null,
@Quantity		decimal = null,
@UnitPrice		decimal = null,
@OpenQuantity		decimal = null,
@MinimumStock		int = null,
@OtherCost		decimal = null,
@Discount		decimal = null,
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
--Save ProductDetails
if(@pOptions=1)
begin
INSERT INTO ProductDetails
(
Id,
ProductId,
UOMId,
ProductBrandId,
ProductCatagoriesId,
ProductColorId,
ProductSizeId,
ProductTypeId,
SupplierId,
Quantity,
UnitPrice,
OpenQuantity,
MinimumStock,
OtherCost,
Discount,
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
@ProductId,
@UOMId,
@ProductBrandId,
@ProductCatagoriesId,
@ProductColorId,
@ProductSizeId,
@ProductTypeId,
@SupplierId,
@Quantity,
@UnitPrice,
@OpenQuantity,
@MinimumStock,
@OtherCost,
@Discount,
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
--End of Save ProductDetails



--Update ProductDetails 
if(@pOptions=2)
begin
UPDATE	ProductDetails 
SET
Id	=	@Id ,
ProductId	=	@ProductId ,
UOMId	=	@UOMId ,
ProductBrandId	=	@ProductBrandId ,
ProductCatagoriesId	=	@ProductCatagoriesId ,
ProductColorId	=	@ProductColorId ,
ProductSizeId	=	@ProductSizeId ,
ProductTypeId	=	@ProductTypeId ,
SupplierId	=	@SupplierId ,
Quantity	=	@Quantity ,
UnitPrice	=	@UnitPrice ,
OpenQuantity	=	@OpenQuantity ,
MinimumStock	=	@MinimumStock ,
OtherCost	=	@OtherCost ,
Discount	=	@Discount ,
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
--End of Update ProductDetails 



--IsDelete ProductDetails



if(@pOptions=3)
begin
UPDATE	ProductDetails 
SET
IsArchive	=	@IsArchive ,
LastUpdateBy	=	@LastUpdateBy ,
LastUpdateAt	=	@LastUpdateAt ,
LastUpdateFrom	=	@LastUpdateFrom 
WHERE	Id	=	@Id;
SET @Msg='Data Deleted Successfully';
end



--End of IsDelete ProductDetails 



--IsDelete ProductDetails



if(@pOptions=4)
begin
Delete from ProductDetails Where Id=@Id;
SET @Msg='Data Deleted Successfully';
end



--End of Delete ProductDetails 



--Select All ProductDetails 



if(@pOptions=5)
begin	        
select * from ProductDetails where IsArchive=0;
if(@@ROWCOUNT=0)
SET @Msg='Data Not Found';
end



--End of Select All ProductDetails 



--Select ProductDetails By Id 
if(@pOptions=6)
begin
select * from ProductDetails Where Id=@Id and IsArchive=0;



if(@@ROWCOUNT=0)
SET @Msg='Data Not Found';
end
--End of Select ProductDetails By Id 



--Select Id,Name ProductDetails 



if(@pOptions=7)
begin	        
select Id,Name  from ProductDetails Where IsActive=1 and IsArchive=0;;
if(@@ROWCOUNT=0)
SET @Msg='Data Not Found';
end



--End Select Id,Name ProductDetails 
