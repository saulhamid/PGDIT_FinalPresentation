SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE  proc [dbo].[sp_EnumCountry]
(
@Id		int = null,
@Name		nvarchar(200) = null,
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
--Save EnumCountry
if(@pOptions=1)
begin
INSERT INTO EnumCountry
(
Name,
Remarks,
IsActive,
IsArchive,
CreatedBy,
CreatedAt,
CreatedFrom

)
VALUES
(	
@Name,
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
--End of Save EnumCountry



--Update EnumCountry 
if(@pOptions=2)
begin
UPDATE	EnumCountry 
SET
Name	=	@Name ,
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
--End of Update EnumCountry 



--IsDelete EnumCountry



if(@pOptions=3)
begin
UPDATE	EnumCountry 
SET
IsArchive	=	@IsArchive ,
LastUpdateBy	=	@LastUpdateBy ,
LastUpdateAt	=	@LastUpdateAt ,
LastUpdateFrom	=	@LastUpdateFrom 
WHERE	Id	=	@Id;
SET @Msg='Data Deleted Successfully';
end



--End of IsDelete EnumCountry 



--IsDelete EnumCountry



if(@pOptions=4)
begin
Delete from EnumCountry Where Id=@Id;
SET @Msg='Data Deleted Successfully';
end



--End of Delete EnumCountry 



--Select All EnumCountry 



if(@pOptions=5)
begin	        
select * from EnumCountry where IsArchive=0;
if(@@ROWCOUNT=0)
SET @Msg='Data Not Found';
end



--End of Select All EnumCountry 



--Select EnumCountry By Id 
if(@pOptions=6)
begin
select * from EnumCountry Where Id=@Id and IsArchive=0;



if(@@ROWCOUNT=0)
SET @Msg='Data Not Found';
end
--End of Select EnumCountry By Id 



--Select Id,Name EnumCountry 



if(@pOptions=7)
begin	        
select Id,Name  from EnumCountry Where IsActive=1 and IsArchive=0;;
if(@@ROWCOUNT=0)
SET @Msg='Data Not Found';
end



--End Select Id,Name EnumCountry 
