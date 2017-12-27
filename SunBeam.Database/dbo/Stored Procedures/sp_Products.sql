
CREATE  proc [dbo].[sp_Products]
(
@Id		int = null,
@Name		nvarchar(200) = null,
@Code		nvarchar(20) = null,
@UOMId		int = null,
@ProductBrandId		int = null,
@ProductCatagoriesId		int = null,
@ProductColorId		int = null,
@ProductSizeId		int = null,
@ProductTypeId		int = null,
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
Name,
Code,
UOMId,
ProductBrandId,
ProductCatagoriesId,
ProductColorId,
ProductSizeId,
ProductTypeId,
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
CreatedFrom

)
VALUES
(	
@Name,
@Code,
@UOMId,
@ProductBrandId,
@ProductCatagoriesId,
@ProductColorId,
@ProductSizeId,
@ProductTypeId,
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
--End of Save Products



--Update Products 
if(@pOptions=2)
begin
UPDATE	Products 
SET
Name	=	@Name ,
Code	=	@Code ,
UOMId	=	@UOMId ,
ProductBrandId	=	@ProductBrandId ,
ProductCatagoriesId	=	@ProductCatagoriesId ,
ProductColorId	=	@ProductColorId ,
ProductSizeId	=	@ProductSizeId ,
ProductTypeId	=	@ProductTypeId ,
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
select 
p.Id,
p.Name,
p.Code,
p.UOMId,
p.ProductBrandId,
p.ProductCatagoriesId,
p.ProductColorId,
p.ProductSizeId,
p.ProductTypeId,
p.SupplierId,
p.MinimumStock,
p.OtherCost,
p.Discount,
p.UnitePrice,
p.Quantity,
p.OpeningQuantity,
p.Remarks,
p.IsActive,
p.IsArchive,
p.CreatedBy,
p.CreatedAt,
p.CreatedFrom
,ps.Name ProductTypeName,
pt.Name ProductSizeName
,u.Name UOMName
 from Products p  
left outer join ProductSize ps on ps.Id=p.ProductSizeId
left outer join ProductTypes pt on pt.Id=p.ProductTypeId
left outer join UOM u on u.Id=p.UOMId Where p.Id=@Id and p.IsArchive=0;



if(@@ROWCOUNT=0)
SET @Msg='Data Not Found';
end
--End of Select Products By Id 



--Select Id,Name Products 



if(@pOptions=7)
begin	        
select p.Id,(p.Code+'~'+p.Name +' '+ ps.Name+' ('+u.Name+')') Name  from Products  p
left outer join ProductSize ps on ps.Id=p.ProductSizeId
left outer join ProductTypes pt on pt.Id=p.ProductTypeId
left outer join UOM u on u.Id=p.UOMId
Where p.IsActive=1 and p.IsArchive=0;
if(@@ROWCOUNT=0)
SET @Msg='Data Not Found';
end



--End Select Id,Name Products 
--Select  Products Detail



if(@pOptions=8)
begin	        
select  p.Id,p.Code,p.Name,p.ProductBrandId,pb.Name ProductBrandName
,p.ProductCatagoriesId,pc.Name ProductCatagoriesName,
p.ProductColorId,pc.Name ProductColorName,
p.ProductSizeId,ps.Name ProductSizeName,
p.ProductTypeId,pt.Name ProductTypeName	,
p.UOMId,u.Name UOMName	,p.IsArchive ,p.IsActive
from Products p
left outer join ProductBrands pb on pb.Id=p.ProductBrandId
left outer join ProductCategorys pc on pc.Id=p.ProductCatagoriesId
left outer join ProductColor pco on pco.Id=p.ProductColorId
left outer join ProductSize ps on ps.Id=p.ProductSizeId
left outer join ProductTypes pt on pt.Id=p.ProductTypeId
left outer join UOM u on u.Id=p.UOMId
 Where p.IsArchive=0;
if(@@ROWCOUNT=0)
SET @Msg='Data Not Found';
end



--End Select Id,Name Products 
