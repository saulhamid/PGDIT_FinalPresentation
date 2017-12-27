create proc sp_singleCustomer
(@Id int )
as
begin
select cu.Id, cu.Code,cu.Name,cu.Mobile,cu.Email,cu.PresentAddress,cu.PermanentAddress,edis.Name DistrictName,
edv.Name DivisionName,cent.Name CountryName from Customers cu 
left outer join EnumDistric edis on cu.DistrictId=edis.Id
left outer join EnumDivision edv on cu.DivisionId=edv.Id
left outer join EnumCountry cent on cu.CountryId=cent.Id
where cu.Id=@Id
end