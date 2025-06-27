/****** Object:  Table [dbo].[ProposalLinks]    Script Date: 6/7/2025 11:49:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ProposalLinks]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ProposalLinks](
	[ProposalLinkId] [int] IDENTITY(1,1) NOT NULL,
	[ProposalId] [int] NOT NULL,
	[Url] [nvarchar](1024) NOT NULL,
	[Name] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_ProjectProposalLinks] PRIMARY KEY CLUSTERED 
(
	[ProposalLinkId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[ProposalMembers]    Script Date: 6/7/2025 11:49:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ProposalMembers]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ProposalMembers](
	[ProposalMemberId] [int] IDENTITY(1,1) NOT NULL,
	[ProposalId] [int] NOT NULL,
	[Name] [nvarchar](64) NOT NULL,
	[Role] [nvarchar](64) NOT NULL,
 CONSTRAINT [PK_ProjectTeamMembers] PRIMARY KEY CLUSTERED 
(
	[ProposalMemberId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Proposals]    Script Date: 6/7/2025 11:49:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Proposals]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Proposals](
	[ProposalId] [int] IDENTITY(1,1) NOT NULL,
	[DateSubmitted] [datetime2](7) NOT NULL,
	[ContactEmail] [nvarchar](128) NOT NULL,
	[ContactPhoneNumber] [nvarchar](32) NOT NULL,
	[ContactName] [nvarchar](64) NOT NULL,
	[OrganizationName] [nvarchar](64) NOT NULL,
	[OrganizationHistory] [nvarchar](512) NOT NULL,
	[StaffArePaid] [bit] NOT NULL,
	[ProjectTitle] [nvarchar](64) NOT NULL,
	[TargetAudience] [nvarchar](64) NOT NULL,
	[KeyObjectives] [nvarchar](512) NOT NULL,
	[ProjectTimeFrameTotal] [int] NOT NULL,
	[ProjectTimeFrameInterval] [nvarchar](6) NOT NULL,
	[Methods] [nvarchar](512) NOT NULL,
	[PlannedVideos] [nvarchar](512) NOT NULL,
	[CurrentEquipment] [nvarchar](512) NOT NULL,
	[HasAudioSpace] [bit] NOT NULL,
	[AudioSpaceDescription] [nvarchar](512) NULL,
	[HasComputer] [bit] NOT NULL,
	[ComputerDescription] [nvarchar](512) NULL,
	[EstimatedProjectCost] [int] NOT NULL,
	[CoordinatorNotes] [nvarchar](1000) NULL,
	[InterviewDate] [datetime2](7) NULL,
	[Status] [nvarchar](16) NOT NULL,
 CONSTRAINT [PK_ProjectProposals] PRIMARY KEY CLUSTERED 
(
	[ProposalId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 6/7/2025 11:49:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Roles]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Roles](
	[RoleId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](32) NOT NULL,
	[Description] [nvarchar](256) NULL,
 CONSTRAINT [PK_EthicTeamRoles] PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_Proposals_Status]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Proposals] ADD  CONSTRAINT [DF_Proposals_Status]  DEFAULT (N'PendingInterview') FOR [Status]
END
GO