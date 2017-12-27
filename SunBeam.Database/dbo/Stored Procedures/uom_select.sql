create proc uom_select
as
begin
SELECT [Id]
      ,[Code]
      ,[Name]
      ,[Remarks]
      ,[IsActive]
      ,[IsArchive]
      ,[CreatedBy]
      ,[CreatedAt]
      ,[CreatedFrom]
      ,[LastUpdateBy]
      ,[LastUpdateAt]
      ,[LastUpdateFrom]
  FROM [dbo].[UOM]
  end


