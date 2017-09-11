CREATE TABLE [dbo].[Lanche] (
    [Id]        INT          IDENTITY (1, 1) NOT NULL,
    [Nome]      VARCHAR (50) NOT NULL,
	[LastModified] DATETIME     NOT NULL,
    [IsDeleted] BIT          NOT NULL,
    CONSTRAINT [PK_Lanche] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Lanche_Lanche] FOREIGN KEY ([Id]) REFERENCES [dbo].[Lanche] ([Id])
);

