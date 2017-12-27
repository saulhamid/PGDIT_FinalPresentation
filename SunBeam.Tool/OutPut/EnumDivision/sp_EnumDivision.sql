SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE  proc [dbo].[sp_EnumDivision]
(
@Id		int = null,
@Name		nvarchar(200) = null,
@CountryId		int = null,
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
--Save EnumDivision
if(@pOptions=1)
begin
INSERT INTO EnumDivision
(
Id,
Name,
CountryId,
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
@Name,
@CountryId,
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
--End of Save EnumDivision



--Update EnumDivision 
if(@pOptions=2)
begin
UPDATE	EnumDivision 
SET
Name	=	@Name ,
CountryId	=	@CountryId ,
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
--End of Update EnumDivision 



--IsDelete EnumDivision



if(@pOptions=3)
begin
UPDATE	EnumDivision 
SET
IsArchive	=	@IsArchive ,
LastUpdateBy	=	@LastUpdateBy ,
LastUpdateAt	=	@LastUpdateAt ,
LastUpdateFrom	=	@LastUpdateFrom 
WHERE	Id	=	@Id;
SET @Msg='Data Deleted Successfully';
end



--End of IsDelete EnumDivision 



--IsDelete EnumDivision



if(@pOptions=4)
begin
Delete from EnumDivision Where Id=@Id;
SET @Msg='Data Deleted Successfully';
end



--End of Delete EnumDivision 



--Select All EnumDivision 



if(@pOptions=5)
begin	        
select * from EnumDivision where IsArchive=0;
if(@@ROWCOUNT=0)
SET @Msg='Data Not Found';
end



--End of Select All EnumDivision 



--Select EnumDivision By Id 
if(@pOptions=6)
begin
select * from EnumDivision Where Id=@Id and IsArchive=0;



if(@@ROWCOUNT=0)
SET @Msg='Data Not Found';
end
--End of Select EnumDivision By Id 



--Select Id,Name EnumDivision 



if(@pOptions=7)
begin	        
select Id,Name  from EnumDivision Where IsActive=1 and IsArchive=0;;
if(@@ROWCOUNT=0)
SET @Msg='Data Not Found';
end



--End Select Id,Name EnumDivision 
