CREATE PROCEDURE dbo.USP_GetCodeSnippet (@CodeSnippetId INT)
AS
	SELECT cs.CodeSnippetId,
		   cs.[Description],
		   cs.CodeSample,
		   l.LanguageId,
		   l.LanguageName
	FROM dbo.CodeSnippet cs
	INNER JOIN dbo.[Language] l ON cs.LanguageId = l.LanguageId
	WHERE cs.CodeSnippetId = @CodeSnippetId

RETURN 0
