CREATE TABLE dbo.[Language]
(
	LanguageId UNIQUEIDENTIFIER NOT NULL,
	LanguageName NVARCHAR(30) NOT NULL,
	CONSTRAINT PK_Language PRIMARY KEY (LanguageId),
	CONSTRAINT UQ_Language_LanguageName UNIQUE(LanguageName)
)