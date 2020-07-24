CREATE TABLE dbo.[Language]
(
	LanguageId INT NOT NULL IDENTITY (1, 10),
	LanguageName NVARCHAR(30) NOT NULL,
	CONSTRAINT PK_Language PRIMARY KEY (LanguageId),
	CONSTRAINT UQ_Language_LanguageName UNIQUE(LanguageName)
)