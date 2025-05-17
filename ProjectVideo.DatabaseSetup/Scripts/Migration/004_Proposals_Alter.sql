EXECUTE sp_rename N'dbo.Proposals.IntroMeetingDate', N'Tmp_InterviewDate', 'COLUMN'
GO
EXECUTE sp_rename N'dbo.Proposals.Tmp_InterviewDate', N'InterviewDate', 'COLUMN' 
GO