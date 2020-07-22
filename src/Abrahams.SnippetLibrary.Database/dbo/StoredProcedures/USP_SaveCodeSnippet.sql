CREATE PROCEDURE dbo.USP_SaveCodeSnippet 
(
	@Description NVARCHAR(255), 
	@CodeSample NVARCHAR(MAX),
	@LanguageId INT, 
	@CodeSnippetId INT = 0
)
AS
	IF (EXISTS (SELECT CodeSnippetId FROM CodeSnippet WHERE CodeSnippetId = @CodeSnippetId))
	BEGIN
		UPDATE dbo.CodeSnippet
		SET [Description] = @Description, 
			LanguageId = @LanguageId,
			CodeSample = @CodeSample
		WHERE CodeSnippetId = @CodeSnippetId
	END 
	ELSE
	BEGIN
		INSERT INTO dbo.CodeSnippet ([Description], CodeSample, LanguageId) 
		VALUES (@Description, @CodeSample, @LanguageId)
	END

RETURN 0