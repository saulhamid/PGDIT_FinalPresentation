create proc sp_singleSupplier
(@Id int )
as
begin
select sp.Id, sp.Code,sp.Name,sp.Mobile,sp.Email,sp.PresentAddress,sp.PermanentAddress,edis.Name DistrictName,
edv.Name DivisionName,cent.Name CountryName from Suppliers sp 
left outer join EnumDistric edis on sp.DistrictId=edis.Id
left outer join EnumDivision edv on sp.DivisionId=edv.Id
left outer join EnumCountry cent on sp.CountryId=cent.Id
where sp.Id=@Id
end