﻿CREATE TABLE dbo.Tag
(
	TagId INT NOT NULL IDENTITY (1, 10),
	TagName NVARCHAR(255) NOT NULL,
	CONSTRAINT PK_Tag PRIMARY KEY (TagId),
)

