    ALTER TABLE dbo.EthnicTeamRoles
        ADD DropdownId INT NOT NULL
        CONSTRAINT DF_EthnicTeamRoles_DropdownId DEFAULT(0);

    EXEC sp_rename 'dbo.EthnicTeamRoles.EthnicTeamRoleId', 'DropdownOptionId', 'COLUMN';
    EXEC sp_rename 'dbo.EthnicTeamRoles', 'DropdownOptions';