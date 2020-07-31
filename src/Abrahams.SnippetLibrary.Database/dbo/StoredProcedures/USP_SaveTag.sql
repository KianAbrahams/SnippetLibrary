CREATE PROCEDURE dbo.USP_SaveTag
(
	@TagName NVARCHAR(255),
	@TagId INT
)
AS
	IF (EXISTS (SELECT TagId FROM Tag WHERE TagId = @TagId))
	BEGIN
		UPDATE dbo.Tag
		SET TagName = @TagName 
		WHERE TagId = @TagId

		RETURN @TagId
	END 
	ELSE
	BEGIN
		INSERT INTO dbo.Tag(TagId, TagName) 
		VALUES (@TagId, @TagName)

		RETURN SCOPE_IDENTITY()
	END
	
RETURN 0