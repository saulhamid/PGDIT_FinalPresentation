
create  proc [dbo].[sp_ProductColor]
(
@Id		int = null,
@Code		nvarchar(20) = null,
@Name		nvarchar(200) = null,
@Remarks		nvarchar(500) = null,
@IsActive		bit = null,
@IsArchive		bit = null,
@CreatedBy		nvarchar(20) = null,
@CreatedAt		nvarchar(14) = null,
@CreatedFrom		nvarchar(50) = null,
@LastUpdateBy		nvarchar(20) = null,
@LastUpdateAt		nvarchar(14) = null,
@LastUpdateFrom		nvarchar(50) = null,

@Msg				nvarchar(MAX)=null OUT ,
@pOptions			int 
)
AS
--Save ProductColor
if(@pOptions=1)
begin
INSERT INTO ProductColor
(
Id,
Code,
Name,
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
--End of Save ProductColor



--Update ProductColor 
if(@pOptions=2)
begin
UPDATE	ProductColor 
SET
Code	=	@Code ,
Name	=	@Name ,
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
--End of Update ProductColor 



--IsDelete ProductColor



if(@pOptions=3)
begin
UPDATE	ProductColor 
SET
IsArchive	=	@IsArchive ,
LastUpdateBy	=	@LastUpdateBy ,
LastUpdateAt	=	@LastUpdateAt ,
LastUpdateFrom	=	@LastUpdateFrom 
WHERE	Id	=	@Id;
SET @Msg='Data Deleted Successfully';
end



--End of IsDelete ProductColor 



--IsDelete ProductColor



if(@pOptions=4)
begin
Delete from ProductColor Where Id=@Id;
SET @Msg='Data Deleted Successfully';
end



--End of Delete ProductColor 



--Select All ProductColor 



if(@pOptions=5)
begin	        
select * from ProductColor;
if(@@ROWCOUNT=0)
SET @Msg='Data Not Found';
end



--End of Select All ProductColor 



--Select ProductColor By Id 
if(@pOptions=6)
begin
select * from ProductColor Where Id=@Id;



if(@@ROWCOUNT=0)
SET @Msg='Data Not Found';
end
--End of Select ProductColor By Id 



--Select Id,Name ProductColor 



if(@pOptions=7)
begin	        
select Id,Name  from ProductColor;
if(@@ROWCOUNT=0)
SET @Msg='Data Not Found';
end



--End Select Id,Name ProductColor 
