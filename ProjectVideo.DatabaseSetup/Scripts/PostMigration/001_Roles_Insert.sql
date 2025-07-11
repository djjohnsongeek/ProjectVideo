TRUNCATE TABLE dbo.Roles;


SET IDENTITY_INSERT dbo.Roles ON;

INSERT INTO dbo.Roles ([RoleId], [Name], [Description])
VALUES
( 1, N'Staff', N'Staff things' ),
( 2, N'Coordinator', N'Coordinator things' ),
( 3, N'Admin', N'Admin things' ),
( 4, N'EthnicTeamMember', N'Ethinic team things'),
( 5, N'Mentor', N'Mentor things')


SET IDENTITY_INSERT dbo.Roles OFF;