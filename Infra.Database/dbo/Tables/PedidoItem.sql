CREATE TABLE [dbo].[PedidoItem] (
    [PedidoId]      INT      NOT NULL,
    [LancheId]      INT      NOT NULL,
    [IngredienteId] INT      NOT NULL,
    [QuantidadeIngrediente]    INT      NOT NULL,
	[LastModified] DATETIME     NOT NULL,
	[IsDeleted] BIT NOT NULL, 
    CONSTRAINT [PK_Pedido_Item] PRIMARY KEY CLUSTERED ([PedidoId] ASC, [LancheId] ASC, [IngredienteId] ASC),
    CONSTRAINT [FK_PedidoItem_Ingrediente] FOREIGN KEY ([IngredienteId]) REFERENCES [dbo].[Ingrediente] ([Id]),
    CONSTRAINT [FK_PedidoItem_Lanche] FOREIGN KEY ([LancheId]) REFERENCES [dbo].[Lanche] ([Id]),
    CONSTRAINT [FK_PedidoItem_Pedido] FOREIGN KEY ([PedidoId]) REFERENCES [dbo].[Pedido] ([Id])
);

