CREATE proc [dbo].[productdetail]
as 
begin
select p.Id,p.Code,p.Name,p.Remarks,p.Discount,p.MinimumStock,p.OpeningQuantity,p.UnitePrice,pb.Code BrandCode,pb.Name BrandName
,pc.Code CategoryCode,pc.Name CategoryName,pco.Code ColorCode,pco.Name ColorName,ps.Code SizeCode,ps.Name SizeName,
pt.Code TypeCode,pt.Name TypeName,u.Code UOMCode,u.Name UOMName,p.IsActive from Products p
left outer join ProductBrands pb on pb.Id=p.ProductBrandId
left outer join ProductCategorys pc on pc.Id=p.ProductCatagoriesId
left outer join ProductColor pco on pco.Id=p.ProductColorId
left outer join ProductSizes ps on ps.Id=p.ProductSizeId
left outer join ProductTypes pt on pt.Id=p.ProductTypeId
left outer join UOM u on u.Id=p.UOMId
where p.IsArchive = 0
end