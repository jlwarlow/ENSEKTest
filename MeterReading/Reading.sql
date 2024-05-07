CREATE TABLE [dbo].[Reading](
	[AccountId] [int] NOT NULL,
	[MeterReadingDateTime] [datetime] NOT NULL,
	[MeterReadValue] [nvarchar](50) NOT NULL
)
GO

ALTER TABLE [dbo].[Reading]  WITH CHECK ADD  CONSTRAINT [FK_Reading_AccountId] FOREIGN KEY([AccountId])
REFERENCES [dbo].[Account] ([AccountId])
GO
