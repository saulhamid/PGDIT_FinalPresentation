
CREATE  proc [dbo].[sp_Purchases]
(
@Id		int = null,
@InvoiecNo		nvarchar(200) = null,
@SupplierId		int = null,
@EmployeeId		int = null,
@Date		nvarchar(50) = null,
@Discount		decimal = null,
@CouponName		nvarchar(100) = null,
@CouponAmunt		decimal = null,
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
--Save Purchases
if(@pOptions=1)
begin
INSERT INTO Purchases
(
Id,
InvoiecNo,
SupplierId,
EmployeeId,
Date,
Discount,
CouponName,
CouponAmunt,
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
@Id	,
@InvoiecNo,
@SupplierId,
@EmployeeId,
@Date,
@Discount,
@CouponName,
@CouponAmunt,
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
--End of Save Purchases



--Update Purchases 
if(@pOptions=2)
begin
UPDATE	Purchases 
SET
InvoiecNo	=	@InvoiecNo ,
SupplierId	=	@SupplierId ,
EmployeeId	=	@EmployeeId ,
Date	=	@Date ,
Discount	=	@Discount ,
CouponName	=	@CouponName ,
CouponAmunt	=	@CouponAmunt ,
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
--End of Update Purchases 



--IsDelete Purchases



if(@pOptions=3)
begin
UPDATE	Purchases 
SET
IsArchive	=	@IsArchive ,
LastUpdateBy	=	@LastUpdateBy ,
LastUpdateAt	=	@LastUpdateAt ,
LastUpdateFrom	=	@LastUpdateFrom 
WHERE	Id	=	@Id;
SET @Msg='Data Deleted Successfully';
end



--End of IsDelete Purchases 



--IsDelete Purchases



if(@pOptions=4)
begin
Delete from Purchases Where Id=@Id;
SET @Msg='Data Deleted Successfully';
end



--End of Delete Purchases 



--Select All Purchases 



if(@pOptions=5)
begin	        
select 
pur.Id,
pur.InvoiecNo,
pur.SupplierId,
pur.EmployeeId,
pur.Date,
pur.Discount,
pur.CouponName,
pur.CouponAmunt,
pur.Remarks,
pur.IsActive,
pur.IsArchive,
pur.CreatedBy,
pur.CreatedAt,
pur.CreatedFrom,
pur.LastUpdateBy,
pur.LastUpdateAt,
pur.LastUpdateFrom
, s.Name  SupplierName
, e.Name  EmployeeName
 from Purchases pur
left outer join Suppliers s on s.Id = pur.SupplierId
left outer join Employee e on e.Id = pur.EmployeeId
where pur.IsArchive=0;
if(@@ROWCOUNT=0)
SET @Msg='Data Not Found';
end



--End of Select All Purchases 



--Select Purchases By Id 
if(@pOptions=6)
begin
select * from Purchases Where Id=@Id and IsArchive=0;



if(@@ROWCOUNT=0)
SET @Msg='Data Not Found';
end
--End of Select Purchases By Id 



--Select Id,Name Purchases 



if(@pOptions=7)
begin	        
select Id  from Purchases Where IsActive=1 and IsArchive=0;;
if(@@ROWCOUNT=0)
SET @Msg='Data Not Found';
end



--End Select Id,Name Purchases 
