
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 04/07/2018 18:30:19
-- Generated from EDMX file: C:\Users\Peterson\Desktop\oficina\Oficina\Models\oficina.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [OficinaDb];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Clientes'
CREATE TABLE [dbo].[Clientes] (
    [Oid] int IDENTITY(1,1) NOT NULL,
    [Nome] nvarchar(max)  NOT NULL,
    [CPF] nvarchar(max)  NOT NULL,
    [Email] nvarchar(max)  NOT NULL,
    [Aniversario] datetime  NOT NULL
);
GO

-- Creating table 'Carros'
CREATE TABLE [dbo].[Carros] (
    [Oid] int IDENTITY(1,1) NOT NULL,
    [Placa] nvarchar(max)  NOT NULL,
    [Cor] nvarchar(max)  NOT NULL,
    [Modelo] nvarchar(max)  NOT NULL,
    [Marca] nvarchar(max)  NOT NULL,
    [Ano] int  NOT NULL,
    [Cliente_Oid] int  NOT NULL
);
GO

-- Creating table 'Faturas'
CREATE TABLE [dbo].[Faturas] (
    [Oid] int IDENTITY(1,1) NOT NULL,
    [ValorRecebido] decimal(18,0)  NOT NULL,
    [TipoPagamento] nvarchar(max)  NOT NULL,
    [Carro_Oid] int  NOT NULL
);
GO

-- Creating table 'Pecas'
CREATE TABLE [dbo].[Pecas] (
    [Oid] int IDENTITY(1,1) NOT NULL,
    [Nome] nvarchar(max)  NOT NULL,
    [Quantidade] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Oid] in table 'Clientes'
ALTER TABLE [dbo].[Clientes]
ADD CONSTRAINT [PK_Clientes]
    PRIMARY KEY CLUSTERED ([Oid] ASC);
GO

-- Creating primary key on [Oid] in table 'Carros'
ALTER TABLE [dbo].[Carros]
ADD CONSTRAINT [PK_Carros]
    PRIMARY KEY CLUSTERED ([Oid] ASC);
GO

-- Creating primary key on [Oid] in table 'Faturas'
ALTER TABLE [dbo].[Faturas]
ADD CONSTRAINT [PK_Faturas]
    PRIMARY KEY CLUSTERED ([Oid] ASC);
GO

-- Creating primary key on [Oid] in table 'Pecas'
ALTER TABLE [dbo].[Pecas]
ADD CONSTRAINT [PK_Pecas]
    PRIMARY KEY CLUSTERED ([Oid] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Cliente_Oid] in table 'Carros'
ALTER TABLE [dbo].[Carros]
ADD CONSTRAINT [FK_ClienteCarro]
    FOREIGN KEY ([Cliente_Oid])
    REFERENCES [dbo].[Clientes]
        ([Oid])
    ON DELETE CASCADE ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ClienteCarro'
CREATE INDEX [IX_FK_ClienteCarro]
ON [dbo].[Carros]
    ([Cliente_Oid]);
GO

-- Creating foreign key on [Carro_Oid] in table 'Faturas'
ALTER TABLE [dbo].[Faturas]
ADD CONSTRAINT [FK_CarroFatura]
    FOREIGN KEY ([Carro_Oid])
    REFERENCES [dbo].[Carros]
        ([Oid])
    ON DELETE CASCADE ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_CarroFatura'
CREATE INDEX [IX_FK_CarroFatura]
ON [dbo].[Faturas]
    ([Carro_Oid]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------