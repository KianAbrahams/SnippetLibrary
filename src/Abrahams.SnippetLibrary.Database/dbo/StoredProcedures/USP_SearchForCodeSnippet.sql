CREATE PROCEDURE dbo.USP_SearchForCodeSnippet
AS
	SELECT [CodeSnippetId] = cs.CodeSnippetId,
		   [Description] = cs.[Description],
		   [CodeSample] = cs.CodeSample,
		   [Language] = l.LanguageName,
		   [Tags] = ''
	FROM dbo.CodeSnippet cs
	INNER JOIN dbo.[Language] l ON cs.LanguageId = l.LanguageId

RETURN 0
