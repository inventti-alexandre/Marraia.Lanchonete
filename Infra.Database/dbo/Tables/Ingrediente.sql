CREATE TABLE [dbo].[Ingrediente] (
    [Id]        INT             IDENTITY (1, 1) NOT NULL,
    [Nome]      VARCHAR (50)    NOT NULL,
    [Valor]     DECIMAL (18, 2) NOT NULL,
	[LastModified] DATETIME     NOT NULL,
    [IsDeleted] BIT             NOT NULL,
    CONSTRAINT [PK_Ingrediente] PRIMARY KEY CLUSTERED ([Id] ASC)
);

