TRUNCATE TABLE dbo.DropdownOptions;

SET IDENTITY_INSERT dbo.DropdownOptions ON;

INSERT INTO dbo.DropdownOptions ([DropDownOptionId], [LocalizationId], [DropdownId])
VALUES
( 1, 48, 1),
( 2, 49, 1),
( 3, 50, 1),
( 4, 51, 1),
( 5, 52, 1),
( 6, 53, 2),
( 7, 54, 2),
( 8, 55, 2),
( 9, 56, 2)

SET IDENTITY_INSERT dbo.DropdownOptions OFF;