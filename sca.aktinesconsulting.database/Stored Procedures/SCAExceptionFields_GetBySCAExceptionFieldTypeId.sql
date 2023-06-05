CREATE PROCEDURE [dbo].[SCAExceptionFields_GetBySCAExceptionFieldTypeId]
@SCAExceptionFieldTypeId int=NULL
AS
BEGIN
	SET NOCOUNT ON;
	SELECT sf.SCAExceptionFieldId,sf.SCAExceptionFieldTypeId,sft.[Name] as SCAExceptionFieldType ,sf.[Name] 
	FROM [dbo].SCAExceptionFields sf
	INNER JOIN [dbo].SCAExceptionFieldTypes sft ON sft.SCAExceptionFieldTypeId=sf.SCAExceptionFieldTypeId
	WHERE (@SCAExceptionFieldTypeId IS NULL OR sf.SCAExceptionFieldTypeId=@SCAExceptionFieldTypeId)
	ORDER BY sf.SCAExceptionFieldTypeId,sft.[Name],sf.[Name]  
END