CREATE TABLE dbo.CodeSnippet
(
	CodeSnippetId INT NOT NULL IDENTITY (1, 10),
    LanguageId INT NOT NULL,
	[Description] NVARCHAR(255) NOT NULL,
    CodeSample NVARCHAR(MAX) NOT NULL,
	CONSTRAINT PK_CodeSnippet PRIMARY KEY (CodeSnippetId),
    CONSTRAINT FK_Language_CodeSnippet FOREIGN KEY (LanguageId) REFERENCES [Language](LanguageId)
)

        --public string Description { get; set; }
        --public string CodeSample { get; set; }
        --public Language Language { get; set; }
        --public List<Tag> Tags { get; } = new List<Tag>();