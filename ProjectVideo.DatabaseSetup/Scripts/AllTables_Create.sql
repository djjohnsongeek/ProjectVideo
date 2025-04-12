USE [C:\USERS\DANIE\ONEDRIVE\DOCUMENTS\PROJECTVIDEO.MDF]
GO
/****** Object:  Table [dbo].[ProjectProposalLinks]    Script Date: 4/12/2025 9:00:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ProjectProposalLinks]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ProjectProposalLinks](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProjectProposalId] [int] NOT NULL,
	[Url] [nvarchar](1024) NOT NULL,
 CONSTRAINT [PK_ProjectProposalLinks] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[ProjectProposals]    Script Date: 4/12/2025 9:00:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ProjectProposals]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ProjectProposals](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ContactEmail] [nvarchar](128) NOT NULL,
	[ContactName] [nvarchar](64) NOT NULL,
	[OrganizationName] [nvarchar](64) NOT NULL,
	[OrganizationHistory] [nvarchar](512) NOT NULL,
	[StaffArePaid] [bit] NOT NULL,
	[ProjectTitle] [nvarchar](64) NOT NULL,
	[TargetAudience] [nvarchar](64) NOT NULL,
	[KeyObjective] [nvarchar](512) NOT NULL,
	[ProjectTimeFrameTotal] [int] NOT NULL,
	[ProjectTimeFrameInterval] [nvarchar](6) NOT NULL,
	[Methods] [nvarchar](512) NOT NULL,
	[PlannedVideos] [nvarchar](512) NOT NULL,
	[CurrentEquipment] [nvarchar](512) NOT NULL,
	[HasAudioSpace] [bit] NOT NULL,
	[AudioSpaceDescription] [nvarchar](512) NULL,
	[HasComputer] [bit] NOT NULL,
	[ComputerDescriptipon] [nvarchar](512) NULL,
	[EstimatedProjectCost] [int] NOT NULL,
 CONSTRAINT [PK_ProjectProposals] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[ProjectProposalTeamMembers]    Script Date: 4/12/2025 9:00:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ProjectProposalTeamMembers]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ProjectProposalTeamMembers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProjectProposalId] [int] NOT NULL,
	[Name] [nvarchar](64) NOT NULL,
	[Role] [nvarchar](64) NOT NULL,
 CONSTRAINT [PK_ProjectTeamMembers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
