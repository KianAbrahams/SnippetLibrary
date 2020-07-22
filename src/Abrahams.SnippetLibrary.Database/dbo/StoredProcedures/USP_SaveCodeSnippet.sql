CREATE PROCEDURE dbo.USP_SaveCodeSnippet 
(
	@Description NVARCHAR(255), 
	@LanguageId INT, 
	@CodeSnippetId INT = 0
)
AS
	IF (EXISTS (SELECT CodeSnippetId FROM CodeSnippet WHERE CodeSnippetId = @CodeSnippetId))
	BEGIN
		UPDATE dbo.CodeSnippet
		SET [Description] = @Description, 
			LanguageId = @LanguageId
		WHERE CodeSnippetId = @CodeSnippetId
	END 
	ELSE
	BEGIN
		INSERT INTO dbo.CodeSnippet ([Description], LanguageId) 
		VALUES (@Description, @LanguageId)
	END

RETURN 0