TRUNCATE TABLE dbo.Roles;


SET IDENTITY_INSERT dbo.Roles ON;

INSERT INTO dbo.Roles ([RoleId], [Name], [Description])
VALUES
( 1, N'Staff', N'Staff things' ),
( 2, N'Coordinator', N'Staff things' ),
( 3, N'Admin', N'Admin functionality' )


SET IDENTITY_INSERT dbo.Roles OFF;