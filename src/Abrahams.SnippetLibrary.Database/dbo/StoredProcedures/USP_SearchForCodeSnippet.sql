CREATE PROCEDURE dbo.USP_SearchForCodeSnippet
(
	@Description NVARCHAR(255) = NULL,
	@CodeSample NVARCHAR(MAX) = NULL,
	@LanguageId INT = NULL
)
AS

	SELECT [CodeSnippetId] = cs.CodeSnippetId,
		   [Description] = cs.[Description],
		   [CodeSample] = cs.CodeSample,
		   [Language] = l.LanguageName,
		   [Tags] = ''
	FROM dbo.CodeSnippet cs 
	INNER JOIN dbo.[Language] l ON cs.LanguageId = l.LanguageId
	WHERE ([Description] LIKE '%' + @Description + '%' OR @Description IS NULL)
	AND (CodeSample LIKE '%' + @CodeSample + '%' OR @CodeSample IS NULL)
	AND (cs.LanguageId = @LanguageId OR @LanguageId IS NULL)

RETURN 0
