create proc sp_singleEmployee
(@Id int )
as
begin
select em.Id, em.Code,em.Name,em.Mobile,em.Email,em.PresentAddress,em.PermanentAddress,edis.Name DistrictName,
edv.Name DivisionName,cent.Name CountryName from Employee em 
left outer join EnumDistric edis on em.DistrictId=edis.Id
left outer join EnumDivision edv on em.DivisionId=edv.Id
left outer join EnumCountry cent on em.CountryId=cent.Id
where em.Id=@Id
end