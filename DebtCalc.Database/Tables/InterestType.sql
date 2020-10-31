CREATE TABLE [dbo].[InterestType]
(
	[Id] BIGINT IDENTITY(1,1) NOT NULL CONSTRAINT PK_Interest_Type  PRIMARY KEY,
	[vch_name] VARCHAR(50) NOT NULL,
	[int_value] INT NOT NULL
)
