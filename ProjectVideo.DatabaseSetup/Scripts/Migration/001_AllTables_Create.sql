/****** Object:  Table [dbo].[EthicTeamRoles]    Script Date: 4/17/2025 5:23:33 AM ******/
CREATE TABLE [dbo].[EthnicTeamRoles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](32) NOT NULL,
	[Description] [nvarchar](128) NULL,
 CONSTRAINT [PK_EthicTeamRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProposalLinks]    Script Date: 4/17/2025 5:23:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProposalLinks](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProposalId] [int] NOT NULL,
	[Url] [nvarchar](1024) NOT NULL,
	[Name] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_ProjectProposalLinks] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Proposals]    Script Date: 4/17/2025 5:23:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Proposals](
	[Id] [int] IDENTITY(1,1) NOT NULL,
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
 CONSTRAINT [PK_ProjectProposals] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProposalTeamMembers]    Script Date: 4/17/2025 5:23:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProposalTeamMembers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProposalId] [int] NOT NULL,
	[Name] [nvarchar](64) NOT NULL,
	[Role] [nvarchar](64) NOT NULL,
 CONSTRAINT [PK_ProjectTeamMembers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
