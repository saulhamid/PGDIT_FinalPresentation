
CREATE  proc [dbo].[sp_ProductCategorys]
(
@Id		int = null,
@Code		nvarchar(20) = null,
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
--Save ProductCategorys
if(@pOptions=1)
begin
INSERT INTO ProductCategorys
(
Code,
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
@Code,
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
--End of Save ProductCategorys



--Update ProductCategorys 
if(@pOptions=2)
begin
UPDATE	ProductCategorys 
SET
Code	=	@Code ,
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
--End of Update ProductCategorys 



--IsDelete ProductCategorys



if(@pOptions=3)
begin
UPDATE	ProductCategorys 
SET
IsArchive	=	@IsArchive ,
LastUpdateBy	=	@LastUpdateBy ,
LastUpdateAt	=	@LastUpdateAt ,
LastUpdateFrom	=	@LastUpdateFrom 
WHERE	Id	=	@Id;
SET @Msg='Data Deleted Successfully';
end



--End of IsDelete ProductCategorys 



--IsDelete ProductCategorys



if(@pOptions=4)
begin
Delete from ProductCategorys Where Id=@Id;
SET @Msg='Data Deleted Successfully';
end



--End of Delete ProductCategorys 



--Select All ProductCategorys 



if(@pOptions=5)
begin	        
select * from ProductCategorys where IsArchive=0;
if(@@ROWCOUNT=0)
SET @Msg='Data Not Found';
end



--End of Select All ProductCategorys 



--Select ProductCategorys By Id 
if(@pOptions=6)
begin
select * from ProductCategorys Where Id=@Id and IsArchive=0;



if(@@ROWCOUNT=0)
SET @Msg='Data Not Found';
end
--End of Select ProductCategorys By Id 



--Select Id,Name ProductCategorys 



if(@pOptions=7)
begin	        
select Id,Name  from ProductCategorys Where IsActive=1 and IsArchive=0;;
if(@@ROWCOUNT=0)
SET @Msg='Data Not Found';
end



--End Select Id,Name ProductCategorys 
