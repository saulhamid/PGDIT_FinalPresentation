SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE  proc [dbo].[sp_Users]
(
@Id		int = null,
@FullName		nchar = null,
@UserName		nchar = null,
@Email		nchar = null,
@LogId		nchar = null,
@Password		nchar = null,
@VerificationCode		nchar = null,
@BranchId		int = null,
@EmployeeId		nvarchar(50) = null,
@IsAdmin		bit = null,
@Remember		bit = null,
@IsActive		bit = null,
@IsVerified		bit = null,
@IsArchived		bit = null,
@CreatedBy		nvarchar(50) = null,
@CreatedAt		nvarchar(50) = null,
@CreatedFrom		varchar = null,
@LastUpdateBy		nvarchar(50) = null,
@LastUpdateAt		nvarchar(50) = null,
@LastUpdateFrom		varchar = null,

@Msg				nvarchar(MAX)=null OUT ,
@pOptions			int 
)
AS
--Save Users
if(@pOptions=1)
begin
INSERT INTO Users
(
Id,
FullName,
UserName,
Email,
LogId,
Password,
VerificationCode,
BranchId,
EmployeeId,
IsAdmin,
Remember,
IsActive,
IsVerified,
IsArchived,
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
@FullName,
@UserName,
@Email,
@LogId,
@Password,
@VerificationCode,
@BranchId,
@EmployeeId,
@IsAdmin,
@Remember,
@IsActive,
@IsVerified,
@IsArchived,
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
--End of Save Users



--Update Users 
if(@pOptions=2)
begin
UPDATE	Users 
SET
FullName	=	@FullName ,
UserName	=	@UserName ,
Email	=	@Email ,
LogId	=	@LogId ,
Password	=	@Password ,
VerificationCode	=	@VerificationCode ,
BranchId	=	@BranchId ,
EmployeeId	=	@EmployeeId ,
IsAdmin	=	@IsAdmin ,
Remember	=	@Remember ,
IsActive	=	@IsActive ,
IsVerified	=	@IsVerified ,
IsArchived	=	@IsArchived ,
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
--End of Update Users 



--IsDelete Users



if(@pOptions=3)
begin
UPDATE	Users 
SET
IsArchive	=	@IsArchive ,
LastUpdateBy	=	@LastUpdateBy ,
LastUpdateAt	=	@LastUpdateAt ,
LastUpdateFrom	=	@LastUpdateFrom 
WHERE	Id	=	@Id;
SET @Msg='Data Deleted Successfully';
end



--End of IsDelete Users 



--IsDelete Users



if(@pOptions=4)
begin
Delete from Users Where Id=@Id;
SET @Msg='Data Deleted Successfully';
end



--End of Delete Users 



--Select All Users 



if(@pOptions=5)
begin	        
select * from Users where IsArchive=0;
if(@@ROWCOUNT=0)
SET @Msg='Data Not Found';
end



--End of Select All Users 



--Select Users By Id 
if(@pOptions=6)
begin
select * from Users Where Id=@Id and IsArchive=0;



if(@@ROWCOUNT=0)
SET @Msg='Data Not Found';
end
--End of Select Users By Id 



--Select Id,Name Users 



if(@pOptions=7)
begin	        
select Id,Name  from Users Where IsActive=1 and IsArchive=0;;
if(@@ROWCOUNT=0)
SET @Msg='Data Not Found';
end



--End Select Id,Name Users 
