TRUNCATE TABLE dbo.EthnicTeamRoles;


SET IDENTITY_INSERT dbo.EthnicTeamRoles ON;

INSERT INTO dbo.EthnicTeamRoles ([EthnicTeamRoleId], [LocalizationId])
VALUES
( 1, 48 ),
( 2, 49 ),
( 3, 50 ),
( 4, 51 ),
( 5, 52 )

SET IDENTITY_INSERT dbo.EthnicTeamRoles OFF;