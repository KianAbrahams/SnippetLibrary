CREATE TABLE dbo.CodeSnippetTag
(
	CodeSnippetTagId INT NOT NULL IDENTITY (1, 10),
    CodeSnippetId INT NOT NULL,
	TagId INT NOT NULL,
	CONSTRAINT PK_CodeSnippetTag PRIMARY KEY (CodeSnippetTagId),
    CONSTRAINT FK_CodeSnippet_CodeSnippetTag FOREIGN KEY (CodeSnippetId) REFERENCES CodeSnippet(CodeSnippetId),
	CONSTRAINT FK_CodeSnippet_Tag FOREIGN KEY (TagId) REFERENCES Tag(TagId)
)
