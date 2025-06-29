BEGIN TRANSACTION
GO
CREATE TABLE dbo.UserRoles
	(
	UserRoleId int NOT NULL IDENTITY (1, 1),
	UserId int NOT NULL,
	RoleId int NOT NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.UserRoles ADD CONSTRAINT
	PK_UserRoles PRIMARY KEY CLUSTERED 
	(
	UserRoleId
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.UserRoles SET (LOCK_ESCALATION = TABLE)
GO
COMMIT