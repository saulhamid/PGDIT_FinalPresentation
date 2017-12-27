SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE  proc [dbo].[sp_Organizations]
(
@Id		int = null,
@Code		nvarchar(20) = null,
@Name		nvarchar(200) = null,
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
--Save Organizations
if(@pOptions=1)
begin
INSERT INTO Organizations
(
Id,
Code,
Name,
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
CreatedFrom,
LastUpdateBy,
LastUpdateAt,
LastUpdateFrom

)
VALUES
(	
@Id,
@Code,
@Name,
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
--End of Save Organizations



--Update Organizations 
if(@pOptions=2)
begin
UPDATE	Organizations 
SET
Code	=	@Code ,
Name	=	@Name ,
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
--End of Update Organizations 



--IsDelete Organizations



if(@pOptions=3)
begin
UPDATE	Organizations 
SET
IsArchive	=	@IsArchive ,
LastUpdateBy	=	@LastUpdateBy ,
LastUpdateAt	=	@LastUpdateAt ,
LastUpdateFrom	=	@LastUpdateFrom 
WHERE	Id	=	@Id;
SET @Msg='Data Deleted Successfully';
end



--End of IsDelete Organizations 



--IsDelete Organizations



if(@pOptions=4)
begin
Delete from Organizations Where Id=@Id;
SET @Msg='Data Deleted Successfully';
end



--End of Delete Organizations 



--Select All Organizations 



if(@pOptions=5)
begin	        
select * from Organizations where IsArchive=0;
if(@@ROWCOUNT=0)
SET @Msg='Data Not Found';
end



--End of Select All Organizations 



--Select Organizations By Id 
if(@pOptions=6)
begin
select * from Organizations Where Id=@Id and IsArchive=0;



if(@@ROWCOUNT=0)
SET @Msg='Data Not Found';
end
--End of Select Organizations By Id 



--Select Id,Name Organizations 



if(@pOptions=7)
begin	        
select Id,Name  from Organizations Where IsActive=1 and IsArchive=0;;
if(@@ROWCOUNT=0)
SET @Msg='Data Not Found';
end



--End Select Id,Name Organizations 
