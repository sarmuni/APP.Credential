USE [master_data]
GO

/****** Object:  Table [dbo].[MobileAppsDeviceID]    Script Date: 10/9/2023 8:51:11 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[MobileAppsDeviceID](
	[IDMill] [varchar](10) NOT NULL,
	[DeviceID] [varchar](500) NOT NULL,
	[CrtUsrID] [varchar](20) NOT NULL,
	[TsCrt] [datetime] NOT NULL,
	[ModUsrID] [varchar](20) NOT NULL,
	[TsMod] [datetime] NOT NULL,
	[ActiveFlag] [char](1) NOT NULL,
 CONSTRAINT [PK_MobileAppsDeviceID] PRIMARY KEY CLUSTERED 
(
	[IDMill] ASC,
	[DeviceID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[MobileAppsDeviceID] ADD  CONSTRAINT [DF_MobileAppsDeviceID_TsCrt]  DEFAULT (getdate()) FOR [TsCrt]
GO

ALTER TABLE [dbo].[MobileAppsDeviceID] ADD  CONSTRAINT [DF_MobileAppsDeviceID_TsMod]  DEFAULT (getdate()) FOR [TsMod]
GO

ALTER TABLE [dbo].[MobileAppsDeviceID] ADD  CONSTRAINT [DF_MobileAppsDeviceID_ActiveFlag]  DEFAULT ('Y') FOR [ActiveFlag]
GO


USE [master_data]
GO

/****** Object:  Table [dbo].[MobileAppsUserLogin]    Script Date: 10/9/2023 8:51:19 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[MobileAppsUserLogin](
	[IDMill] [varchar](10) NOT NULL,
	[UserID] [varchar](20) NOT NULL,
	[Apps] [varchar](20) NOT NULL,
	[FullName] [varchar](200) NULL,
	[Role] [varchar](10) NULL,
	[CrtUsrID] [varchar](20) NOT NULL,
	[TsCrt] [datetime] NOT NULL,
	[ModUsrID] [varchar](20) NOT NULL,
	[TsMod] [datetime] NOT NULL,
	[ActiveFlag] [char](1) NOT NULL,
 CONSTRAINT [PK_MobileAppsUserLogin_1] PRIMARY KEY CLUSTERED 
(
	[IDMill] ASC,
	[UserID] ASC,
	[Apps] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[MobileAppsUserLogin] ADD  CONSTRAINT [DF_MobileAppsUserLogin_TsCrt]  DEFAULT (getdate()) FOR [TsCrt]
GO

ALTER TABLE [dbo].[MobileAppsUserLogin] ADD  CONSTRAINT [DF_MobileAppsUserLogin_TsMod]  DEFAULT (getdate()) FOR [TsMod]
GO

ALTER TABLE [dbo].[MobileAppsUserLogin] ADD  CONSTRAINT [DF_MobileAppsUserLogin_ActiveFlag]  DEFAULT ('Y') FOR [ActiveFlag]
GO


USE [master_data]
GO

/****** Object:  Table [dbo].[MobileAppsVersion]    Script Date: 10/9/2023 8:51:25 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[MobileAppsVersion](
	[IDMill] [varchar](10) NOT NULL,
	[Apps] [nchar](10) NOT NULL,
	[VersionName] [varchar](50) NOT NULL,
	[VersionCode] [varchar](10) NOT NULL,
	[DownloadURL] [varchar](100) NULL,
	[ReleaseDate] [datetime] NULL,
	[Remark] [varchar](100) NULL,
	[CrtUsrID] [varchar](20) NOT NULL,
	[TsCrt] [datetime] NOT NULL,
	[ModUsrID] [varchar](20) NOT NULL,
	[TsMod] [datetime] NOT NULL,
	[ActiveFlag] [char](1) NOT NULL,
 CONSTRAINT [PK_MobileAppsVersion] PRIMARY KEY CLUSTERED 
(
	[IDMill] ASC,
	[Apps] ASC,
	[VersionName] ASC,
	[VersionCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[MobileAppsVersion] ADD  CONSTRAINT [DF_MobileAppsVersion_TsCrt]  DEFAULT (getdate()) FOR [TsCrt]
GO

ALTER TABLE [dbo].[MobileAppsVersion] ADD  CONSTRAINT [DF_MobileAppsVersion_TsMod]  DEFAULT (getdate()) FOR [TsMod]
GO

ALTER TABLE [dbo].[MobileAppsVersion] ADD  CONSTRAINT [DF_MobileAppsVersion_ActiveFlag]  DEFAULT ('Y') FOR [ActiveFlag]
GO


