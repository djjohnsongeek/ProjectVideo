TRUNCATE TABLE dbo.EthnicTeamRoles;


SET IDENTITY_INSERT dbo.EthnicTeamRoles ON;

INSERT INTO dbo.EthnicTeamRoles ([EthnicTeamRoleId], [Name], [Description])
VALUES
( 1, N'Ministry Director', N'Director of the ministry.' ),
( 2, N'Studio / Team Manager', N'Manages the team.' ),
( 3, N'Camera Operator', N'Takes raw footage and organizes it, adds sound, graphics, and more.' ),
( 4, N'Video Editor', N'Edits the videos.' ),
( 5, N'Audio Engineer', N'Music and Sound Effects' )


SET IDENTITY_INSERT dbo.EthnicTeamRoles OFF;