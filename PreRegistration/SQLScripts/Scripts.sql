ALTER TABLE [PatientPreRegistration_TEST].[dbo].[AccidentType]
ADD IsActive bit not null default(1);


ALTER TABLE [PatientPreRegistration_TEST].[dbo].[Hospital]
ADD IsActive bit not null default(1);

ALTER TABLE [PatientPreRegistration_TEST].[dbo].[ResponsibleParty]
ADD IsActive bit not null default(1);


 ALTER TABLE [PatientPreRegistration_TEST].[dbo].[States]
ADD IsActive bit not null default(1);

  ALTER TABLE [PatientPreRegistration_TEST].[dbo].[States]
ADD CONSTRAINT PK_State_ID PRIMARY KEY([StateID])


CREATE TABLE [dbo].[Ethnicity](
	[EthnicityID] [smallint] IDENTITY(1,1) NOT NULL,
	[Description] [varchar](150) NOT NULL,
	[IsActive] [bit] NOT NULL default(1),
 CONSTRAINT [PK_Ethnicity] PRIMARY KEY CLUSTERED 
(
	[EthnicityID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


INSERT INTO [dbo].[Ethnicity] ( [Description] ) VALUES
('White'),
('Black or African American'),
('Hispanic or Latino'),
('Asian'),
('American Indian or Alaska Native'),
('Native Hawaiian or Other Pacific Islander'),
('Other'),
('Prefer not to say');

CREATE TABLE [dbo].[Gender](
	[GenderID] [smallint] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](150) NOT NULL,
	[IsActive] [bit] NOT NULL default(1),
 CONSTRAINT [PK_Gender] PRIMARY KEY CLUSTERED 
(
	[GenderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


INSERT INTO [dbo].[Gender] ( [Name] ) VALUES
('Male'),
('Female'),
('Non-Binary'),
('Prefer not to say');

CREATE TABLE [dbo].[AttachmentTypes](
	[ID] [smallint] IDENTITY(1,1) NOT NULL,
	[AttachmentType] [varchar](75) NOT NULL,
	[IsActive] [bit] NOT NULL default(1),
 CONSTRAINT [PK_AttachmentTypes] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


INSERT INTO [dbo].[AttachmentTypes] ( [AttachmentType] ) VALUES
('Insurance Card'),
('Birth Certificate'),
('SSN');

CREATE TABLE [dbo].[Race](
	[RaceID] [smallint] IDENTITY(1,1) NOT NULL,
	[Description] [varchar](150) NOT NULL,
	[IsActive] [bit] NOT NULL default(1),
 CONSTRAINT [PK_Race] PRIMARY KEY CLUSTERED 
(
	[RaceID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

--Create Lookup Screens
INSERT INTO [dbo].[Race] ( [Description] ) VALUES
('American Indian or Alaska Native'),
('Asian'),
('Black or African American'),
('Hispanic'),
('Mixed Race'),
('Native Hawaiian or Other Pacific Islander'),
('Hispanic'),
('Other Race'),
('White');


CREATE TABLE [dbo].[MaritalStatus](
	[ID] [smallint] IDENTITY(1,1) NOT NULL,
	[Description] [varchar](150) NOT NULL,
	[IsActive] [bit] NOT NULL default(1),
 CONSTRAINT [PK_MaritalStatus] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


INSERT INTO [dbo].[MaritalStatus] ( [Description] ) VALUES
('Single'),
('Married'),
('Separated'),
('Divorced');

CREATE TABLE [dbo].[HospitalService](
	[ID] [smallint] IDENTITY(1,1) NOT NULL,
	[Description] [varchar](150) NOT NULL,
	[IsActive] [bit] NOT NULL default(1),
 CONSTRAINT [PK_HospitalService] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


INSERT INTO [dbo].[HospitalService] ( [Description] ) VALUES
('Pregnancy'),
('Surgery'),
('Other');

CREATE TABLE [dbo].[BirthGender](
	[ID] [smallint] IDENTITY(1,1) NOT NULL,
	[Description] [varchar](150) NOT NULL,
	[IsActive] [bit] NOT NULL default(1),
 CONSTRAINT [PK_BirthGender] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


INSERT INTO [dbo].[BirthGender] ( [Description] ) VALUES
('Female'),
('Male');

  ALTER TABLE [PatientPreRegistration_TEST].[dbo].[PatientDemographics]
ADD CurrentlyIdentifyAs varchar(25) null;
