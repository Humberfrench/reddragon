USE [RedDragon]
GO

/****** Object:  Table [dbo].[Aviao]    Script Date: 17/01/2020 21:14:26 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Aviao](
	[AviaoId] [int] IDENTITY(1,1) NOT NULL,
	[Modelo] [varchar](50) NOT NULL,
	[QuantidadeDePassageiros] [int] NOT NULL,
	[DataCriacao] [datetime] NOT NULL,
 CONSTRAINT [PK_Aviao] PRIMARY KEY CLUSTERED 
(
	[AviaoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

