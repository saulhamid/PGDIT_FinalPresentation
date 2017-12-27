CREATE proc sp_StockAutoProduct

as
begin
select st.Id,(pro.Name +'~'+prosize.Name+''+u.Name+'~'+CONVERT(nvarchar(20),st.UnitPrice)) StProduct  from Stocks st
left outer join Products pro on pro.Id=st.ProductId
left outer join UOM u on u.Id=pro.UOMId
left outer join ProductSizes prosize on prosize.Id=pro.ProductSizeId
order  by pro.Name
end