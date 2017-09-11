CREATE TABLE [dbo].[Pedido] (
     [Id]        INT          IDENTITY (1, 1) NOT NULL,
    [ClienteId]    INT             NOT NULL,
    [Valor]        DECIMAL (18, 2) NOT NULL,
	[LastModified] DATETIME     NOT NULL,
    [IsDeleted]    BIT             NOT NULL,
    CONSTRAINT [PK_Pedido] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Pedido_Pedido] FOREIGN KEY ([ClienteId]) REFERENCES [dbo].[Cliente] ([Id])
);

