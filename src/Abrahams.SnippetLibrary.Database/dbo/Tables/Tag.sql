﻿CREATE TABLE dbo.Tag
(
	TagId UNIQUEIDENTIFIER NOT NULL,
	TagName NVARCHAR(255) NOT NULL,
	CONSTRAINT PK_Tag PRIMARY KEY (TagId),
)
