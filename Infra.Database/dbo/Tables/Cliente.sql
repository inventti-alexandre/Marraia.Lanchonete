CREATE TABLE [dbo].[Cliente] (
    [Id]           INT          IDENTITY (1, 1) NOT NULL,
    [Nome]         VARCHAR (50) NOT NULL,
	[LastModified] DATETIME     NOT NULL,
    [IsDeleted] BIT NOT NULL, 
    CONSTRAINT [PK_Cliente] PRIMARY KEY CLUSTERED ([Id] ASC)
);

