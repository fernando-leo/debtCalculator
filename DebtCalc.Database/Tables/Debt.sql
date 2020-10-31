CREATE TABLE [dbo].[Debt]
(
	[Id] BIGINT IDENTITY(1,1) NOT NULL CONSTRAINT PK_Debt  PRIMARY KEY, 
    [dec_original_value] DECIMAL NOT NULL, 
    [dtt_original_date] DATETIME NOT NULL, 
    [FK_interest_type] BIGINT NOT NULL, 
    [int_installments] INT NOT NULL, 
    [dtt_final_date] DATETIME NOT NULL, 
    [int_comission] INT NOT NULL,
    [dec_final_value] DECIMAL NOT NULL,

    CONSTRAINT [FK_interest_type_Debt_InterestType] FOREIGN KEY ([FK_interest_type]) REFERENCES [dbo].[InterestType] ([Id])
)
