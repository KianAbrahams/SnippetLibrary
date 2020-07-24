CREATE PROCEDURE dbo.USP_GetAvailableLanguages
AS
	SELECT LanguageId, LanguageName 
	FROM dbo.[Language]

RETURN 0
