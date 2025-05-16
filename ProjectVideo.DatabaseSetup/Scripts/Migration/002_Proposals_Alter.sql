ALTER TABLE dbo.Proposals ADD
	CoordinatorNotes nvarchar(1000) NULL,
	IntroMeetingDate datetime2(7) NULL,
	IsApproved bit NOT NULL CONSTRAINT DF_Proposals_IsApproved DEFAULT 0