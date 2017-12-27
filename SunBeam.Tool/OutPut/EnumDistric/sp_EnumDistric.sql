SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE  proc [dbo].[sp_EnumDistric]
(
@Id		int = null,
@Name		nvarchar(200) = null,
@CountryId		int = null,
@DivisionId		int = null,
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
--Save EnumDistric
if(@pOptions=1)
begin
INSERT INTO EnumDistric
(
Id,
Name,
CountryId,
DivisionId,
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
@DivisionId,
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
--End of Save EnumDistric



--Update EnumDistric 
if(@pOptions=2)
begin
UPDATE	EnumDistric 
SET
Name	=	@Name ,
CountryId	=	@CountryId ,
DivisionId	=	@DivisionId ,
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
--End of Update EnumDistric 



--IsDelete EnumDistric



if(@pOptions=3)
begin
UPDATE	EnumDistric 
SET
IsArchive	=	@IsArchive ,
LastUpdateBy	=	@LastUpdateBy ,
LastUpdateAt	=	@LastUpdateAt ,
LastUpdateFrom	=	@LastUpdateFrom 
WHERE	Id	=	@Id;
SET @Msg='Data Deleted Successfully';
end



--End of IsDelete EnumDistric 



--IsDelete EnumDistric



if(@pOptions=4)
begin
Delete from EnumDistric Where Id=@Id;
SET @Msg='Data Deleted Successfully';
end



--End of Delete EnumDistric 



--Select All EnumDistric 



if(@pOptions=5)
begin	        
select * from EnumDistric where IsArchive=0;
if(@@ROWCOUNT=0)
SET @Msg='Data Not Found';
end



--End of Select All EnumDistric 



--Select EnumDistric By Id 
if(@pOptions=6)
begin
select * from EnumDistric Where Id=@Id and IsArchive=0;



if(@@ROWCOUNT=0)
SET @Msg='Data Not Found';
end
--End of Select EnumDistric By Id 



--Select Id,Name EnumDistric 



if(@pOptions=7)
begin	        
select Id,Name  from EnumDistric Where IsActive=1 and IsArchive=0;;
if(@@ROWCOUNT=0)
SET @Msg='Data Not Found';
end



--End Select Id,Name EnumDistric 
