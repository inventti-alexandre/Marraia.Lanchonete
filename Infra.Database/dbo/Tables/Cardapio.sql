CREATE TABLE [dbo].[Cardapio] (
    [LancheId]      INT NOT NULL,
    [IngredienteId] INT NOT NULL,
    [Quantidade]    INT NOT NULL,
	[LastModified] DATETIME     NOT NULL,
    [IsDeleted]     INT NOT NULL,
    CONSTRAINT [FK_Cardapio_Ingrediente] FOREIGN KEY ([IngredienteId]) REFERENCES [dbo].[Ingrediente] ([Id]),
    CONSTRAINT [FK_Cardapio_Lanche] FOREIGN KEY ([LancheId]) REFERENCES [dbo].[Lanche] ([Id]), 
    CONSTRAINT [PK_Cardapio] PRIMARY KEY ([LancheId], [IngredienteId])
);

