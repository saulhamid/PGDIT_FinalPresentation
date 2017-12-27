SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE  proc [dbo].[sp_ProductBrands]
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
--Save ProductBrands
if(@pOptions=1)
begin
INSERT INTO ProductBrands
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
--End of Save ProductBrands



--Update ProductBrands 
if(@pOptions=2)
begin
UPDATE	ProductBrands 
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
--End of Update ProductBrands 



--IsDelete ProductBrands



if(@pOptions=3)
begin
UPDATE	ProductBrands 
SET
IsArchive	=	@IsArchive ,
LastUpdateBy	=	@LastUpdateBy ,
LastUpdateAt	=	@LastUpdateAt ,
LastUpdateFrom	=	@LastUpdateFrom 
WHERE	Id	=	@Id;
SET @Msg='Data Deleted Successfully';
end



--End of IsDelete ProductBrands 



--IsDelete ProductBrands



if(@pOptions=4)
begin
Delete from ProductBrands Where Id=@Id;
SET @Msg='Data Deleted Successfully';
end



--End of Delete ProductBrands 



--Select All ProductBrands 



if(@pOptions=5)
begin	        
select * from ProductBrands where IsArchive=0;
if(@@ROWCOUNT=0)
SET @Msg='Data Not Found';
end



--End of Select All ProductBrands 



--Select ProductBrands By Id 
if(@pOptions=6)
begin
select * from ProductBrands Where Id=@Id and IsArchive=0;



if(@@ROWCOUNT=0)
SET @Msg='Data Not Found';
end
--End of Select ProductBrands By Id 



--Select Id,Name ProductBrands 



if(@pOptions=7)
begin	        
select Id,Name  from ProductBrands Where IsActive=1 and IsArchive=0;;
if(@@ROWCOUNT=0)
SET @Msg='Data Not Found';
end



--End Select Id,Name ProductBrands 
