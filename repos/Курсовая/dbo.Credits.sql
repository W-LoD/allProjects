CREATE TABLE [dbo].[Credits] (
    [Id]        INT           IDENTITY (1, 1) NOT NULL,
    [Name]      NVARCHAR (50) NULL,
    [Srok]      NCHAR (10)    NULL,
    [Stavka]    INT           NULL,
    [Pasport]   INT           NULL,
    [Z/P]       FLOAT (53)    NULL,
    [Summa]     FLOAT (53)    NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

