ALTER TABLE dbo.Proposals ADD
	Status nvarchar(16) NOT NULL CONSTRAINT DF_Proposals_Status DEFAULT N'PendingInterview'
GO
ALTER TABLE dbo.Proposals
	DROP CONSTRAINT DF_Proposals_IsApproved
GO
ALTER TABLE dbo.Proposals
	DROP COLUMN IsApproved
GO