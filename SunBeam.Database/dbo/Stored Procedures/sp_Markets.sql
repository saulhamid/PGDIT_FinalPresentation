
CREATE  proc [dbo].[sp_Markets]
(
@Id		int = null,
@ZoneOrAreaId		int = null,
@Code		nvarchar(20) = null,
@Name		nvarchar(200) = null,
@Description		nvarchar(500) = null,
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
--Save Markets
if(@pOptions=1)
begin
INSERT INTO Markets
(

ZoneOrAreaId,
Code,
Name,
Description,
Remarks,
IsActive,
IsArchive,
CreatedBy,
CreatedAt,
CreatedFrom

)
VALUES
(	
@ZoneOrAreaId,
@Code,
@Name,
@Description,
@Remarks,
@IsActive,
@IsArchive,
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
--End of Save Markets



--Update Markets 
if(@pOptions=2)
begin
UPDATE	Markets 
SET
ZoneOrAreaId	=	@ZoneOrAreaId ,
Code	=	@Code ,
Name	=	@Name ,
Description	=	@Description ,
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
--End of Update Markets 



--IsDelete Markets



if(@pOptions=3)
begin
UPDATE	Markets 
SET
IsArchive	=	@IsArchive ,
LastUpdateBy	=	@LastUpdateBy ,
LastUpdateAt	=	@LastUpdateAt ,
LastUpdateFrom	=	@LastUpdateFrom 
WHERE	Id	=	@Id;
SET @Msg='Data Deleted Successfully';
end



--End of IsDelete Markets 



--IsDelete Markets



if(@pOptions=4)
begin
Delete from Markets Where Id=@Id;
SET @Msg='Data Deleted Successfully';
end



--End of Delete Markets 



--Select All Markets 



if(@pOptions=5)
begin	        
select * from Markets where IsArchive=0;
if(@@ROWCOUNT=0)
SET @Msg='Data Not Found';
end



--End of Select All Markets 



--Select Markets By Id 
if(@pOptions=6)
begin
select * from Markets Where Id=@Id and IsArchive=0;



if(@@ROWCOUNT=0)
SET @Msg='Data Not Found';
end
--End of Select Markets By Id 



--Select Id,Name Markets 



if(@pOptions=7)
begin	        
select Id,Name  from Markets Where IsActive=1 and IsArchive=0;;
if(@@ROWCOUNT=0)
SET @Msg='Data Not Found';
end



--End Select Id,Name Markets 
