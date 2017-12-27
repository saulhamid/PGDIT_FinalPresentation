CREATE proc Market_Insert(
			@id int
			, @ZoneOrAreaId int
			,@Code nvarchar(20)
           , @Name  nvarchar(200)
           , @Description nvarchar(200)
           , @Remarks nvarchar(200)
           , @IsActive bit
           , @IsArchive bit
           , @CreatedBy nvarchar(50)
           , @CreatedAt nvarchar(50)
           , @CreatedFrom nvarchar(50)
           , @LastUpdateBy nvarchar(50)
           , @LastUpdateAt nvarchar(50)
           , @LastUpdateFrom nvarchar(50)

)
as
begin
if(@id = null) 
begin
INSERT INTO  dbo . Markets 
           ( Code 
			,ZoneOrAreaId
           , Name 
           , Description 
           , Remarks 
           , IsActive 
           , IsArchive 
           , CreatedBy 
           , CreatedAt 
           , CreatedFrom 
		    )
     VALUES
           ( @ZoneOrAreaId  
		   , @Code
           , @Name 
           , @Description 
           , @Remarks
           , @IsActive
           , @IsArchive
           , @CreatedBy
           , @CreatedAt
           , @CreatedFrom
		   )
end
if(@id != null)
begin
update Markets 
set
ZoneOrAreaId=@ZoneOrAreaId
,Code=@Code
,Name=@Name
,Description=@Description 
,Remarks=@Remarks
,IsActive=@IsActive
,IsArchive=@IsArchive
,LastUpdateBy=@LastUpdateBy
,LastUpdateAt=@LastUpdateAt
,LastUpdateFrom=@LastUpdateFrom
where Id=@id
end
end
