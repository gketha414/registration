USE [PatientPreRegistration_TEST]
GO
/****** Object:  Table [dbo].[InsuranceAttachments]    Script Date: 11/7/2024 6:45:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InsuranceAttachments](
	[Id] [int] NOT NULL,
	[PersonId] [int] NOT NULL,
	[InsId] [int] NOT NULL,
	[FileName] [varchar](200) NOT NULL,
 CONSTRAINT [PK_InsuranceAttachments] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
