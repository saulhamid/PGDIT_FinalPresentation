
CREATE  proc [dbo].[sp_Suppliers]
(
@Id		int = null,
@BranchId		int = null,
@Code		nvarchar(20) = null,
@Name		nvarchar(50) = null,
@Salutation_E		nvarchar(200) = null,
@MiddleName		nvarchar(200) = null,
@LastName		nvarchar(200) = null,
@CountryId		int = null,
@DivisionId		int = null,
@DistrictId		int = null,
@Mobile		nvarchar(20) = null,
@PermanentAddress		nvarchar(500) = null,
@PresentAddress		nvarchar(500) = null,
@PABX		nvarchar(100) = null,
@Email		nvarchar(100) = null,
@FAX		nvarchar(100) = null,
@Remarks		nvarchar(500) = null,
@IsActive		bit = null,
@IsArchive		bit = null,
@CreatedBy		nvarchar(50) = null,
@CreatedAt		nvarchar(50) = null,
@CreatedFrom		nvarchar(50) = null,
@LastUpdateBy		nvarchar(50) = null,
@LastUpdateAt		nvarchar(50) = null,
@LastUpdateFrom		nvarchar(50) = null,

@Msg				nvarchar(MAX)=null OUT ,
@pOptions			int 
)
AS
--Save Suppliers
if(@pOptions=1)
begin
INSERT INTO Suppliers
(
BranchId,
Code,
Name,
Salutation_E,
MiddleName,
LastName,
CountryId,
DivisionId,
DistrictId,
Mobile,
PermanentAddress,
PresentAddress,
PABX,
Email,
FAX,
Remarks,
IsActive,
IsArchive,
CreatedBy,
CreatedAt,
CreatedFrom

)
VALUES
(	
@BranchId,
@Code,
@Name,
@Salutation_E,
@MiddleName,
@LastName,
@CountryId,
@DivisionId,
@DistrictId,
@Mobile,
@PermanentAddress,
@PresentAddress,
@PABX,
@Email,
@FAX,
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
--End of Save Suppliers



--Update Suppliers 
if(@pOptions=2)
begin
UPDATE	Suppliers 
SET
BranchId	=	@BranchId ,
Code	=	@Code ,
Name	=	@Name ,
Salutation_E	=	@Salutation_E ,
MiddleName	=	@MiddleName ,
LastName	=	@LastName ,
CountryId	=	@CountryId ,
DivisionId	=	@DivisionId ,
DistrictId	=	@DistrictId ,
Mobile	=	@Mobile ,
PermanentAddress	=	@PermanentAddress ,
PresentAddress	=	@PresentAddress ,
PABX	=	@PABX ,
Email	=	@Email ,
FAX	=	@FAX ,
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
--End of Update Suppliers 



--IsDelete Suppliers



if(@pOptions=3)
begin
UPDATE	Suppliers 
SET
IsArchive	=	@IsArchive ,
LastUpdateBy	=	@LastUpdateBy ,
LastUpdateAt	=	@LastUpdateAt ,
LastUpdateFrom	=	@LastUpdateFrom 
WHERE	Id	=	@Id;
SET @Msg='Data Deleted Successfully';
end



--End of IsDelete Suppliers 



--IsDelete Suppliers



if(@pOptions=4)
begin
Delete from Suppliers Where Id=@Id;
SET @Msg='Data Deleted Successfully';
end



--End of Delete Suppliers 



--Select All Suppliers 



if(@pOptions=5)
begin	        
select * from Suppliers where IsArchive=0;
if(@@ROWCOUNT=0)
SET @Msg='Data Not Found';
end



--End of Select All Suppliers 



--Select Suppliers By Id 
if(@pOptions=6)
begin
select * from Suppliers Where Id=@Id and IsArchive=0;



if(@@ROWCOUNT=0)
SET @Msg='Data Not Found';
end
--End of Select Suppliers By Id 



--Select Id,Name Suppliers 



if(@pOptions=7)
begin	        
select Id,Name  from Suppliers Where IsActive=1 and IsArchive=0;;
if(@@ROWCOUNT=0)
SET @Msg='Data Not Found';
end



--End Select Id,Name Suppliers 
