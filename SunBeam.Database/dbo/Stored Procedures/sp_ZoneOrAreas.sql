
CREATE  proc [dbo].[sp_ZoneOrAreas]
(
@Id		int = null,
@Code		nvarchar(20) = null,
@Name		nvarchar(200) = null,
@Description		nchar = null,
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
--Save ZoneOrAreas
if(@pOptions=1)
begin
INSERT INTO ZoneOrAreas
(
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
@Code,
@Name,
@Description,
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
--End of Save ZoneOrAreas



--Update ZoneOrAreas 
if(@pOptions=2)
begin
UPDATE	ZoneOrAreas 
SET
Code	=	@Code ,
Name	=	@Name ,
Description	=	@Description ,
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
--End of Update ZoneOrAreas 



--IsDelete ZoneOrAreas



if(@pOptions=3)
begin
UPDATE	ZoneOrAreas 
SET
IsArchive	=	@IsArchive ,
LastUpdateBy	=	@LastUpdateBy ,
LastUpdateAt	=	@LastUpdateAt ,
LastUpdateFrom	=	@LastUpdateFrom 
WHERE	Id	=	@Id;
SET @Msg='Data Deleted Successfully';
end



--End of IsDelete ZoneOrAreas 



--IsDelete ZoneOrAreas



if(@pOptions=4)
begin
Delete from ZoneOrAreas Where Id=@Id;
SET @Msg='Data Deleted Successfully';
end



--End of Delete ZoneOrAreas 



--Select All ZoneOrAreas 



if(@pOptions=5)
begin	        
select * from ZoneOrAreas where IsArchive=0;
if(@@ROWCOUNT=0)
SET @Msg='Data Not Found';
end



--End of Select All ZoneOrAreas 



--Select ZoneOrAreas By Id 
if(@pOptions=6)
begin
select * from ZoneOrAreas Where Id=@Id and IsArchive=0;



if(@@ROWCOUNT=0)
SET @Msg='Data Not Found';
end
--End of Select ZoneOrAreas By Id 



--Select Id,Name ZoneOrAreas 



if(@pOptions=7)
begin	        
select Id,Name  from ZoneOrAreas Where IsActive=1 and IsArchive=0;;
if(@@ROWCOUNT=0)
SET @Msg='Data Not Found';
end



--End Select Id,Name ZoneOrAreas 
