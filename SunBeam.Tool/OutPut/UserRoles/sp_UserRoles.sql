SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE  proc [dbo].[sp_UserRoles]
(
@Id		int = null,
@BranchId		int = null,
@UserInfoId		nvarchar(128) = null,
@RoleInfoId		nvarchar(128) = null,
@IsArchived		bit = null,

@Msg				nvarchar(MAX)=null OUT ,
@pOptions			int 
)
AS
--Save UserRoles
if(@pOptions=1)
begin
INSERT INTO UserRoles
(
Id,
BranchId,
UserInfoId,
RoleInfoId,
IsArchived

)
VALUES
(	
@Id,
@BranchId,
@UserInfoId,
@RoleInfoId,
@IsArchived

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
--End of Save UserRoles



--Update UserRoles 
if(@pOptions=2)
begin
UPDATE	UserRoles 
SET
BranchId	=	@BranchId ,
UserInfoId	=	@UserInfoId ,
RoleInfoId	=	@RoleInfoId ,
IsArchived	=	@IsArchived 




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
--End of Update UserRoles 



--IsDelete UserRoles



if(@pOptions=3)
begin
UPDATE	UserRoles 
SET
IsArchive	=	@IsArchive ,
LastUpdateBy	=	@LastUpdateBy ,
LastUpdateAt	=	@LastUpdateAt ,
LastUpdateFrom	=	@LastUpdateFrom 
WHERE	Id	=	@Id;
SET @Msg='Data Deleted Successfully';
end



--End of IsDelete UserRoles 



--IsDelete UserRoles



if(@pOptions=4)
begin
Delete from UserRoles Where Id=@Id;
SET @Msg='Data Deleted Successfully';
end



--End of Delete UserRoles 



--Select All UserRoles 



if(@pOptions=5)
begin	        
select * from UserRoles where IsArchive=0;
if(@@ROWCOUNT=0)
SET @Msg='Data Not Found';
end



--End of Select All UserRoles 



--Select UserRoles By Id 
if(@pOptions=6)
begin
select * from UserRoles Where Id=@Id and IsArchive=0;



if(@@ROWCOUNT=0)
SET @Msg='Data Not Found';
end
--End of Select UserRoles By Id 



--Select Id,Name UserRoles 



if(@pOptions=7)
begin	        
select Id,Name  from UserRoles Where IsActive=1 and IsArchive=0;;
if(@@ROWCOUNT=0)
SET @Msg='Data Not Found';
end



--End Select Id,Name UserRoles 
