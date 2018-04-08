
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 04/08/2018 00:36:05
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

IF OBJECT_ID(N'[dbo].[FK_ClienteCarro]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Carros] DROP CONSTRAINT [FK_ClienteCarro];
GO
IF OBJECT_ID(N'[dbo].[FK_CarroFatura]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Faturas] DROP CONSTRAINT [FK_CarroFatura];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Clientes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Clientes];
GO
IF OBJECT_ID(N'[dbo].[Carros]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Carros];
GO
IF OBJECT_ID(N'[dbo].[Faturas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Faturas];
GO
IF OBJECT_ID(N'[dbo].[Pecas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Pecas];
GO

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
    [TipoPagamento] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Pecas'
CREATE TABLE [dbo].[Pecas] (
    [Oid] int IDENTITY(1,1) NOT NULL,
    [Codigo] nvarchar(max)  NOT NULL,
    [TipoPeca_Oid] int  NOT NULL,
    [Atendimento_Oid] int  NOT NULL
);
GO

-- Creating table 'Atendimentoes'
CREATE TABLE [dbo].[Atendimentoes] (
    [Oid] int IDENTITY(1,1) NOT NULL,
    [Codigo] nvarchar(max)  NOT NULL,
    [DataInicio] nvarchar(max)  NOT NULL,
    [DataFim] nvarchar(max)  NOT NULL,
    [Carro_Oid] int  NOT NULL,
    [Fatura_Oid] int  NOT NULL
);
GO

-- Creating table 'TipoPecas'
CREATE TABLE [dbo].[TipoPecas] (
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

-- Creating primary key on [Oid] in table 'Atendimentoes'
ALTER TABLE [dbo].[Atendimentoes]
ADD CONSTRAINT [PK_Atendimentoes]
    PRIMARY KEY CLUSTERED ([Oid] ASC);
GO

-- Creating primary key on [Oid] in table 'TipoPecas'
ALTER TABLE [dbo].[TipoPecas]
ADD CONSTRAINT [PK_TipoPecas]
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

-- Creating foreign key on [Carro_Oid] in table 'Atendimentoes'
ALTER TABLE [dbo].[Atendimentoes]
ADD CONSTRAINT [FK_CarroAtendimento]
    FOREIGN KEY ([Carro_Oid])
    REFERENCES [dbo].[Carros]
        ([Oid])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_CarroAtendimento'
CREATE INDEX [IX_FK_CarroAtendimento]
ON [dbo].[Atendimentoes]
    ([Carro_Oid]);
GO

-- Creating foreign key on [Fatura_Oid] in table 'Atendimentoes'
ALTER TABLE [dbo].[Atendimentoes]
ADD CONSTRAINT [FK_AtendimentoFatura]
    FOREIGN KEY ([Fatura_Oid])
    REFERENCES [dbo].[Faturas]
        ([Oid])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_AtendimentoFatura'
CREATE INDEX [IX_FK_AtendimentoFatura]
ON [dbo].[Atendimentoes]
    ([Fatura_Oid]);
GO

-- Creating foreign key on [TipoPeca_Oid] in table 'Pecas'
ALTER TABLE [dbo].[Pecas]
ADD CONSTRAINT [FK_TipoPeca_Peca]
    FOREIGN KEY ([TipoPeca_Oid])
    REFERENCES [dbo].[TipoPecas]
        ([Oid])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_TipoPeca_Peca'
CREATE INDEX [IX_FK_TipoPeca_Peca]
ON [dbo].[Pecas]
    ([TipoPeca_Oid]);
GO

-- Creating foreign key on [Atendimento_Oid] in table 'Pecas'
ALTER TABLE [dbo].[Pecas]
ADD CONSTRAINT [FK_AtendimentoPeca]
    FOREIGN KEY ([Atendimento_Oid])
    REFERENCES [dbo].[Atendimentoes]
        ([Oid])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_AtendimentoPeca'
CREATE INDEX [IX_FK_AtendimentoPeca]
ON [dbo].[Pecas]
    ([Atendimento_Oid]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------