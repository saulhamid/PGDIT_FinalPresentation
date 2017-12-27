CREATE proc [dbo].[SP_Product]
(
@Id int=null
,@Code nvarchar(20)=null
,@Name nvarchar(50)=null
,@UOMId int=null
,@ProductBrandId int=null
,@ProductCatagoriesId int=null
,@ProductColorId int=null
,@ProductSizeId int=null
,@ProductTypeId int=null
,@SupplierId int=null
,@MinimumStock int=null
,@OtherCost decimal(18,2)=null
,@Discount decimal(18,2)=null
,@UnitePrice decimal(18,2)=null
,@Quantity decimal(18,2)=null
,@OpeningQuantity decimal(18,2)=null
,@Remarks nvarchar(500)=null
,@CreatedBy nvarchar(20)=null
,@CreatedAt nvarchar(14)=null
,@CreatedFrom nvarchar(50)=null
,@LastUpdateBy nvarchar(20)=null
,@LastUpdateAt nvarchar(14)=null
,@LastUpdateFrom nvarchar(50)=null
,@pOptions  int=5
 )
 as 
 begin
 if(@pOptions =1)
 begin
 insert into dbo.Products (
 Code
,Name
,UOMId
,ProductBrandId
,ProductCatagoriesId
,ProductColorId
,ProductSizeId
,ProductTypeId
,SupplierId
,MinimumStock
,OtherCost
,Discount
,UnitePrice
,Quantity
,OpeningQuantity
,Remarks
,IsActive
,IsArchive
,CreatedBy
,CreatedAt
,CreatedFrom
)
VALUES(@Code
,@Name
,@UOMId
,@ProductBrandId
,@ProductCatagoriesId
,@ProductColorId
,@ProductSizeId
,@ProductTypeId
,@SupplierId
,@MinimumStock
,@OtherCost
,@Discount
,@UnitePrice
,@Quantity
,@OpeningQuantity
,@Remarks
,1
,0
,@CreatedBy
,@CreatedAt
,@CreatedFrom
 )
 end
  if(@pOptions =2)
 begin
 update dbo.Products 
 set 
Code=@Code
,Name=@Name
,UOMId=@UOMId
,ProductBrandId=@ProductBrandId
,ProductCatagoriesId=@ProductCatagoriesId
,ProductColorId=@ProductColorId
,ProductSizeId=@ProductSizeId
,ProductTypeId=@ProductTypeId
,SupplierId=@SupplierId
,MinimumStock=@MinimumStock
,OtherCost=@OtherCost
,Discount=@Discount
,UnitePrice=@UnitePrice
,Quantity=@Quantity
,OpeningQuantity=@OpeningQuantity
,Remarks=@Remarks
,IsActive=1
,IsArchive=0
,LastUpdateBy=@LastUpdateBy
,LastUpdateAt=@LastUpdateAt
,LastUpdateFrom=@LastUpdateFrom
where id=@id
 end
 if(@pOptions =3)
 begin
delete  dbo.Products where 	 Id=@Id 
 end
  if(@pOptions =4)
 begin
select *FROM dbo.Products WHERE Id=@Id 
 end
    if(@pOptions =5)
 begin
select *FROM dbo.Products pur
left outer join dbo.UOM um on  pur.UOMId=um.Id
 end
 --Getby Product Code
   if(@pOptions =6)
 begin
select Convert(nvarchar(50),pur.Id ) Id, (ISNULL(pur.Code,'') +'-'+ISNULL(pur.Name,'') +' '+ISNULL( size.Name,'') +'('+ISNULL(um.Name,'')+')') as Name FROM dbo.Products pur
left outer join dbo.UOM um on  pur.UOMId=um.Id
left outer join dbo.ProductSizes size on  pur.ProductSizeId=size.Id

 end
 --Getby Product Code
   if(@pOptions =7)
 begin
select * FROM dbo.Products pur
left outer join dbo.UOM um on  pur.UOMId=um.Id
left outer join dbo.ProductSizes size on  pur.ProductSizeId=size.Id
where pur.Code =@Code
 end
 end