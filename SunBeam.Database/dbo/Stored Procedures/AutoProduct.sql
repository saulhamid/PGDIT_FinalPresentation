CREATE proc AutoProduct
(
@term nvarchar(50)
)
as
begin 
select (pro.Code+'~'+ pro.Name+'('+ps.Name+u.Name+')') ProductName from  Products pro
left outer join UOM u on u.Id=pro.UOMId
--left outer join ProductSizes ps on ps.Id=pro.ProductSizeId
where pro.IsArchive=0 and pro.IsActive=1 and pro.Name like '%'+@term+'%' or pro.Code like '%'+@term+'%'
end